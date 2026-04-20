<!DOCTYPE html>
<html lang="hu">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>DuoStyle Szalon</title>
    {{-- Linkek meghívása --}}
    <link rel="stylesheet" href="{{ asset('assets/css/bootstrap.css') }}">
    <link rel="stylesheet" href="{{ asset('assets/css/layout.css') }}">
    <link rel="stylesheet" href="{{ asset('assets/css/welcome.css') }}">
    <link rel="stylesheet" href="{{ asset('assets/css/register.css') }}">
    <link rel="stylesheet" href="{{ asset('assets/css/barber.css') }}">
    <link rel="stylesheet" href="{{ asset('assets/css/profile.css') }}">
    @stack('employee-css')
    @stack('webshop-css')
    @stack('details-css')
    <link rel="stylesheet" href="{{ asset('assets/fontawesome/css/all.css') }}">
    <script src="{{ asset('assets/js/bootstrap.bundle.js') }}"></script>
    <link rel="icon" type="image/x-icon" href="{{ asset('assets/img/logo.png') }}">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css">
    <script src="{{ asset('assets/js/password.js') }}"></script>
    <script src="{{ asset('assets/js/timer.js') }}"></script>
    <script src="{{ asset('assets/js/register.js') }}" defer></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.css">
    <script src="https://cdn.jsdelivr.net/npm/flatpickr"></script>
    <script src="https://cdn.jsdelivr.net/npm/flatpickr/dist/l10n/hu.js"></script>

</head>

<body data-bs-spy="scroll" data-bs-target=".navbar" data-bs-offset="100" tabindex="0">

    {{-- Navigációs sáv --}}
    <nav class="navbar navbar-expand-md p-3 sticky-top">
        <div class="container-fluid">
            <a class="navbar-brand me-auto" href="/"><img src="{{ asset('assets/img/logo.png') }}" alt="logo.png"
                    title="DuoSytle logó"></a>
            <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasNavbar"
                aria-labelledby="offcanvasNavbarLabel">
                <div class="offcanvas-header">
                    <h5 class="offcanvas-title" id="offcanvasNavbarLabel"><a href="/"><img
                                src="{{ asset('assets/img/logo.png') }}" alt="{{ asset('assets/img/logo.png') }}"></a>
                    </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                </div>
                <div class="offcanvas-body">
                    <ul class="navbar-nav justify-content-center flex-grow-1 pe-3">
                        <li class="nav-item">
                            <a class="nav-link mx-lg-2" href="/#home">Főoldal</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link mx-lg-2" href="/#reservation">Időpontfoglalás</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link mx-lg-2" href="#about">Rólunk</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link mx-lg-2 {{ request()->is('our_employees') ? 'active' : '' }}"
                                href="/our_employees">
                                Munkatársaink
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link mx-lg-2 {{ request()->is('webshop') ? 'active' : '' }}" href="/webshop">Webshopunk</a>
                        </li>
                    </ul>
                </div>
            </div>
            {{-- Bejelentkezés/Profil gomb --}}
            @guest
                <div class="dropdown">
                    <button class="btn login-button dropdown-toggle" type="button" data-bs-toggle="dropdown"
                        aria-expanded="false" id="loginDropdownButton">
                        Bejelentkezés
                    </button>

                    <div class="dropdown-menu dropdown-menu-end d-menu text-white p-4 mobile-login">
                        <form method="POST" action="/login">
                            @csrf

                            <input type="hidden" name="redirect_to" value="{{ url()->current() }}">

                            {{-- Sikertelen bejelentkezés esetén hibaüzenet --}}
                            @if (session('fail'))
                                <div class="alert alert-danger text-danger py-1 text-center"><i
                                        class="bi bi-exclamation-triangle-fill"></i> {{ session('fail') }}</div>
                            @endif

                            <div class="mb-3">
                                <label for="email" class="form-label">E-mail:</label>
                                <input type="text" class="form-control inp" id="email" name="email" required>
                            </div>

                            <div class="mb-1">
                                <label for="password" class="form-label">Jelszó:</label>
                                <input type="password" class="form-control inp" id="password" name="password" required>
                            </div>

                            <button type="submit" class="btn btn-primary w-100 mt-2">
                                Bejelentkezés
                            </button>

                            <div class="mt-2">
                                <p>
                                    Nincs még fiókod? <a href="/register">Regisztrálj!</a>
                                    <br>
                                    <a href="/forgot-password">Elfelejtetted a jelszavad?</a>
                                </p>
                            </div>

                        </form>
                    </div>
                </div>
            @else
                <a href="/webshop/addcart"><i class="bi bi-cart2 text-white p-3"></i></a>
                <div class="dropdown">
                    <button class="btn login-button dropdown-toggle" type="button" data-bs-toggle="dropdown"
                        aria-expanded="false">
                        {{ Auth::user()->name }}
                        <div id="session-timer">
                            (15:00)
                        </div>
                    </button>

                    <ul class="dropdown-menu d-menu">
                        <li><a class="dropdown-item d-item" href="/profile">Saját profil</a></li>
                        <li><a class="dropdown-item d-item" href="/logout">Kijelentkezés</a></li>
                    </ul>
                </div>
            @endguest
            <button class="navbar-toggler" type="button" data-bs-toggle="offcanvas"
                data-bs-target="#offcanvasNavbar" aria-controls="offcanvasNavbar">
                <span class="navbar-toggler-icon"></span>
            </button>
        </div>
    </nav>

    {{-- Tartalom --}}
    @yield('content')

    {{-- Lábléc --}}
    <footer>
        <div class="container my-4">
            <div class="row">

                {{-- Rólunk kártya --}}
                <div class="col-md-3" id="card1">
                    <div class="card w-100" id="about">
                        <div class="card-body">
                            <h5 class="card-title mb-3">Rólunk</h5>
                            <p class="card-text">
                                A <strong>DuoStyle Szalon</strong> egy modern szépség- és wellnessközpont, ahol két
                                külon világ találkozik: a professzionális <strong>barber</strong> üzlet és a pihentető
                                <strong>masszázsszalon</strong>.
                            </p>
                            <p class="card-text">
                                Célunk, hogy vendégeink egyszerre érezzék magukat stílusosnak és feltöltődöttnek.
                                2026-ban nyitottuk meg kapuinkat, ahol a minőség, az igényesség és a vendégközpontú
                                élmény áll a középpontban.
                            </p>
                            <div class="card-text">
                                <h6 class="text-center">"Stílus. Erő. Megújulás."</h6>
                            </div>
                        </div>
                    </div>
                </div>

                {{-- Szalonok adatainak megjelenítése --}}
                @foreach ($salons as $salon)
                    <div class="col-md-3 card2">
                        <div class="card w-100">
                            <div class="card-body">
                                <div class="card-title mb-3"><img class="w-100"
                                        src="{{ asset('assets/img/' . $salon->img) }}" alt="{{ $salon->img }}"
                                        title="{{ $salon->name }}"></div>
                                <div class="card-text">
                                    <h5 class="text-center">{{ $salon->name }}</h5>
                                </div>
                                <p class="card-text">
                                    <strong>Nyitvatartás:</strong>
                                    <br>
                                    Hétfő - Vasárnap: {{ $salon->open_time }} - {{ $salon->close_time }}
                                </p>
                                <div class="card-text">
                                    <div><i class="bi bi-geo-alt"></i> {{ $salon->location }}</div>
                                    <div class="div"><i class="bi bi-telephone"></i> <a
                                            href="tel:{{ $salon->tel }}">{{ $salon->tel }}</a></div>
                                    <div><i class="bi bi-envelope"></i> <a
                                            href="mailto:{{ $salon->email }}">{{ $salon->email }}</a></div>
                                </div>
                            </div>
                        </div>
                    </div>
                @endforeach

                {{-- Közösségi média kártya --}}
                <div class="col-md-3" id="card3">
                    <div class="card w-100">
                        <div class="card-body">
                            <h5 class="card-title mb-3">Kövess minket!</h5>
                            <p class="card-text">
                                <a href="http://www.facebook.com/randomuser" target="_blank"><i
                                        class="bi bi-facebook me-3 fs-2"></i></a>
                                <a href="https://www.instagram.com/duostyleszalon/" target="_blank"><i
                                        class="bi bi-instagram fs-2"></i></a>
                            </p>
                            <hr>
                            @guest
                                <h6 class="mb-3"><a href="/our_employees/name={{ $employees->name }}">Ismerd meg</a>,
                                    egyik @if ($employees->salon_id == 1)
                                        borbélyunkat
                                    @else
                                        masszőrünket
                                    @endif
                                </h6>
                                <figure>
                                    <img class="w-100" src="{{ asset('assets/img/' . $employees->img) }}"
                                        alt="{{ $employees->img }}" title="{{ $employees->name }}">
                                    <figcaption class="text-center mt-2 fw-bold">{{ $employees->name }}-t !</figcaption>
                                </figure>
                            @else
                                <h6 class="mb-3"><a href="/our_employees/name={{ $login_employee->name }}">Ismerd meg</a>,
                                    egyik @if ($login_employee->salon_id == 1)
                                        borbélyunkat
                                    @else
                                        masszőrünket
                                    @endif
                                </h6>
                                <figure>
                                    <img class="w-100" src="{{ asset('assets/img/' . $login_employee->img) }}"
                                        alt="{{ $login_employee->img }}" title="{{ $login_employee->name }}">
                                    <figcaption class="text-center mt-2 fw-bold">{{ $login_employee->name }}-t !
                                    </figcaption>
                                </figure>
                            @endguest
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <hr>

        {{-- Jognyilatkozatok --}}
        <div class="p-3">
            <p class="text-center">
                {{ date('Y') }} © <strong>DuoStyle Szalon</strong>. Minden jog fenntartva.
            </p>
            <p class="text-center">
                <a class="text-decoration-none" href="/documents/adatvedelmi">Adatvédelmi nyilatkozat.</a> <br>
                <a class="text-decoration-none" href="/documents/aszf">ÁSZF.</a>
            </p>
        </div>

    </footer>
    <script>
        document.addEventListener("DOMContentLoaded", function() {
            @if (session('openLogin'))
                let btn = document.getElementById('loginDropdownButton');
                if (btn) {
                    let dropdown = new bootstrap.Dropdown(btn);
                    dropdown.show();
                }
            @endif
        });
    </script>
</body>

</html>
