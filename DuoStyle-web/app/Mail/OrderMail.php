<?php

namespace App\Mail;

use App\Models\Order;
use Illuminate\Bus\Queueable;
use Illuminate\Mail\Mailable;
use Illuminate\Mail\Mailables\Content;
use Illuminate\Mail\Mailables\Envelope;
use Illuminate\Queue\SerializesModels;

class OrderMail extends Mailable
{
    use Queueable, SerializesModels;

    public Order $order;
    public array $items;
    public float|int $total;
    /**
     * Create a new message instance.
     */
    public function __construct(Order $order, array $items, float|int $total)
    {
        $this->order = $order;
        $this->items = $items;
        $this->total = $total;
    }
    /**
     * Get the message envelope.
     */
    public function envelope(): Envelope
    {
        return new Envelope(
            subject: 'Rendelés visszaigazolás #' . $this->order->order_id
        );
    }
    /**
     * Get the message content definition.
     */
    public function content(): Content
    {
        return new Content(
            view: 'emails.email-order-confirmation',
            with: [
                'order' => $this->order,
                'items' => $this->items,
                'total' => $this->total,
            ],
        );
    }
    /**
     * Get the attachments for the message.
     */
    public function attachments(): array
    {
        return [];
    }
}
