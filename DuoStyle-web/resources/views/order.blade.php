@extends('layout')
@push('webshop-css')
    <link rel="stylesheet" href="{{ asset('assets/css/webshop.css') }}">
@endpush
@section('content')
    <main>
        @auth
            <div class="container">
                <div class="row">
                    <div class="col-12 mb-4">
                        <h1 class="text-white"><i class="bi bi-truck me-2 text-white"></i>Rendelés</h1>
                    </div>

                    <div class="col-lg-5 mb-4">
                        <div class="card webshop-card h-100">
                            <div class="card-header webshop-card-header">
                                <h5 class="mb-0"><i class="bi bi-person me-2 text-primary"></i>Szállítási adatok</h5>
                            </div>
                            <div class="card-body">
                                <form action="/webshop/order" method="post">
                                    @csrf
                                    <div class="mb-3">
                                        <label class="form-label text-white" for="name">
                                            Teljes név <strong class="text-danger">*</strong>
                                        </label>
                                        <input class="form-control inp @error('name') is-invalid @enderror" type="text"
                                            id="name" name="name" value="{{ Auth::user()->name }}" readonly>
                                        @error('name')
                                            <p class="text-danger small mt-1">{{ $message }}</p>
                                        @enderror
                                    </div>

                                    <div class="mb-3">
                                        <label class="form-label text-white">
                                            Szállítási cím <strong class="text-danger">*</strong>
                                        </label>

                                        <div class="row g-2">

                                            <div class="col-md-2">
                                                <input class="form-control inp @error('zip') is-invalid @enderror"
                                                    type="text" name="zip" value="{{ old('zip') }}" placeholder="2030"
                                                    maxlength="4" pattern="[0-9]{4}" title="Az irányítószám 4 számjegy lehet">
                                            </div>

                                            <div class="col-md-4">
                                                <input class="form-control inp @error('city') is-invalid @enderror"
                                                    type="text" name="city" value="{{ old('city') }}"
                                                    placeholder="Város">
                                            </div>

                                            <div class="col-md-6">
                                                <input class="form-control inp @error('street') is-invalid @enderror"
                                                    type="text" name="street" value="{{ old('street') }}"
                                                    placeholder="Utca, házszám">
                                            </div>

                                        </div>

                                        @error('zip')
                                            <p class="text-danger small mt-1">{{ $message }}</p>
                                        @enderror
                                    </div>

                                    <div class="mb-3">
                                        <label class="form-label text-white" for="phone">
                                            Telefonszám <strong class="text-danger">*</strong>
                                        </label>
                                        <input class="form-control inp @error('phone') is-invalid @enderror" type="text"
                                            id="phone" name="phone" value="{{ Auth::user()->tel }}"
                                            placeholder="+36 30 123 4567">
                                        @error('phone')
                                            <p class="text-danger small mt-1">{{ $message }}</p>
                                        @enderror
                                    </div>

                                    <div class="mb-3">
                                        <label class="form-label text-white d-block">
                                            Szállítás módja <strong class="text-danger">*</strong>
                                        </label>
                                        <div class="d-flex gap-3 flex-wrap">
                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" name="shipping_method"
                                                    id="shipping_home" value="Házhoz szállítás"
                                                    {{ old('shipping_method') == 'home' ? 'checked' : 'checked' }}>
                                                <label class="form-check-label text-white" for="shipping_home">
                                                    <i class="bi bi-truck me-1"></i> Házhoz szállítás
                                                </label>
                                            </div>
                                        </div>
                                        @error('shipping_method')
                                            <p class="text-danger small mt-1">{{ $message }}</p>
                                        @enderror
                                    </div>

                                    <div class="mb-3">
                                        <label class="form-label text-white d-block">
                                            Fizetés módja <strong class="text-danger">*</strong>
                                        </label>
                                        <div class="bg-secondary bg-opacity-25 p-3 rounded border">
                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" name="paying_method"
                                                    id="payment_cod" value="Utánvét" checked>
                                                <label class="form-check-label text-white" for="payment_cod">
                                                    <div class="d-flex align-items-center">
                                                        <i class="bi bi-cash-stack text-primary fs-4 me-3"></i>
                                                        <div>
                                                            <span class="fw-bold d-block">Utánvét</span>
                                                            <small class="text-secondary">Fizetés a futárnak készpénzben vagy
                                                                bankkártyával</small>
                                                        </div>
                                                    </div>
                                                </label>
                                            </div>
                                            <input type="hidden" name="payingmethod" value="cod">
                                        </div>
                                        @error('payingmethod')
                                            <p class="text-danger small mt-1">{{ $message }}</p>
                                        @enderror
                                    </div>

                                    <div class="mb-3">
                                        <label class="form-label text-white" for="note">
                                            Megjegyzés a rendeléshez
                                        </label>
                                        <textarea class="form-control inp" id="note" name="note" rows="2"
                                            placeholder="Pl.: kapucsengő, emelet, ajtókód...">{{ old('note') }}</textarea>
                                    </div>
                                    <div class="mb-3">
                                        <label class="form-label text-white" for="coupon_code">
                                            Kuponkód
                                        </label>
                                        <input type="text" class="form-control inp" id="coupon_code" name="coupon_code"
                                            placeholder="Pl.: KUPON123" value="{{ old('coupon_code') }}">
                                        @error('coupon_code')
                                            <p class="text-danger small mt-1">{{ $message }}</p>
                                        @enderror
                                    </div>

                                    <div class="mt-4">
                                        <button type="submit" class="btn webshop-order-btn w-100 py-3">
                                            <i class="bi bi-check-circle me-2"></i>Rendelés leadása
                                        </button>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-7 mb-4">
                        <div class="card webshop-card">
                            <div class="card-header webshop-card-header">
                                <h5 class="mb-0"><i class="fas fa-shopping-bag me-2 text-primary"></i>Rendelés összegzése
                                </h5>
                            </div>
                            <div class="card-body">
                                @if (empty($cartItems))
                                    <p class="text-white text-center">A kosár üres</p>
                                @else
                                    <div class="webshop-order-items mb-4">
                                        @foreach ($cartItems as $item)
                                            <div
                                                class="webshop-order-item d-flex justify-content-between align-items-center mb-3 pb-2 border-bottom border-secondary">
                                                <div class="d-flex align-items-center">
                                                    <img src="{{ asset('assets/img/' . $item['pn'] . '.png') }}"
                                                        alt="{{ $item['product_name'] }}" class="webshop-order-img me-3">
                                                    <div>
                                                        <h6 class="webshop-order-item-title mb-0">{{ $item['product_name'] }}
                                                        </h6>
                                                        <small class="text-muted">{{ $item['size'] }} |
                                                            {{ $item['quantity'] }} db</small>
                                                    </div>
                                                </div>
                                                <span
                                                    class="webshop-order-item-price">{{ number_format($item['subtotal'], 0, ',', ' ') }}
                                                    Ft</span>
                                            </div>
                                        @endforeach
                                    </div>

                                    <hr class="webshop-hr">

                                    @if ($total > 10000)
                                        <div class="d-flex justify-content-between mb-2">
                                            <span class="webshop-cart-text">Részösszeg:</span>
                                            <span class="webshop-cart-text">{{ number_format($total, 0, ',', ' ') }} Ft</span>
                                        </div>

                                        <div class="d-flex justify-content-between mb-2">
                                            <span class="webshop-cart-text">Szállítás:</span>
                                            <span class="webshop-cart-text shipping-cost"><del>1 500 Ft</del></span>
                                        </div>

                                        <hr class="webshop-hr">

                                        <div class="d-flex justify-content-between mb-4">
                                            <span class="webshop-cart-total-label">Összesen:</span>
                                            <span class="webshop-cart-total">{{ number_format($total, 0, ',', ' ') }}
                                                Ft</span>
                                        </div>
                                    @elseif ($total > 8000 && $total < 10000)
                                        <div class="d-flex justify-content-between mb-2">
                                            <span class="webshop-cart-text">Részösszeg:</span>
                                            <span class="webshop-cart-text">{{ number_format($total, 0, ',', ' ') }} Ft</span>
                                        </div>

                                        <div class="d-flex justify-content-between mb-2">
                                            <span class="webshop-cart-text">Szállítás:</span>
                                            <span class="webshop-cart-text shipping-cost">1 500 Ft</span>
                                        </div>

                                        <div class="alert alert-warning webshop-card-alert mb-3" role="alert">
                                            <i class="fas fa-exclamation-triangle me-2"></i>
                                            Ha 10 000 Ft felett vásárol, akkor szállítás ingyenes!
                                        </div>

                                        <hr class="webshop-hr">

                                        <div class="d-flex justify-content-between mb-4">
                                            <span class="webshop-cart-total-label">Összesen:</span>
                                            <span class="webshop-cart-total">{{ number_format($total + 1500, 0, ',', ' ') }}
                                                Ft</span>
                                        </div>
                                    @else
                                        <div class="d-flex justify-content-between mb-2">
                                            <span class="webshop-cart-text">Részösszeg:</span>
                                            <span class="webshop-cart-text">{{ number_format($total, 0, ',', ' ') }} Ft</span>
                                        </div>

                                        <div class="d-flex justify-content-between mb-2">
                                            <span class="webshop-cart-text">Szállítás:</span>
                                            <span class="webshop-cart-text shipping-cost">1 500 Ft</span>
                                        </div>

                                        <hr class="webshop-hr">

                                        <div class="d-flex justify-content-between mb-4">
                                            <span class="webshop-cart-total-label">Összesen:</span>
                                            <span class="webshop-cart-total">{{ number_format($total + 1500, 0, ',', ' ') }}
                                                Ft</span>
                                        </div>
                                    @endif
                                @endif

                                <div class="webshop-card-actions">
                                    <a href="/webshop" class="btn webshop-card-btn-details w-100 py-3">
                                        <i class="fas fa-arrow-left me-2"></i> Vissza a webshopba
                                    </a>
                                </div>
                            </div>
                        </div>
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
@endsection
