<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Carbon\Carbon;
use Illuminate\Support\Facades\Auth;
use App\Models\services;
use App\Models\employees;
use App\Models\shifts;
use App\Models\appointments;
use App\Models\prices;
use Illuminate\Support\Facades\Mail;
use App\Mail\ReservationMail;

class ReservationController extends Controller
{
    public function Barber()
    {
         return view('barber', [
            'services' => services::where('salon_id',1)->get(),
            'employees' => employees::where('salon_id', 1)
                                    ->where('active', 1)
                                    ->get(),
            'step' => 'service',
            'selectedService' => null,
            'selectedBarber' => null,
            'selectedDate' => null,
            'selectedTime' => null,
            'times' => [],
            'message' => null,
            'serviceForUser' => null,
            'barberForUser' => null,
            'priceForUser' => null,
        ]);
    }

    public function BarberBtn(Request $request)
    {

        $step = 'service';
        $times = [];
        $message = null;

        $services = services::where('salon_id',1)->get();
        $employees = employees::where('salon_id', 1)
                                ->where('active', 1)
                                ->get();

        if ($request->filled('service_id')) {
            $step = 'employee';
        }

        if ($request->filled('service_id') && $request->filled('barber_id')) {
            $step = 'time';
        }

        if ($request->filled('service_id') && $request->filled('barber_id') && $request->filled('date'))
        {
            $shift = shifts::where('employee_id', $request->barber_id)
                            ->where('shift_date', $request->date)
                            ->first();

            if (!$shift)
            {
                $message = 'A kiválasztott barber ezen a napon nem dolgozik.';
            }

            else
            {
                $duration = services::where('service_id', $request->service_id)
                                    ->value('duration');

                $appointments = appointments::where('employee_id', $request->barber_id)
                                            ->where('appointment_date',$request->date)
                                            ->where('active', 1)
                                            ->get();


                $start = Carbon::parse($request->date . ' ' . $shift->start_time);
                $end   = Carbon::parse($request->date . ' ' . $shift->end_time);

                $slot = 30;

                while ($start->copy()->addMinutes($duration) <= $end) {
                    $isFree = true;
                    foreach ($appointments as $appointment) {

                        $appStart = Carbon::parse($request->date . ' ' . $appointment->start_time);
                        $appEnd   = Carbon::parse($request->date . ' ' . $appointment->finish_time);

                        if ($start < $appEnd && $start->copy()->addMinutes($duration) > $appStart) {
                            $isFree = false;
                            break;
                        }
                    }

                    if($isFree){
                        $times[] = $start->format('H:i');
                    }

                    $start->addMinutes($slot);
                }

                if (empty($times)) {
                    $message = 'Erre a napra nincs több szabad időpont.';
                }

                $step = 'time';
            }

        }

        if (
            $request->filled('service_id') &&
            $request->filled('barber_id') &&
            $request->filled('date') &&
            $request->filled('time')
        )
        {
            $step = 'submit';
        }

        return view('barber', [
            'services' => $services,
            'employees' => $employees,
            'step' => $step,
            'selectedService' => $request->service_id,
            'selectedBarber' => $request->barber_id,
            'selectedDate' => $request->date,
            'selectedTime' => $request->time,
            'times' => $times,
            'message' => $message,
            'serviceForUser' => services::where('service_id',$request->service_id)
                                        ->value('name'),
            'barberForUser' => employees::where('employee_id',$request->barber_id)
                                        ->value('name'),
            'priceForUser' => prices::where('employee_id',$request->barber_id)
                                    ->where('service_id',$request->service_id)
                                    ->value('price'),
            'endForUser' => Carbon::parse($request->date . ' ' . $request->time)
                                    ->addMinutes(services::where('service_id',$request->service_id)->value('duration'))
                                    ->format('H:i')
        ]);
    }

    public function SaveBtn(Request $request){
        $appointment = new appointments;
        $appointment->service_id = $request->service_id;
        $appointment->employee_id = $request->barber_id;
        $appointment->user_id = Auth::user()->user_id;
        $appointment->appointment_date = $request->date;
        $appointment->start_time = $request->time;

        $duration = services::where('service_id',$request->service_id)
                        ->value('duration');
        $appointment->finish_time = Carbon::createFromFormat('H:i', $request->time)
                                    ->addMinutes($duration)
                                    ->format('H:i');

        $appointment->note = $request->note;
        $appointment->save();

        Mail::to(Auth::user()->email)->send(new ReservationMail($appointment));
        return redirect('/')->with(
            'success', 'Sikeres időpontfoglalás. Kérjük, ellenőrizze a beérkező levelek mappáját.'
        );
    }

}
