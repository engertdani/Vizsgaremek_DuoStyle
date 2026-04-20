<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use App\Models\appointments;
use App\Models\services;
use App\Models\employees;
use App\Models\shifts;
use App\Models\prices;
use Carbon\Carbon;
use Illuminate\Support\Facades\Mail;
use App\Mail\ReservationMail;

class MassageController extends Controller
{
    public function Massage(){
        return view('massage',[
            'services' => services::where('salon_id',2)->get(),
            'employees' => employees::where('salon_id',2)
                                    ->where('active',1)
                                    ->get(),
            'step'  => 'service',
            'selectedService' => null,
            'selectedMasseur' => null,
            'selectedDate' => null,
            'selectedTime' => null,
            'times' => [],
            'message' => null,
            'serviceForUser' => null,
            'masseurForUser' => null,
            'priceForUser' => null,
        ]);
    }

    public function MassageBtn(Request $request){
        $step = 'service';
        $times = [];
        $message = null;

        $services = services::where('salon_id',2)->get();
        $employees = employees::where('salon_id',2)
                                    ->where('active',1)
                                    ->get();

        if($request->filled('service_id')){
            $step = 'masseur';
        }

        if($request->filled('service_id') && $request->filled('masseur_id')){
            $step = 'time';
        }

        if($request->filled('service_id') && $request->filled('masseur_id') && $request->filled('date')){
            $shift = shifts::where('employee_id',$request->masseur_id)
                            ->where('shift_date',$request->date)
                            ->first();

            if(!$shift){
                $message = 'A kiválasztott masszőr ezen a napon nem dolgozik!';
            }
            else
            {
                $duration = services::where('service_id',$request->service_id)
                                    ->value('duration');

                $appointments = appointments::where('employee_id',$request->masseur_id)
                                            ->where('appointment_date',$request->date)
                                            ->where('active', 1)
                                            ->get();

                $start = Carbon::parse($request->date . ' ' . $shift->start_time);
                $end = Carbon::parse($request->date . ' ' . $shift->end_time);

                $slot = 30;

                while($start->copy()->addMinutes($duration) <= $end){
                    $isFree = true;

                    foreach($appointments as $appointment){
                        $appStart = Carbon::parse($request->date . ' '. $appointment->start_time);
                        $appEnd = Carbon::parse($request->date . ' '. $appointment->finish_time);

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
            $request->filled('masseur_id') &&
            $request->filled('date') &&
            $request->filled('time'))
        {
            $step = 'submit';
        }

        return view('massage',[
            'services' => $services,
            'employees' => $employees,
            'step' => $step,
            'selectedService' => $request->service_id,
            'serviceForUser' => services::where('service_id',$request->service_id)
                                        ->value('name'),
            'selectedMasseur' => $request->masseur_id,
            'masseurForUser' => employees::where('employee_id',$request->masseur_id)
                                        ->value('name'),
            'priceForUser' => prices::where('employee_id',$request->masseur_id)
                                    ->where('service_id',$request->service_id)
                                    ->value('price'),
            'selectedDate' => $request->date,
            'selectedTime' => $request->time,
            'times' => $times,
            'message' => $message,
            'endForUser' => Carbon::parse($request->date . ' ' . $request->time)
                                    ->addMinutes(services::where('service_id',$request->service_id)->value('duration'))
                                    ->format('H:i')

        ]);
    }

    public function SaveBtn(Request $request){
        $data = new appointments();

        $data->employee_id = $request->masseur_id;
        $data->user_id = Auth::user()->user_id;
        $data->service_id = $request->service_id;
        $data->note = $request->note;
        $data->appointment_date = $request->date;
        $data->start_time = $request->time;
        $duration = services::where('service_id',$request->service_id)
                        ->value('duration');
        $data->finish_time = Carbon::createFromFormat('H:i', $request->time)
                                    ->addMinutes($duration)
                                    ->format('H:i');

        $data->save();

        Mail::to(Auth::user()->email)->send(new ReservationMail($data));
        return redirect('/')->with([
            'success' => "Sikeres időpont foglalás. Kérjük, ellenőrizze a beérkező levelek mappáját."
        ]);
    }
}
