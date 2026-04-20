<?php

namespace App\Mail;

use App\Models\User;
use Illuminate\Bus\Queueable;
use Illuminate\Mail\Mailable;
use Illuminate\Mail\Mailables\Content;
use Illuminate\Mail\Mailables\Envelope;
use Illuminate\Queue\SerializesModels;

class ForgotPasswordMail extends Mailable
{
    use Queueable, SerializesModels;

    public User $user;
    public string $token;
    public string $code;

    public function __construct(User $user, string $token, string $code)
    {
        $this->user = $user;
        $this->token = $token;
        $this->code = $code;
    }

    public function envelope(): Envelope
    {
        return new Envelope(
            subject: 'Elfelejtett jelszó'
        );
    }

    public function content(): Content
    {
        return new Content(
            view: 'emails.forgot-pass',
            with: [
                'user' => $this->user,
                'code' => $this->code,
                'resetUrl' => url('/profile/reset-password/'.$this->token),
            ],
        );
    }
}

