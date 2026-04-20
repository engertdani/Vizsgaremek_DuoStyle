<!DOCTYPE html>
<html lang="hu">

<head>
    <meta charset="UTF-8">
    <title>Rendelés visszaigazolás</title>
</head>

<body style="margin:0; padding:0; background-color:#f4f4f4; font-family:Arial, Helvetica, sans-serif;">

    <table width="100%" cellpadding="0" cellspacing="0" style="padding:40px 0;">
        <tr>
            <td align="center">

                <table width="600" cellpadding="0" cellspacing="0"
                    style="background:#ffffff; border-radius:8px; overflow:hidden;
                          box-shadow:0 6px 20px rgba(0,0,0,0.08);">

                    <tr>
                        <td style="background:#111111; padding:30px; text-align:center;">
                            <h1 style="margin:0; color:#ffffff; font-size:22px; letter-spacing:1px;">
                                DuoStyle
                            </h1>
                        </td>
                    </tr>

                    <tr>
                        <td style="padding:40px; color:#333333;">

                            <h2 style="margin-top:0; font-size:22px; font-weight:600;">
                                Kedves {{ optional($order->user)->name }}!
                            </h2>

                            <p style="font-size:15px; line-height:1.7; margin:20px 0;">
                                Köszönjük a rendelésed! Az alábbi termékeket rögzítettük:
                            </p>

                            <table width="100%" cellpadding="0" cellspacing="0"
                                style="border-collapse:collapse; margin:20px 0;">

                                <tr>
                                    <th align="left"
                                        style="padding:12px; background:#f1f1f1; font-size:13px; border:1px solid #e6e6e6;">
                                        Termék
                                    </th>
                                    <th align="center"
                                        style="padding:12px; background:#f1f1f1; font-size:13px; border:1px solid #e6e6e6;">
                                        Mennyiség
                                    </th>
                                    <th align="right"
                                        style="padding:12px; background:#f1f1f1; font-size:13px; border:1px solid #e6e6e6;">
                                        Egységár
                                    </th>
                                    <th align="right"
                                        style="padding:12px; background:#f1f1f1; font-size:13px; border:1px solid #e6e6e6;">
                                        Részösszeg
                                    </th>
                                </tr>

                                @foreach ($items as $item)
                                    <tr>
                                        <td style="padding:12px; border:1px solid #e6e6e6; font-size:14px;">
                                            <strong>{{ $item['product_name'] }}</strong><br>
                                            <span style="color:#6c757d; font-size:12px;">
                                                Méret: {{ $item['size'] }}
                                            </span>
                                        </td>

                                        <td align="center"
                                            style="padding:12px; border:1px solid #e6e6e6; font-size:14px;">
                                            {{ $item['quantity'] }} db
                                        </td>

                                        <td align="right"
                                            style="padding:12px; border:1px solid #e6e6e6; font-size:14px;">
                                            {{ number_format($item['price'], 0, ',', ' ') }} Ft
                                        </td>

                                        <td align="right"
                                            style="padding:12px; border:1px solid #e6e6e6; font-size:14px;">
                                            {{ number_format($item['subtotal'], 0, ',', ' ') }} Ft
                                        </td>
                                    </tr>
                                @endforeach
                            </table>

                            <table width="100%" cellpadding="0" cellspacing="0"
                                style="background:#f8f9fa; border-radius:6px; margin:25px 0;">
                                <tr>
                                    <td style="padding:18px; font-size:14px; line-height:1.7;">
                                        <div><strong>Rendelés azonosító:</strong> #{{ $order->order_id }}</div>
                                        <div><strong>Szállítási cím:</strong> {{ $order->shipping_address }}</div>
                                        <div><strong>Szállítási mód:</strong> {{ $order->shipping_method }}</div>
                                        <div><strong>Fizetési mód:</strong> {{ $order->paying_method }}</div>

                                        @if (!empty($order->coupon_code))
                                            <div><strong>Kupon:</strong> {{ $order->coupon_code }}</div>
                                        @else
                                            <div><strong>Kupon:</strong> Ön nem használt kupont.</div>
                                        @endif
                                        @if (!empty($order->note))
                                            <div><strong>Megjegyzés:</strong> {{ $order->note }}</div>
                                        @endif
                                    </td>
                                </tr>
                            </table>

                            <p style="font-size:16px; margin:0; text-align:right;">
                                <strong>Végösszeg: {{ number_format($order->total_amount ?? $total, 0, ',', ' ') }}
                                    Ft</strong>
                            </p>

                            <p style="font-size:14px; color:#6c757d; margin-top:30px;">
                                Ha kérdésed van, válaszolj erre az emailre.
                            </p>

                            <p style="font-size:14px; margin-top:25px;">
                                Üdvözlettel,<br>
                                <strong>A DuoStyle csapata</strong>
                            </p>

                        </td>
                    </tr>

                    <tr>
                        <td
                            style="background:#f1f1f1; padding:20px; text-align:center;
                               font-size:12px; color:#888888;">
                            © {{ date('Y') }} DuoStyle Szalon · Minden jog fenntartva
                        </td>
                    </tr>

                </table>

            </td>
        </tr>
    </table>

</body>

</html>
