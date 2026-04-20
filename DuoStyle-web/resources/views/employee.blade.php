@extends('layout')
@push('employee-css')
    <link rel="stylesheet" href="{{ asset('assets/css/employee.css') }}">
@endpush
@section('content')
    <main class="employee-main">
        <div class="employee-header text-center">
            <h1>Munkatársaink</h1>
            <div class="divider"></div>
            <p>Válaszd ki a számodra megfelelő szakembert</p>
        </div>
        <div class="container employee-con py-5">
            <h2 class="text-center mb-4 text-white">Barberek</h2>
            <div class="row g-3 justify-content-center">
                @foreach ($employees as $employee)
                    @if ($employee->salon_id == 1)
                        <div class="col-md-4 d-flex justify-content-center">
                            <div class="card" style="width: 18rem;">
                                <img src="{{ asset('assets/img/' . $employee->img) }}" class="card-img-top w-100"
                                    alt="{{ $employee->name }}" title="{{ $employee->name }}">

                                <div class="card-body">
                                    <h5 class="card-title">{{ $employee->name }}</h5>
                                    <hr>

                                    <p class="card-text">{{ $employee->description }}</p>

                                    <hr>

                                    <a href="/our_employees/name={{ $employee->name }}" class="btn login-button">
                                        Rólam (áraim)
                                    </a>
                                </div>
                            </div>
                        </div>
                    @endif
                @endforeach
            </div>

            <div class="my-5 text-white">
                <hr>
            </div>

            <h2 class="text-center mb-4 text-white">Masszőrök</h2>
            <div class="row g-3 justify-content-center">
                @foreach ($employees as $employee)
                    @if ($employee->salon_id != 1)
                        <div class="col-md-4 d-flex justify-content-center">
                            <div class="card" style="width: 18rem;">
                                <img src="{{ asset('assets/img/' . $employee->img) }}" class="card-img-top img-fluid"
                                    alt="{{ $employee->name }}" title="{{ $employee->name }}">

                                <div class="card-body">
                                    <h5 class="card-title">{{ $employee->name }}</h5>
                                    <hr>

                                    <p class="card-text">{{ $employee->description }}</p>

                                    <hr>

                                    <a href="/our_employees/name={{ $employee->name }}" class="btn login-button">
                                        Rólam (áraim)
                                    </a>
                                </div>
                            </div>
                        </div>
                    @endif
                @endforeach
            </div>
        </div>
    </main>
@endsection
