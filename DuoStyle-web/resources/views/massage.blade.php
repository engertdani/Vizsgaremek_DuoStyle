@extends('layout')
@section('content')
    <main>
        <div class="container-fluid image-overlay">
            <div class="container text-white">
                <div class="row justify-content-center align-items-center">
                    <div class="col-md-8 strong-overlay my-5">
                        @guest
                            <div class="text-center area my-4">
                                <h1>Foglaljon gyorsan és egyszerűen</h1>
                                <p>A folytatáshoz kérjük, jelentkezzen be.</p>
                                <p>Nincs még fiókja? <a href="/register">Hozza létre most</a></p>
                            </div>
                        @else
                            @if ($step === 'service')
                                <div class="row p-3">
                                    <div class="col-lg-4 bordersty d-flex align-items-center justify-content-center">
                                        <div class="text-center">
                                            <h3>Válasszon szolgáltatást!</h3>
                                            <p>Kérjük válasszon egy szolgáltatást!</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8 p-3">
                                        <h5 class="mb-4 text-center">Válassza ki a szolgáltatást!</h5>

                                        @foreach ($services as $service)
                                            <form method="POST" action="/reservation/massage" class="mb-2">
                                                @csrf
                                                <input type="hidden" name="service_id" value="{{ $service->service_id }}">

                                                <button type="submit" class="btn service-btn w-100">
                                                    {{ $service->name }}
                                                </button>
                                            </form>
                                        @endforeach
                                    </div>
                                </div>
                            @endif
                            @if ($step === 'masseur')
                                <div class="row p-3">
                                    <div class="col-lg-4 bordersty">
                                        <div class="text-center">
                                            <h3>Válasszon masszőrt!</h3>
                                            <p>Kérjük válasszon egy masszőrt!</p>
                                            <p>Szolgáltatás: <strong>{{ $serviceForUser }}</strong></p>
                                        </div>
                                        <form method="POST" action="/reservation/massage"
                                            class="position-absolute bottom-0 start-1 m-2">
                                            @csrf

                                            <button type="submit" class="border-0 bg-transparent fs-3 text-white">
                                                <i class="bi bi-arrow-left-square-fill"></i>
                                            </button>
                                        </form>

                                    </div>
                                    <div class="col-lg-8">
                                        <h5 class="mb-4 text-center">Válassza ki a masszőrét!</h5>
                                        <div class="row">
                                            @foreach ($employees as $employee)
                                                <div class="col-6 col-md-4 mb-3">
                                                    <form method="POST" action="/reservation/massage">
                                                        @csrf
                                                        <input type="hidden" name="service_id" value="{{ $selectedService }}">
                                                        <input type="hidden" name="masseur_id"
                                                            value="{{ $employee->employee_id }}">

                                                        <button type="submit" class="card w-100 text-center p-2">
                                                            <img src="{{ asset('assets/img/' . $employee->img) }}"
                                                                class="img-fluid">
                                                            <strong>{{ $employee->name }}</strong>
                                                        </button>
                                                    </form>
                                                </div>
                                            @endforeach
                                        </div>

                                    </div>
                                </div>
                            @endif

                            @if ($step === 'time')
                                <div class="row p-3">
                                    <div class="col-lg-4 bordersty">
                                        <div class="text-center">
                                            <h3>Válasszon időpontot!</h3>
                                            <p>Kérjük válasszon dátumot és időt!</p>
                                            <p>
                                                Szolgáltatás: <strong>{{ $serviceForUser }}</strong>
                                                <br>
                                                Masszőr: <strong>{{ $masseurForUser }}</strong>
                                                <br>
                                                Ár: <strong>{{ $priceForUser }}</strong> Ft
                                            </p>
                                        </div>
                                        <form method="POST" action="/reservation/massage"
                                            class="position-absolute bottom-0 start-1 m-2">
                                            @csrf
                                            <input type="hidden" name="service_id" value="{{ $selectedService }}">

                                            <button type="submit" class="border-0 bg-transparent fs-3 text-white">
                                                <i class="bi bi-arrow-left-square-fill"></i>
                                            </button>
                                        </form>

                                    </div>
                                    <div class="col-lg-8 p-3">
                                        @if (!empty($message))
                                            <div class="alert alert-danger text-danger py-1 text-center"><i
                                                    class="bi bi-exclamation-triangle-fill"></i>
                                                {{ $message }}
                                            </div>
                                        @endif
                                        <div class="mb-4">
                                            <h5 class="mb-3 text-center">Válasszon ki egy napot!</h5>

                                            <div class="d-flex flex-wrap gap-2 justify-content-center">
                                                <form method="POST" action="/reservation/massage">
                                                    @csrf
                                                    <input type="hidden" name="service_id" value="{{ $selectedService }}">
                                                    <input type="hidden" name="masseur_id" value="{{ $selectedMasseur }}">

                                                    <input type="text" name="date" id="datePicker"
                                                        class="form-control w-100 mx-auto mb-3" placeholder="Válasszon dátumot!"
                                                        value="{{ $selectedDate }}">

                                                    <button type="submit" class="btn btn-outline-light">
                                                        Időpontok megjelenítése
                                                    </button>
                                                </form>
                                            </div>
                                        </div>
                                        @if (!empty($times))
                                            <h5 class="mb-3 text-center">Szabad időpontok</h5>
                                            <form action="/reservation/massage" method="post">
                                                @csrf
                                                <input type="hidden" name="service_id" value="{{ $selectedService }}">
                                                <input type="hidden" name="masseur_id" value="{{ $selectedMasseur }}">
                                                <input type="hidden" name="date" value="{{ $selectedDate }}">
                                                <div class="d-flex flex-wrap gap-2 justify-content-center">
                                                    @foreach ($times as $time)
                                                        <button type="submit" name="time" value="{{ $time }}"
                                                            class="btn btn-outline-light">
                                                            {{ $time }}
                                                        </button>
                                                    @endforeach
                                                </div>
                                            </form>
                                        @endif
                                    </div>
                                </div>
                            @endif

                            @if ($step === 'submit')
                                <form action="/reservation/massage/submit" method="POST">
                                    @csrf
                                    <input type="hidden" name="service_id" value="{{ $selectedService }}">
                                    <input type="hidden" name="masseur_id" value="{{ $selectedMasseur }}">
                                    <input type="hidden" name="date" value="{{ $selectedDate }}">
                                    <input type="hidden" name="time" value="{{ $selectedTime }}">
                                    <div class="row p-3">
                                        <h4 class="text-center mb-4">Foglalás összegzése</h4>
                                        <div class="col-lg-6">
                                            <div class="p-3 area">
                                                <h5 class="mb-3"><i class="bi bi-card-checklist"></i> Részletek</h5>
                                                <p><strong>Szolgáltatás:</strong> {{ $serviceForUser }}</p>
                                                <p><strong>Masszőr:</strong> {{ $masseurForUser }}</p>
                                                <p><strong>Ár:</strong> {{ $priceForUser }} Ft</p>
                                                <p><strong>Dátum:</strong> {{ $selectedDate }}</p>
                                                <p><strong>Időpont:</strong> {{ $selectedTime }} - {{ $endForUser }}</p>

                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="p-3 area">
                                                <h5 class="mb-3"><i class="bi bi-chat-dots-fill"></i> Megjegyzés a masszőrnek
                                                    (opcionális)</h5>
                                                <textarea name="note" id="note" class="form-control" rows="5"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="text-center">
                                        <button type="submit" class="btn loginbtn my-3">Foglalás véglegesítése</button>
                                    </div>
                                </form>
                                <form method="POST" action="/reservation/massage"
                                    class="position-absolute bottom-0 start-0 m-2">
                                    @csrf
                                    <input type="hidden" name="service_id" value="{{ $selectedService }}">
                                    <input type="hidden" name="masseur_id" value="{{ $selectedMasseur }}">
                                    <input type="hidden" name="date" value="{{ $selectedDate }}">

                                    <button type="submit" class="border-0 bg-transparent fs-3 text-white">
                                        <i class="bi bi-arrow-left-square-fill"></i>
                                    </button>
                                </form>
                            @endif
                        @endguest
                    </div>
                </div>
            </div>
        </div>
    </main>
    <script>
        flatpickr("#datePicker", {
            locale: "hu",
            dateFormat: "Y-m-d",
            minDate: new Date().fp_incr(1),
            maxDate: new Date().fp_incr(21),
            disableMobile: true,
            allowInput: false
        });
    </script>

@endsection
