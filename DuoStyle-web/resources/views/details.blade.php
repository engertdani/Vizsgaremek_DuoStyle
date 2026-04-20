@extends('layout')
@push('details-css')
    <link rel="stylesheet" href="{{ asset('assets/css/details.css') }}">
@endpush
@section('content')
    <main>
        <div class="container py-3">
            <div class="row justify-content-center">
                <div class="col-lg-8">
                    <div class="card shadow-lg border-0">
                        <div class="row g-0 rw">

                            <div class="col-md-4">
                                <img src="{{ asset('assets/img/' . $employee->img) }}" class="w-100 h-100 object-fit-cover rounded-start"
                                    alt="{{ asset('assets/img/' . $employee->img) }}" title="{{ $employee->name }}">
                            </div>

                            <div class="col-md-8">
                                <div class="card-body">

                                    <h2 class="card-title mb-3 str">
                                        {{ $employee->name }}
                                    </h2>

                                    <p class="mb-2">
                                        {{ $employee->salon_id == 1 ? 'Barber' : 'Masszőr' }}
                                    </p>

                                    <p class="card-text">
                                        {{ $employee->description }}
                                    </p>

                                    <hr>

                                    <p>
                                        <strong class="str">Kedvenc márka:</strong>
                                        {{ $employee->fav_brand }}
                                    </p>

                                    <p>
                                        <strong class="str">Csatlakozott:</strong>
                                        {{ $employee->join_date }}
                                    </p>



                                    <a href="/our_employees" class="btn btn-outline-secondary">
                                        Vissza
                                    </a>

                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="card shadow-sm border-0 mt-4">
                        <div class="card-body rw">
                            <div class="d-flex align-items-center justify-content-between">
                                <h4 class="mb-0">Árak</h4>
                                <span class="small">{{ $prices->count() }} szolgáltatás</span>
                            </div>

                            <div class="list-group list-group-flush mt-3">
                                @forelse($prices as $p)
                                    <div class="list-group-item d-flex justify-content-between align-items-center py-3">
                                        <div class="fw-semibold">{{ $p->service_name }}</div>
                                        <span class="badge bg-dark rounded-pill fs-6 text-white">
                                            {{ number_format($p->price, 0, ',', ' ') }} Ft
                                        </span>
                                    </div>
                                @empty
                                    <div class="py-3">Nincs ár feltöltve ehhez a kollégához.</div>
                                @endforelse
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        </div>
    </main>
@endsection
