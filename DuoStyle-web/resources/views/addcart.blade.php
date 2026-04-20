@extends('layout')
@push('webshop-css')
<link rel="stylesheet" href="{{ asset('assets/css/webshop.css') }}">
@endpush
@section('content')
    <main>
        @auth
            <div class="container py-4">
                <div class="row">
                    <div class="col-12">
                        <h1 class="webshop-title mb-4"><i class="fas fa-shopping-cart me-2"></i>Kosár</h1>

                        @if (session('success'))
                            <div class="alert alert-success alert-dismissible fade show" role="alert">
                                {{ session('success') }}
                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            </div>
                        @endif

                        @if (session('error'))
                            <div class="alert alert-danger alert-dismissible fade show" role="alert">
                                {{ session('error') }}
                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            </div>
                        @endif

                        @if (empty($cartItems))
                            <div class="card webshop-card">
                                <div class="card-body text-center py-5">
                                    <i class="fas fa-shopping-cart fa-3x text-muted mb-3"></i>
                                    <h3 class="webshop-card-title mb-3">A kosarad üres</h3>
                                    <p class="webshop-card-text mb-4">Még nem adtál hozzá termékeket a kosaradhoz.</p>
                                    <a href="/webshop" class="btn btn-primary webshop-card-btn-cart">
                                        <i class="fas fa-store me-2"></i>Tovább a vásárláshoz
                                    </a>
                                </div>
                            </div>
                        @else
                            <div class="row">
                                <div class="col-lg-8">
                                    <div class="card webshop-card mb-4">
                                        <div class="card-body">
                                            <div class="table-responsive">
                                                <table class="table table-borderless webshop-cart-table">
                                                    <thead>
                                                        <tr>
                                                            <th scope="col" class="webshop-cart-th">Termék</th>
                                                            <th scope="col" class="webshop-cart-th">Méret</th>
                                                            <th scope="col" class="webshop-cart-th">Ár</th>
                                                            <th scope="col" class="webshop-cart-th">Mennyiség</th>
                                                            <th scope="col" class="webshop-cart-th">Összesen</th>
                                                            <th scope="col" class="webshop-cart-th"></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        @foreach ($cartItems as $item)
                                                            <tr class="webshop-cart-tr">
                                                                <td>
                                                                    <div class="d-flex align-items-center">
                                                                        <img src="{{ $item['image'] }}"
                                                                            alt="{{ $item['product_name'] }}"
                                                                            class="webshop-cart-img me-3">
                                                                        <div>
                                                                            <h6 class="webshop-cart-product-title mb-0">
                                                                                {{ $item['product_name'] }}</h6>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td class="align-middle">
                                                                    <span class="webshop-cart-size">{{ $item['size'] }}</span>
                                                                </td>
                                                                <td class="align-middle">
                                                                    <span
                                                                        class="webshop-cart-price">{{ number_format($item['price'], 0, ',', ' ') }}
                                                                        Ft
                                                                    </span>
                                                                </td>
                                                                <td class="align-middle">
                                                                    <form action="/webshop/cart/update" method="POST"
                                                                        class="d-flex align-items-center">
                                                                        @csrf
                                                                        <input type="hidden" name="variant_id"
                                                                            value="{{ $item['variant_id'] }}">
                                                                        @if ($item['quantity'] == 1)
                                                                            <div class="input-group webshop-quantity-group mx-auto"
                                                                                style="width: 120px;">
                                                                                <button type="button"
                                                                                    class="btn btn-dark webshop-quantity-btn"
                                                                                    onclick="this.parentElement.querySelector('input').stepDown(); this.form.submit();"
                                                                                    disabled>
                                                                                    <i class="fa-solid fa-minus"></i>
                                                                                </button>
                                                                                <input type="number" name="quantity"
                                                                                    value="{{ $item['quantity'] }}"
                                                                                    min="1" {{-- max="{{ $item['stock'] }}" --}}
                                                                                    max="100"
                                                                                    class="form-control text-center webshop-quantity-input"
                                                                                    onchange="this.form.submit()">
                                                                                <button type="button"
                                                                                    class="btn btn-dark webshop-quantity-btn"
                                                                                    onclick="this.parentElement.querySelector('input').stepUp(); this.form.submit();">
                                                                                    <i class="fa-solid fa-plus"></i>
                                                                                </button>
                                                                            </div>
                                                                        @else
                                                                            <div class="input-group webshop-quantity-group mx-auto"
                                                                                style="width: 120px;">
                                                                                <button type="button"
                                                                                    class="btn btn-dark webshop-quantity-btn"
                                                                                    onclick="this.parentElement.querySelector('input').stepDown(); this.form.submit();">
                                                                                    <i class="fa-solid fa-minus"></i>
                                                                                </button>
                                                                                <input type="number" name="quantity"
                                                                                    value="{{ $item['quantity'] }}"
                                                                                    min="1" {{-- max="{{ $item['stock'] }}" --}}
                                                                                    max="100"
                                                                                    class="form-control text-center webshop-quantity-input"
                                                                                    onchange="this.form.submit()">
                                                                                <button type="button"
                                                                                    class="btn btn-dark webshop-quantity-btn"
                                                                                    onclick="this.parentElement.querySelector('input').stepUp(); this.form.submit();">
                                                                                    <i class="fa-solid fa-plus"></i>
                                                                                </button>
                                                                            </div>
                                                                        @endif
                                                                    </form>
                                                                </td>
                                                                <td class="align-middle">
                                                                    <span
                                                                        class="webshop-cart-subtotal">{{ number_format($item['subtotal'], 0, ',', ' ') }}
                                                                        Ft</span>
                                                                </td>
                                                                <td class="align-middle">
                                                                    <form
                                                                        action="/webshop/cart/remove/{{ $item['variant_id'] }}"
                                                                        method="POST">
                                                                        @csrf
                                                                        @method('DELETE')
                                                                        <button type="submit"
                                                                            class="btn btn-link text-danger webshop-cart-remove">
                                                                            <i class="fas fa-trash"></i>
                                                                        </button>
                                                                    </form>
                                                                </td>
                                                            </tr>
                                                        @endforeach
                                                    </tbody>
                                                </table>
                                            </div>

                                            <div
                                                class="d-flex justify-content-between align-items-center mt-4 pt-3 border-top">
                                                <a href="/webshop" class="btn btn-outline-secondary webshop-card-btn-details">
                                                    <i class="fas fa-arrow-left me-2"></i>Vásárlás folytatása
                                                </a>
                                                <form action="/webshop/cart/clear" method="POST">
                                                    @csrf
                                                    <button type="submit" class="btn btn-danger webshop-cart-clear">
                                                        <i class="fas fa-trash-alt me-2"></i>Kosár ürítése
                                                    </button>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                @if ($total > 10000)
                                    <div class="col-lg-4">
                                        <div class="card webshop-card">
                                            <div class="card-body">
                                                <h5 class="webshop-card-title mb-3">Rendelés összegzése</h5>
                                                <div class="d-flex justify-content-between mb-2">
                                                    <span class="webshop-cart-text">Részösszeg:</span>
                                                    <span class="webshop-cart-text">{{ number_format($total, 0, ',', ' ') }}
                                                        Ft</span>
                                                </div>

                                                <div class="d-flex justify-content-between mb-2">
                                                    <span class="webshop-cart-text">Szállítás:</span>
                                                    <del><span class="webshop-cart-text">1 500 Ft</span></del>
                                                </div>

                                                <hr class="my-3">

                                                <div class="d-flex justify-content-between mb-4">
                                                    <span class="webshop-cart-total-label">Összesen:</span>
                                                    <span class="webshop-cart-total">{{ number_format($total, 0, ',', ' ') }}
                                                        Ft</span>
                                                </div>

                                                <a href="/webshop/order"
                                                    class="btn btn-primary webshop-card-btn-cart w-100 py-3">
                                                    <i class="bi bi-credit-card me-2"></i>Tovább a rendeléshez
                                                </a>

                                                <div class="mt-3 text-center">
                                                    <small class="text-white">
                                                        <i class="fas fa-shield-alt me-1"></i>
                                                        Biztonságos vásárlás • 30 napos visszatérítés
                                                    </small>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                @elseif ($total >= 8000 && $total <= 10000)
                                    <div class="col-lg-4">
                                        <div class="card webshop-card">
                                            <div class="card-body">
                                                <h5 class="webshop-card-title mb-3">Rendelés összegzése</h5>
                                                <div class="d-flex justify-content-between mb-2">
                                                    <span class="webshop-cart-text">Részösszeg:</span>
                                                    <span class="webshop-cart-text">{{ number_format($total, 0, ',', ' ') }}
                                                        Ft</span>
                                                </div>

                                                <div class="d-flex justify-content-between mb-2">
                                                    <span class="webshop-cart-text">Szállítás:</span>
                                                    <span class="webshop-cart-text">1 500 Ft</span>
                                                </div>
                                                <div class="alert alert-warning webshop-card-alert mb-3" role="alert">
                                                    <i class="fas fa-exclamation-triangle me-2"></i>
                                                    Ha 10 000 Ft felett vásárol, akkor szállítás ingyenes!
                                                </div>
                                                <hr class="my-3">

                                                <div class="d-flex justify-content-between mb-4">
                                                    <span class="webshop-cart-total-label">Összesen:</span>
                                                    <span
                                                        class="webshop-cart-total">{{ number_format($total + 1500, 0, ',', ' ') }}
                                                        Ft</span>
                                                </div>

                                                <a href="/webshop/order"
                                                    class="btn btn-primary webshop-card-btn-cart w-100 py-3">
                                                    <i class="bi bi-credit-card me-2"></i>Tovább a rendeléshez
                                                </a>

                                                <div class="mt-3 text-center">
                                                    <small class="text-white">
                                                        <i class="fas fa-shield-alt me-1"></i>
                                                        Biztonságos vásárlás • 30 napos visszatérítés
                                                    </small>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                @else
                                    <div class="col-lg-4">
                                        <div class="card webshop-card">
                                            <div class="card-body">
                                                <h5 class="webshop-card-title mb-3">Rendelés összegzése</h5>
                                                <div class="d-flex justify-content-between mb-2">
                                                    <span class="webshop-cart-text">Részösszeg:</span>
                                                    <span class="webshop-cart-text">{{ number_format($total, 0, ',', ' ') }}
                                                        Ft</span>
                                                </div>

                                                <div class="d-flex justify-content-between mb-2">
                                                    <span class="webshop-cart-text">Szállítás:</span>
                                                    <span class="webshop-cart-text">1 500 Ft</span>
                                                </div>

                                                <hr class="my-3">

                                                <div class="d-flex justify-content-between mb-4">
                                                    <span class="webshop-cart-total-label">Összesen:</span>
                                                    <span
                                                        class="webshop-cart-total">{{ number_format($total + 1500, 0, ',', ' ') }}
                                                        Ft</span>
                                                </div>

                                                <a href="/webshop/order"
                                                    class="btn btn-primary webshop-card-btn-cart w-100 py-3">
                                                    <i class="bi bi-credit-card me-2"></i>Tovább a rendeléshez
                                                </a>

                                                <div class="mt-3 text-center">
                                                    <small class="text-white">
                                                        <i class="fas fa-shield-alt me-1"></i>
                                                        Biztonságos vásárlás • 30 napos visszatérítés
                                                    </small>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                @endif
                            </div>
                        @endif
                    </div>
                </div>
            </div>
        @endauth
        @guest
            <main class="d-flex align-items-center justify-content-center" style="min-height: 80vh;">
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-md-8 col-lg-6">
                            <div class="card webshop-card border-0 overflow-hidden">
                                <div class="card-header webshop-card-header text-center py-4">
                                    <i class="bi bi-basket2-fill text-primary"style=" font-size: 3rem;"></i>
                                    <h2 class="h4 mb-0 mt-2 text-white">Üdvözöljük a Webshopunk-ban!</h2>
                                </div>

                                <div class="card-body webshop-card-body p-4">
                                    <div class="text-center mb-4">
                                        <div class="mb-3">
                                            <span class="badge bg-secondary">Prémium minőség</span>
                                            <span class="badge bg-secondary ms-2">Személyre szabva</span>
                                        </div>

                                        <h3 class="h5 mb-3 text-white">Fedezze fel exkluzív termékeinket!</h3>

                                        <p class="mb-4 text-secondary">
                                            Professzionális fodrász és masszázs termékek széles választéka várja.
                                            Vásárláshoz kérjük, jelentkezzen be vagy regisztráljon!
                                        </p>
                                    </div>

                                    <div class="row g-3 mb-4">
                                        <div class="col-6">
                                            <div class="p-3 text-center border rounded webshop-card">
                                                <i class="bi bi-truck text-primary mb-2 fs-4"></i>
                                                <h4 class="h6 mb-1 text-white">Ingyenes szállítás</h4>
                                                <p class="text-secondary small">10.000 Ft felett</p>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="p-3 text-center border rounded webshop-card">
                                                <i class="bi bi-shield-check text-primary mb-2 fs-4"></i>
                                                <h4 class="h6 mb-1 text-white">Minőségi garancia</h4>
                                                <p class="text-secondary small">100% eredeti</p>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="p-3 text-center border rounded webshop-card">
                                                <i class="bi bi-gift text-primary mb-2 fs-4"></i>
                                                <h4 class="h6 mb-1 text-white">Törzsvásárlói program</h4>
                                                <p class="text-secondary small">Extra kedvezmények</p>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="p-3 text-center border rounded webshop-card">
                                                <i class="bi bi-clock-history text-primary mb-2 fs-4"></i>
                                                <h4 class="h6 mb-1 text-white">24 órás szállítás</h4>
                                                <p class="text-secondary small">Raktárról</p>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="d-flex flex-column gap-2">
                                        <a href="/login" class="btn webshop-card-btn-cart py-2">
                                            <i class="bi bi-box-arrow-in-right me-2"></i>
                                            Bejelentkezés
                                        </a>

                                        <a href="/register" class="btn webshop-card-btn-details py-2">
                                            <i class="bi bi-person-plus me-2"></i>
                                            Regisztráció
                                            <span class="text-primary small d-block">2 perc az egész</span>
                                        </a>
                                    </div>

                                    <div class="text-center mt-4">
                                        <a href="/" class="btn btn-outline-secondary webshop-card-btn-details">
                                            <i class="fas fa-arrow-left me-2"></i> Vissza a főoldalra
                                        </a>
                                    </div>
                                </div>

                                <div class="card-footer webshop-card-header border-top">
                                    <div class="text-center">
                                        <small class="text-muted">
                                            <i class="bi bi-shield-lock me-1"></i>
                                            Biztonságos vásárlás | SSL titkosítás
                                        </small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </main>
        @endguest
    </main>
    <style>
        .webshop-title {
            color: #e2e8f0;
            font-weight: 600;
        }

        .webshop-cart-table {
            --bs-table-bg: #151515;
            --bs-table-color: #e2e8f0;
        }


        .webshop-cart-th {
            color: black;
            font-weight: 600;
            border-bottom: 1px solid #4a5568;
            padding-bottom: 1rem;
        }

        .webshop-cart-tr {
            border-bottom: 1px solid #4a5568;
        }

        .webshop-cart-tr:last-child {
            border-bottom: none;
        }

        .webshop-cart-img {
            width: 60px;
            height: 60px;
            object-fit: cover;
            border-radius: 4px;
            border: 1px solid #4a5568;
        }

        .webshop-cart-product-title {
            color: white;
            font-size: 0.95rem;
        }

        .webshop-cart-size {
            /* background-color: black; */
            padding: 0.25rem 0.5rem;
            border-radius: 4px;
            font-size: 0.85rem;
        }

        .webshop-cart-price,
        .webshop-cart-subtotal {
            color: #63b3ed;
            font-weight: 600;
        }

        .webshop-cart-text {
            color: #cbd5e0;
            font-size: 0.95rem;
        }

        .webshop-cart-total-label {
            color: #e2e8f0;
            font-size: 1.1rem;
            font-weight: 600;
        }

        .webshop-cart-total {
            color: #63b3ed;
            font-size: 1.3rem;
            font-weight: 700;
        }

        .webshop-cart-remove {
            font-size: 1rem;
            padding: 0.25rem;
        }

        .webshop-cart-remove:hover {
            color: #f56565 !important;
        }

        .webshop-cart-clear {
            padding: 0.5rem 1rem;
        }

        @media (max-width: 768px) {
            .webshop-cart-table thead {
                display: none;
            }

            .webshop-cart-tr {
                display: block;
                margin-bottom: 1rem;
                border: 1px solid #4a5568;
                border-radius: 8px;
                padding: 1rem;
            }

            .webshop-cart-tr td {
                display: block;
                text-align: center;
                padding: 0.5rem 0;
                border: none;
            }

            .webshop-cart-tr td:before {
                content: attr(data-label);
                float: left;
                font-weight: bold;
                color: #a0aec0;
            }

            .d-flex.justify-content-between.align-items-center {
                flex-direction: column;
                gap: 1rem;
            }

            .webshop-cart-img {
                width: 50px;
                height: 50px;
            }
        }
    </style>
@endsection
