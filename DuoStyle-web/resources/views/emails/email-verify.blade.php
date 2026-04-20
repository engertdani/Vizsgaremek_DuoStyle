<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <title>Sikeres regisztráció</title>
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
                            Kedves {{ $user->name }}!
                        </h2>

                        <p style="font-size:15px; line-height:1.7; margin:20px 0;">
                            Örömmel értesítünk, hogy a regisztrációd sikeresen megtörtént
                            a <strong>DuoStyle</strong> rendszerében.
                        </p>

                        <table width="100%" cellpadding="0" cellspacing="0"
                               style="background:#f8f9fa; border-radius:6px; margin:30px 0;">
                            <tr>
                                <td style="padding:20px; text-align:center;">
                                    <p style="margin:0 0 15px; font-size:16px;">
                                        Kérjük, erősítsd meg e-mail címed:
                                    </p>

                                    <a href="{{ $verifyUrl }}"
                                       style="display:inline-block;
                                              background:#111111;
                                              color:#ffffff;
                                              padding:14px 28px;
                                              font-size:14px;
                                              text-decoration:none;
                                              border-radius:4px;">
                                        Email cím megerősítése
                                    </a>
                                </td>
                            </tr>
                        </table>

                        <p style="font-size:15px; line-height:1.7;">
                            A megerősítés után azonnal használhatod az oldal funkcióit,
                            időpontot foglalhatsz és kezelheted adataidat.
                        </p>

                        <p style="font-size:14px; color:#6c757d; margin-top:40px;">
                            Ha nem te hoztad létre ezt a fiókot, kérjük hagyd figyelmen kívül ezt az emailt.
                        </p>

                        <p style="font-size:14px; margin-top:30px;">
                            Üdvözlettel,<br>
                            <strong>A DuoStyle csapata</strong>
                        </p>

                    </td>
                </tr>

                <tr>
                    <td style="background:#f1f1f1; padding:20px; text-align:center;
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
