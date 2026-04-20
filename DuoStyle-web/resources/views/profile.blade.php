@extends('layout')
@section('content')
    <div class="container-fluid  profile-bg">
        <div class="container py-3">
            <div class="row">
                <aside class="col-lg-3 my-5">
                    <div class="card profile-sidebar">
                        <div class="card-body p-0">
                            <div class="list-group">
                                <a href="#data" onclick="showSection(event, 'profile')"
                                    class="menu-link list-group-item list-group-item-action active">
                                    Profil adatok ({{ Auth::user()->name }})
                                </a>
                                <a href="#security" onclick="showSection(event, 'security')"
                                    class="menu-link list-group-item list-group-item-action">
                                    Jelszó változtatás
                                </a>
                                <a href="#booking" onclick="showSection(event, 'bookings')"
                                    class="menu-link list-group-item list-group-item-action">
                                    Foglalások
                                </a>
                                <a href="#order" onclick="showSection(event, 'orders')"
                                    class="menu-link list-group-item list-group-item-action">
                                    Vásárlások
                                </a>
                                <a href="/logout" class="list-group-item list-group-item-action">
                                    Kijelentkezés
                                </a>
                                <a href="/delete" class="list-group-item list-group-item-action text-center"
                                    data-bs-toggle="modal" data-bs-target="#deleteModal{{ Auth::user()->user_id }}">
                                    <strong class="text-danger">Fiók törlése</strong>
                                </a>
                                <div class="modal fade" id="deleteModal{{ Auth::user()->user_id }}" tabindex="-1">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title">Fiók törlése</h5>
                                                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                                            </div>

                                            <div class="modal-body">
                                                Biztosan törölni szeretné a fiókját?
                                                <br><br>
                                                Amennyiben fiókját törli, minden foglalása elveszik, továbbá nem tud
                                                bejelentkezni a fiókjába.
                                                <br>
                                                Kérjük, fontolja meg döntését!
                                            </div>

                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">
                                                    Mégse
                                                </button>
                                                <form action="/profile/{{ Auth::user()->user_id }}/delete" method="POST">
                                                    @csrf
                                                    <button type="submit" class="btn btn-danger">
                                                        Igen
                                                    </button>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </aside>

                <main class="col-lg-9 my-5">
                    <div class="card">
                        <div class="card-body">
                            @if (session('fail'))
                                <div class="alert alert-danger text-danger py-1 text-center"><i
                                        class="bi bi-exclamation-triangle-fill"></i> {{ session('fail') }}</div>
                            @elseif (session('success'))
                                <div class="alert alert-success text-success py-1 text-center"><i
                                        class="bi bi-check-circle-fill"></i> {{ session('success') }}</div>
                            @endif
                            <div id="profile-section" class="content-section">
                                <h3 class="mb-4">Profil adatok</h3>
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item d-flex justify-content-between mb-2 bradius">
                                        <span>Név</span>
                                        <strong>{{ Auth::user()->name }}</strong>
                                    </li>
                                    <li class="list-group-item d-flex justify-content-between mb-2 bradius">
                                        <span>Email</span>
                                        <strong>{{ Auth::user()->email }}</strong>
                                    </li>
                                    <li class="list-group-item d-flex justify-content-between mb-2 bradius">
                                        <span>Telefonszám:</span>
                                        <strong>{{ Auth::user()->tel }}</strong>
                                    </li>
                                    <li class="list-group-item d-flex justify-content-between mb-2 bradius">
                                        <span>Születési dátum</span>
                                        <strong>{{ Auth::user()->born_date }}</strong>
                                    </li>
                                    <li class="list-group-item d-flex justify-content-between mb-2 bradius">
                                        <span>Regisztráció dátuma</span>
                                        <strong>{{ Auth::user()->created_at->format('Y-m-d') }}</strong>
                                    </li>
                                    <li class="list-group-item d-flex justify-content-between bradius">
                                        <span>Legutolsó módosítás dátuma</span>
                                        <strong>{{ Auth::user()->updated_at->format('Y-m-d') }}</strong>
                                    </li>
                                </ul>

                                <div class="mt-4 text-end">
                                    <a href={{ '/editprofile/user_id=' . Auth::user()->user_id }} target="_blank"
                                        class="btn btn-outline-primary">
                                        Adatok szerkesztése
                                    </a>
                                </div>
                            </div>

                            <div id="security-section" class="content-section d-none">
                                <h3 class="mb-4">Jelszó változtatás</h3>

                                <form method="POST" action="/profile">
                                    @csrf

                                    <div>
                                        <label class="form-label">Jelenlegi jelszó: <strong
                                                class="text-danger">*</strong></label>
                                        <input type="password" name="opassword" id="opassword" class="form-control inp">
                                    </div>
                                    @error('opassword')
                                        <p class="text-danger">{{ $message }}</p>
                                    @enderror

                                    <label class="form-label mt-3" for="password">
                                        Új jelszó: <strong class="text-danger">*</strong>
                                    </label>
                                    <div class="input-group">
                                        <input class="form-control inp" type="password" name="password" id="password"
                                            maxlength="20">
                                        <span class="input-group-text" onclick="togglePassword('password', 'toggleIcon')">
                                            <i class="bi bi-eye" id="toggleIcon"></i>
                                        </span>
                                    </div>
                                    @error('password')
                                        <p class="text-danger">{{ $message }}</p>
                                    @enderror

                                    <label class="form-label mt-3" for="password_confirmation">
                                        Jelszó újra: <strong class="text-danger">*</strong>
                                    </label>
                                    <div class="input-group">
                                        <input class="form-control inp" type="password" name="password_confirmation"
                                            id="password_confirmation" maxlength="20">
                                        <span class="input-group-text"
                                            onclick="togglePassword('password_confirmation', 'conf_toggleIcon')">
                                            <i class="bi bi-eye" id="conf_toggleIcon"></i>
                                        </span>
                                    </div>

                                    <div class="mt-4 text-end">
                                        <button type="submit" class="btn btn-outline-primary">
                                            Jelszó módosítása
                                        </button>
                                    </div>
                                </form>
                            </div>

                            <div id="bookings-section" class="content-section d-none">
                                <h3 class="mb-4">Foglalások</h3>

                                <ul class="nav nav-underline mb-4" id="bookingTabs">
                                    <li class="nav-item">
                                        <button class="nav-link active" data-bs-toggle="pill" data-bs-target="#active">
                                            Aktív foglalások
                                        </button>
                                    </li>
                                    <li class="nav-item">
                                        <button class="nav-link" data-bs-toggle="pill" data-bs-target="#past">
                                            Eddigi foglalások
                                        </button>
                                    </li>
                                    <li class="nav-item">
                                        <button class="nav-link" data-bs-toggle="pill" data-bs-target="#cancelled">
                                            Lemondott foglalások
                                        </button>
                                    </li>
                                </ul>

                                <div class="tab-content">

                                    <div class="tab-pane fade show active" id="active">
                                        @if ($activeBookings->isEmpty())
                                            <div class="card mb-3 booking-card active-booking">
                                                <div class="card-body d-flex justify-content-between align-items-center">
                                                    <div>
                                                        <h5>Nincsen jelenlegi foglalása!</h5>
                                                        <small><a href="/#reservation">Foglaljon most!</a></small>
                                                    </div>
                                                    <span class="badge bg-warning">!</span>
                                                </div>
                                            </div>
                                        @else
                                            @foreach ($activeBookings as $book)
                                                <div class="card mb-3 booking-card active-booking">
                                                    <div
                                                        class="card-body d-flex justify-content-between align-items-center">
                                                        <div>
                                                            <h5>{{ $book->service->name }} - {{ $book->employee->name }}
                                                            </h5>
                                                            <small>{{ $book->appointment_date }}:
                                                                {{ date_format(date_create($book->start_time), 'H:i') }} -
                                                                {{ date_format(date_create($book->finish_time), 'H:i') }}</small>
                                                        </div>
                                                        <span class="badge bg-danger">
                                                            <button
                                                                class="btn btn-sm text-white p-0 {{ $book->reminder_sent ? 'text-decoration-line-through' : '' }}"
                                                                data-bs-toggle="modal"
                                                                data-bs-target="#cancelModal{{ $book->appointment_id }}"
                                                                {{ $book->reminder_sent ? 'disabled' : '' }}>
                                                                Lemondás
                                                            </button>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="modal fade" id="cancelModal{{ $book->appointment_id }}"
                                                    tabindex="-1">
                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <h5 class="modal-title">Foglalás lemondása</h5>
                                                                <button type="button" class="btn-close"
                                                                    data-bs-dismiss="modal"></button>
                                                            </div>

                                                            <div class="modal-body">
                                                                Biztosan le szeretnéd mondani ezt az időpontot?
                                                                <br><br>
                                                                <strong>{{ $book->service->name }}</strong><br>
                                                                {{ $book->appointment_date }}
                                                                {{ date_format(date_create($book->start_time), 'H:i') }}
                                                            </div>

                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-secondary"
                                                                    data-bs-dismiss="modal">
                                                                    Mégse
                                                                </button>
                                                                <form action="/profile/{{ $book->appointment_id }}/cancel"
                                                                    method="POST">
                                                                    @csrf
                                                                    <button type="submit" class="btn btn-danger">
                                                                        Igen
                                                                    </button>
                                                                </form>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            @endforeach
                                        @endif
                                    </div>

                                    <div class="tab-pane fade" id="past">
                                        @if ($closedBookings->isEmpty())
                                            <div class="card mb-3 booking-card active-booking">
                                                <div class="card-body d-flex justify-content-between align-items-center">
                                                    <div>
                                                        <h5>Nem volt még időpontja!</h5>
                                                        <small><a href="/#reservation">Foglaljon most!</a></small>
                                                    </div>
                                                    <span class="badge bg-warning">!</span>
                                                </div>
                                            </div>
                                        @else
                                            @foreach ($closedBookings as $book)
                                                <div class="card mb-3 booking-card active-booking">
                                                    <div
                                                        class="card-body d-flex justify-content-between align-items-center">
                                                        <div>
                                                            <h5>{{ $book->service->name }} - {{ $book->employee->name }}
                                                            </h5>
                                                            <small>
                                                                {{ $book->appointment_date }}:
                                                                {{ date_format(date_create($book->start_time), 'H:i') }} -
                                                                {{ date_format(date_create($book->finish_time), 'H:i') }}
                                                            </small>
                                                        </div>
                                                        <span class="badge bg-danger">Lejárt</span>
                                                    </div>
                                                </div>
                                            @endforeach
                                        @endif
                                    </div>

                                    <div class="tab-pane fade" id="cancelled">
                                        @if ($cancelledBookings->isEmpty())
                                            <div class="card mb-3 booking-card active-booking">
                                                <div class="card-body d-flex justify-content-between align-items-center">
                                                    <div>
                                                        <h5>Nem mondot még le időpontot!!</h5>
                                                        <small><a href="/#reservation">Foglaljon most!</a></small>
                                                    </div>
                                                    <span class="badge bg-warning">!</span>
                                                </div>
                                            </div>
                                        @else
                                            @foreach ($cancelledBookings as $book)
                                                <div class="card mb-3 booking-card active-booking">
                                                    <div
                                                        class="card-body d-flex justify-content-between align-items-center">
                                                        <div>
                                                            <h5>{{ $book->service->name }} - {{ $book->employee->name }}
                                                            </h5>
                                                            <small>
                                                                {{ $book->appointment_date }}:
                                                                {{ date_format(date_create($book->start_time), 'H:i') }} -
                                                                {{ date_format(date_create($book->finish_time), 'H:i') }}
                                                            </small>
                                                        </div>
                                                        <span class="badge bg-danger">Lemondott</span>
                                                    </div>
                                                </div>
                                            @endforeach
                                        @endif
                                    </div>
                                </div>
                            </div>

                            <div id="orders-section" class="content-section d-none">
                                <h3 class="mb-4">Vásárlások</h3>

                                @if ($orders->isEmpty())
                                    <div class="card mb-3 booking-card active-booking">
                                        <div class="card-body d-flex justify-content-between align-items-center">
                                            <div>
                                                <h5>Nincs még rendelésed!</h5>
                                                <small><a href="/webshop">Nézz körül a shopban</a></small>
                                            </div>
                                            <span class="badge bg-warning">!</span>
                                        </div>
                                    </div>
                                @else
                                    <div class="accordion" id="ordersAccordion">
                                        @foreach ($orders as $order)
                                            <div class="accordion-item mb-2 bradius">
                                                <h2 class="accordion-header" id="heading{{ $order->order_id }}">
                                                    <button class="accordion-button accordionbtn collapsed" type="button"
                                                        data-bs-toggle="collapse"
                                                        data-bs-target="#collapse{{ $order->order_id }}"
                                                        aria-expanded="false"
                                                        aria-controls="collapse{{ $order->order_id }}">

                                                        <div
                                                            class="w-100 d-flex justify-content-between align-items-center">
                                                            <div>
                                                                <strong>Rendelés #{{ $order->order_id }}</strong>
                                                                <div class="text-muted small">
                                                                    {{ $order->ordered_at }}
                                                                </div>
                                                            </div>
                                                            <div class="text-end">
                                                                <div><strong>{{ number_format($order->total_amount, 0, ',', ' ') }}
                                                                        Ft</strong></div>
                                                                <div class="text-muted small">
                                                                    {{ $order->shipping_method }} ·
                                                                    {{ $order->paying_method }}
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </button>
                                                </h2>

                                                <div id="collapse{{ $order->order_id }}"
                                                    class="accordion-collapse collapse"
                                                    aria-labelledby="heading{{ $order->order_id }}"
                                                    data-bs-parent="#ordersAccordion">
                                                    <div class="accordion-body">

                                                        <div class="mb-3">
                                                            <div class="small text-muted">Szállítási cím</div>
                                                            <div>{{ $order->shipping_address }}</div>

                                                            @if (!empty($order->note))
                                                                <div class="small text-muted mt-2">Megjegyzés</div>
                                                                <div>{{ $order->note }}</div>
                                                            @endif

                                                            @if (!empty($order->coupon_code))
                                                                <div class="small text-muted mt-2">Kupon</div>
                                                                <div>{{ $order->coupon_code }}</div>
                                                            @endif
                                                        </div>

                                                        <div class="table-responsive">
                                                            <table class="table align-middle">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Termék</th>
                                                                        <th>Méret</th>
                                                                        <th class="text-center">Mennyiség</th>
                                                                        <th class="text-end">Egységár</th>
                                                                        <th class="text-end">Összesen</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    @foreach ($order->orderProducts as $item)
                                                                        @php
                                                                            $productName =
                                                                                $item->variant?->products?->name ??
                                                                                'Ismeretlen termék';
                                                                            $size = $item->variant?->size ?? '-';
                                                                            $unit = (float) $item->unit_price;
                                                                            $qty = (int) $item->quantity;
                                                                        @endphp
                                                                        <tr>
                                                                            <td>{{ $productName }}</td>
                                                                            <td>{{ $size }}</td>
                                                                            <td class="text-center">{{ $qty }}
                                                                            </td>
                                                                            <td class="text-end">
                                                                                {{ number_format($unit, 0, ',', ' ') }} Ft
                                                                            </td>
                                                                            <td class="text-end">
                                                                                {{ number_format($unit * $qty, 0, ',', ' ') }}
                                                                                Ft</td>
                                                                        </tr>
                                                                    @endforeach
                                                                </tbody>
                                                                <tfoot>
                                                                    <tr>
                                                                        <th colspan="4" class="text-end">Végösszeg</th>
                                                                        <th class="text-end">
                                                                            {{ number_format($order->total_amount, 0, ',', ' ') }}
                                                                            Ft</th>
                                                                    </tr>
                                                                </tfoot>
                                                            </table>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        @endforeach
                                    </div>
                                @endif
                            </div>

                        </div>
                    </div>
                </main>

            </div>
        </div>
    </div>
    <script>
        function showSection(event, section) {

            event.preventDefault();

            document.querySelectorAll('.content-section').forEach(el => {
                el.classList.add('d-none');
            });

            document.getElementById(section + '-section').classList.remove('d-none');

            document.querySelectorAll('.menu-link').forEach(el => {
                el.classList.remove('active');
            });

            event.currentTarget.classList.add('active');
        }
    </script>
@endsection
