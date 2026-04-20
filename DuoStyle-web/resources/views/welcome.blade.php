@extends('layout')
@section('content')
    <main>
        <div class="container-fluid image-overlay" id="home">
            <div class="container text-white">

                {{-- Cím --}}
                <div class="row mb-4 p-1">
                    <div class="col text-center mt-4">
                        <h1>Üdvözöljük a DuoStyle Szalonban!</h1>
                    </div>
                </div>

                @if (session('success'))
                    <div class="alert alert-success text-success py-1 text-center"><i class="bi bi-check-circle-fill"></i>  {{ session('success') }}</div>
                @endif

                {{-- Átlagos értékelés --}}
                <div class="row strong-overlay w-50 m-auto d-flex align-items-center jsutify-content-center">
                    <div class="col text-center p-3">
                        @if ($avgStars > 0)
                            <div class="mb-2">
                                @for ($i = 0; $i < $roundedStars; $i++)
                                    <i class="bi bi-star-fill text-warning me-2"></i>
                                @endfor
                            </div>
                            <p class="mb-2">{{ number_format($avgStars, 1) }} / 5 Google értékelések alapján</p>
                        @else
                            <div class="mb-2">
                                @for ($i=0; $i < 5; $i++)
                                    <i class="bi bi-star me-2"></i>
                                @endfor
                            </div>
                            <p class="mb-2">Nincsenek még értékelések.</p>
                        @endif
                        @auth
                            <p class="mb-0">Szeretne értékelést írni? <a href="/write_evaluation">Itt megteheti!</a></p>
                        @else
                            <p class="mb-0">A vélemény íráshoz jelentkezzen be!</p>
                        @endauth
                    </div>
                </div>

                {{-- Szolgáltatások --}}
                <div class="row mt-5" id="reservation">
                    <div class="col-md-6 margin">
                        <div class="card w-100">
                            <img src="{{ asset('assets/img/salon_barber.png') }}" class="card-img-top" alt="">
                            <div class="card-body text-center">
                                <h5 class="card-title">DuoStyle - Barber</h5>
                                <p class="card-text">
                                    Férfi fodrászatunk a legújabb trendeknek megfelelő hajvágásokat,
                                    szakállformázást és borotválást kínál, hogy ügyfeleink stílusosak és
                                    magabiztosak legyenek.
                                </p>
                                <a href="/reservation/barber" class="btn reserv-btn">Időpontfoglalás</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="card w-100">
                            <img src="{{ asset('assets/img/salon_massage.png') }}" class="card-img-top" alt="">
                            <div class="card-body text-center">
                                <h5 class="card-title">DuoStyle - Masszázsszalon</h5>
                                <p class="card-text">
                                    Masszázsszalonunkban különféle masszázsokat kínálunk, amelyek
                                    segítenek ellazulni, csökkenteni a stresszt és felfrissíteni a testet és
                                    lelket.
                                </p>
                                <a href="/reservation/massage" class="btn reserv-btn">Időpontfoglalás</a>
                            </div>
                        </div>
                    </div>
                </div>

                {{-- Legutolsó értékelések --}}
                <div class="row mt-5">
                    <h3 class="text-center ev-title">Legutolsó értékeléseink</h3>
                    {{-- Ha nincs még értékelés, akkor szöveg jelenik meg --}}
                    @if ($lastEvaluations->isEmpty())
                        <div class="col-md-6 mx-auto mb-4">
                            <div class="text-center strong-overlay text-white p-3">
                            <p class="mb-0">HOPPÁ! Nincsenek még értékelések.</p>
                        </div>
                        </div>
                    @else
                        {{-- Ha vannak értékelések, akkor megjelennek, igazodó gridekkel --}}
                        @foreach ($lastEvaluations as $evaluation)
                            <div class="col-md-4 mb-4">
                                <div class="strong-overlay text-white p-3">
                                    <div>
                                        {{ $evaluation->user->name }} -
                                        {{ date_format(date_create($evaluation->evaluation_date),'Y.m.d.') }}
                                    </div>
                                    <div>
                                        @for ($i = 0; $i < $evaluation->star; $i++)
                                            <i class="bi bi-star-fill text-warning"></i>
                                        @endfor
                                    </div>
                                    <div>
                                        {{ $evaluation->evaluation_text }}
                                    </div>
                                </div>
                            </div>
                        @endforeach
                    @endif
                </div>

            </div>
        </div>
    </main>
@endsection
