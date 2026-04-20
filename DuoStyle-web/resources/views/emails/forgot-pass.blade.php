<!DOCTYPE html>
<html lang="hu">

<head>
    <meta charset="UTF-8">
    <title>Elfelejtett jelszó</title>
</head>

<body style="margin:0; padding:0; background-color:#f4f6f8;">

    <table width="100%" cellpadding="0" cellspacing="0" style="background-color:#f4f6f8; padding:30px 0;">
        <tr>
            <td align="center">

                <table width="600" cellpadding="0" cellspacing="0"
                    style="background-color:#ffffff; border-radius:8px; padding:30px; font-family:Arial, sans-serif;">

                    <tr>
                        <td style="background:#111111; padding:30px; text-align:center;">
                            <h1 style="margin:0; color:#ffffff; font-size:22px; letter-spacing:1px;"">Jelszó visszaállítás</h1>
                        </td>
                    </tr>

                    <tr>
                        <td style="margin-top:0; font-size:22px; font-weight:600;">
                            <p>Kedves <strong>{{ $user->name }}</strong>!</p>

                            <p>
                                Jelszó-visszaállítást kértek a fiókodhoz.
                                Ha valóban te voltál, az alábbi adatokkal tudod módosítani a jelszavadat.
                            </p>
                        </td>
                    </tr>

                    <tr>
                        <td style="padding:20px 0; text-align:center;">
                            <div
                                style="
                            display:inline-block;
                            background-color:#f0f2f5;
                            border-radius:6px;
                            padding:12px 20px;
                            font-size:22px;
                            letter-spacing:4px;
                            font-weight:bold;
                            color:#111;">
                                {{ $code }}
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align:center; padding:20px 0;">
                            <a href="{{ $resetUrl }}"
                                style="display:inline-block;
                                              background:#111111;
                                              color:#ffffff;
                                              padding:14px 28px;
                                              font-size:14px;
                                              text-decoration:none;
                                              border-radius:4px;">
                                Jelszó módosítása
                            </a>
                        </td>
                    </tr>

                    <p>
                        Fontos: A fenti kód 30 percig érvényes. Ezt követően új jelszó-visszaállítást kell kérned.
                    </p>

                    <tr>
                        <td style="font-size:14px; color:#6c757d; margin-top:40px;">
                            <p>
                                Ha nem te kérted a jelszó visszaállítást,
                                nyugodtan hagyd figyelmen kívül ezt az emailt.
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
