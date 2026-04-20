<!DOCTYPE html>
<html lang="hu">

<head>
    <meta charset="UTF-8">
    <title>Sikeres időpontfoglalás</title>
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
                                Kedves {{ $appointment->user->name }}!
                            </h2>

                            <p style="font-size:15px; line-height:1.7; margin:20px 0;">
                                Örömmel értesítünk, hogy az időpontfoglalásod sikeresen megtörtént
                                a <strong>DuoStyle</strong> rendszerében.
                            </p>

                            <table width="100%" cellpadding="0" cellspacing="0"
                                style="background:#f8f9fa; border-radius:6px; margin:30px 0;">
                                <tr>
                                    <td style="padding:25px;">

                                        <p style="margin:0 0 20px; font-size:16px; text-align:center;">
                                            <strong>A foglalás adatai:</strong>
                                        </p>

                                        <table width="100%" cellpadding="0" cellspacing="0" style="font-size:14px;">
                                            <tr>
                                                <td style="padding:8px 0; color:#555;">📅 Dátum:</td>
                                                <td style="padding:8px 0; text-align:right;">
                                                    {{ $appointment->appointment_date }}
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="padding:8px 0; color:#555;">⏰ Kezdés:</td>
                                                <td style="padding:8px 0; text-align:right;">
                                                    {{ $appointment->start_time }}
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="padding:8px 0; color:#555;">⏱️ Befejezés:</td>
                                                <td style="padding:8px 0; text-align:right;">
                                                    {{ $appointment->finish_time }}
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="padding:8px 0; color:#555;">💇 Szolgáltatás:</td>
                                                <td style="padding:8px 0; text-align:right;">
                                                    {{ $appointment->service->name ?? '-' }}
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="padding:8px 0; color:#555;">✂️ Alkalmazott::</td>
                                                <td style="padding:8px 0; text-align:right;">
                                                    {{ $appointment->employee->name ?? '-' }}
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="padding:8px 0; color:#555;">💰 Ár:</td>
                                                <td style="padding:8px 0; text-align:right;">
                                                    @if (!is_null($price))
                                                        {{ number_format($price, 0, ',', ' ') }} Ft
                                                    @else
                                                        -
                                                    @endif
                                                </td>
                                            </tr>

                                            @if ($appointment->note)
                                                <tr>
                                                    <td style="padding:8px 0; color:#555;">📝 Megjegyzés:</td>
                                                    <td style="padding:8px 0; text-align:right;">
                                                        {{ $appointment->note }}
                                                    </td>
                                                </tr>
                                            @endif
                                        </table>

                                    </td>
                                </tr>
                            </table>

                            <p style="font-size:15px; line-height:1.7;">
                                Az időpont előtt, 24 órával ingyenesen lemondhatja a profiljában az időpontot,
                                amennyiben lemondás ellenére nem jelenik meg a fent jelzett időpontban, következő
                                szolgáltatáshoz 50%-ot fogunk felszámolni!
                            </p>

                            <p style="font-size:14px; color:#6c757d; margin-top:40px;">
                                Ha nem te hoztad létre a foglalást, kérjük hagyd figyelmen kívül ezt az emailt.
                            </p>

                            <p style="font-size:14px; margin-top:30px;">
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
