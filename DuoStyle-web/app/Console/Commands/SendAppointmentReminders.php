<?php

namespace App\Console\Commands;

use Illuminate\Console\Command;
use Carbon\Carbon;
use App\Models\appointments;
use Illuminate\Support\Facades\Mail;
use App\Mail\AppointmentReminderMail;

class SendAppointmentReminders extends Command
{
    /**
     * The name and signature of the console command.
     *
     * @var string
     */
    protected $signature = 'app:send-appointment-reminders';

    /**
     * The console command description.
     *
     * @var string
     */
    protected $description = 'Command description';

    /**
     * Execute the console command.
     */
    public function handle()
    {
        $now = Carbon::now();
        $target = $now->copy()->addHours(24);

        $appointments = appointments::where('reminder_sent', false)
            ->whereBetween('appointment_date', [
                $target->toDateString(),
                $target->toDateString()
            ])
            ->get();

        foreach ($appointments as $appointment) {

            $start = Carbon::parse(
                $appointment->appointment_date . ' ' . $appointment->start_time
            );

            if ($start->diffInMinutes($now) <= 1440) {

                Mail::to($appointment->user->email)
                    ->send(new AppointmentReminderMail($appointment));

                $appointment->update([
                    'reminder_sent' => true
                ]);
            }
        }
    }
}
