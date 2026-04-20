<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>DuoStyle Szalon</title>
    <link rel="stylesheet" href="{{ asset('assets/css/bootstrap.css') }}">
    <script src="{{ asset('assets/js/bootstrap.bundle.js') }}"></script>
</head>
<body class="bg-light">
    <div class="container vh-100 d-flex align-items-center justify-content-center">
        <div class="card shadow-lg p-4 text-center" style="max-width: 500px; width: 100%;">
            <img
                src="{{ asset('assets/img/logo.png') }}"
                alt="DuoStyle logó"
                title="DuoStyle logó"
                class="img-fluid mb-4 mx-auto"
                style="max-height: 120px;">

            <h1 class="h4 mb-3">
                🎉 Sikeresen megerősítette az e-mail címét!
            </h1>

            <p class="text-muted mb-0">
                Most már bejelentkezhet, nyugodtan bezárhatja ezt az oldalt.
            </p>

        </div>
    </div>
</body>

</html>
