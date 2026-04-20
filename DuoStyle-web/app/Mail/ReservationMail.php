<?php

namespace App\Mail;

use Illuminate\Bus\Queueable;
use Illuminate\Contracts\Queue\ShouldQueue;
use Illuminate\Mail\Mailable;
use Illuminate\Mail\Mailables\Content;
use Illuminate\Mail\Mailables\Envelope;
use Illuminate\Queue\SerializesModels;
use App\Models\User;
use App\Models\appointments;
use App\Models\prices;

class ReservationMail extends Mailable
{
    use Queueable, SerializesModels;

    public Appointments $appointments;

    /**
     * Create a new message instance.
     */
    public function __construct(Appointments $appointments)
    {
        $this->appointments = $appointments;
    }

    /**
     * Get the message envelope.
     */
    public function envelope(): Envelope
    {
        return new Envelope(
            subject: 'Sikeres időpontfoglalás',
        );
    }

    /**
     * Get the message content definition.
     */
    public function content(): Content
    {
        $price = prices::where('employee_id', $this->appointments->employee_id)
                ->where('service_id', $this->appointments->service_id)
                ->value('price');
        return new Content(
            view: 'emails.reservation',
            with: [
                'appointment' => $this->appointments,
                'user'  => $this->appointments->user,
                'price' => $price,
            ]
        );
    }

    /**
     * Get the attachments for the message.
     *
     * @return array<int, \Illuminate\Mail\Mailables\Attachment>
     */
    public function attachments(): array
    {
        return [];
    }
}
