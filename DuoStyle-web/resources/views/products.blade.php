@extends('layout')
@push('webshop-css')
<link rel="stylesheet" href="{{ asset('assets/css/webshop.css') }}">
@endpush
@section('content')
    <main>
        @auth
            <div class="container">
                <div class="row">
                    <div class="col-lg-6 offset-lg-3 col-md-8 offset-md-2">
                        <div class="card h-100 d-flex flex-column webshop-card">
                            <div class="card-img-top webshop-card-img-container">
                                <img src="{{ asset('assets/img/' . $products->pn . '.png') }}"
                                    class="img-fluid webshop-product-img" alt="{{ $products->name }}">
                            </div>

                            <div class="card-body d-flex flex-column webshop-card-body">
                                <!-- Session üzenetek -->
                                @if (session('success'))
                                    <div class="alert alert-success alert-dismissible fade show" role="alert">
                                        {{ session('success') }}
                                        <button type="button" class="btn-close" data-bs-dismiss="alert"
                                            aria-label="Close"></button>
                                    </div>
                                @endif

                                @if (session('error'))
                                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                                        {{ session('error') }}
                                        <button type="button" class="btn-close" data-bs-dismiss="alert"
                                            aria-label="Close"></button>
                                    </div>
                                @endif

                                <h5 class="card-title webshop-card-title">
                                    <a class="text-decoration-none webshop-card-title-link">
                                        {{ $products->name }}
                                    </a>
                                </h5>

                                <!-- Méret választó  -->
                                @if ($product_variants->count() > 1)
                                    <div class="mb-4">
                                        <h6 class="webshop-card-subtitle mb-3">Válassz méretet:</h6>
                                        <div class="d-flex flex-wrap gap-2">
                                            @foreach ($product_variants as $variant)
                                                <a href="?variant_id={{ $variant->variant_id }}"
                                                    class="btn btn-outline-secondary webshop-variant-btn
                                                  {{ $selected_variant->variant_id == $variant->variant_id ? 'active' : '' }}
                                                  {{ $variant->active == 0 || $variant->stock == 0 ? 'disabled' : '' }}">
                                                    {{ $variant->size }}
                                                    @if ($variant->active == 0)
                                                        <span class="badge bg-danger ms-1">Nem áruljuk</span>
                                                    @endif
                                                    @if ($variant->stock == 0)
                                                        <span class="badge bg-danger ms-1">Elfogyott</span>
                                                    @endif
                                                </a>
                                            @endforeach
                                        </div>
                                    </div>
                                @endif

                                <!-- Kiválasztott variáns információk -->
                                @if ($selected_variant->active == 0)
                                    <div class="alert alert-danger mb-3 webshop-card-alert" role="alert">
                                        <p class="mb-0"><strong>Sajnos már nem áruljuk ezt a terméket!</strong><br>
                                            A termék adatai továbbra is megtalálhatók!</p>
                                    </div>
                                @endif

                                <div class="mb-3">
                                    <p class="card-text webshop-card-text">
                                        {{ $products->description }}
                                    </p>

                                    @if ($selected_variant->size)
                                        <p class="card-text webshop-card-text mb-1">
                                            <strong>Méret:</strong> {{ $selected_variant->size }}
                                        </p>
                                    @endif

                                    <p class="card-text webshop-card-price">
                                        <strong>Ár:</strong> {{ number_format($selected_variant->price, 0, ',', ' ') }} Ft
                                    </p>

                                    @if ($in_cart_quantity > 0)
                                        <div class="alert alert-info webshop-card-alert mb-3" role="alert">
                                            <i class="fas fa-shopping-cart me-2"></i>
                                            Már {{ $in_cart_quantity }} db van a kosaradban
                                        </div>
                                    @endif
                                </div>

                                @if ($selected_variant->active == 1)
                                    <div class="mb-4">
                                        @if ($selected_variant->stock < 10 && $selected_variant->stock > 0)
                                            <div class="alert alert-warning webshop-card-alert mb-3" role="alert">
                                                <i class="fas fa-exclamation-triangle me-2"></i>
                                                Siess, mert már csak {{ $selected_variant->stock }} db van!
                                            </div>
                                        @elseif ($selected_variant->stock == 0)
                                            <div class="alert alert-danger webshop-card-alert mb-3" role="alert">
                                                <i class="fas fa-times-circle me-2"></i>
                                                Jelenleg nincs készleten
                                            </div>
                                        @else
                                            <div class="alert alert-success webshop-card-alert mb-3" role="alert">
                                                <i class="fas fa-check-circle me-2"></i>
                                                Készleten van
                                            </div>
                                        @endif
                                    </div>

                                    @if ($selected_variant->stock > 0)
                                        <!-- Kosárhoz adás form -->
                                        <form method="POST" action="/webshop/cart/add" class="mb-4">
                                            @csrf
                                            <input type="hidden" name="variant_id"
                                                value="{{ $selected_variant->variant_id }}">
                                            <input type="hidden" name="size" value="{{ $selected_variant->size }}">
                                            <input type="hidden" name="pn" value="{{ $selected_variant->pn }}">

                                            @if ($in_cart_quantity > 0)
                                                <div class="d-flex align-items-center justify-content-center mb-4">
                                                    <div class="input-group webshop-quantity-group" style="max-width: 200px;">
                                                        <button type="button" class="btn btn-dark webshop-quantity-btn"
                                                            onclick="decreaseQuantity()">
                                                            <i class="fa-solid fa-minus"></i>
                                                        </button>
                                                        <input type="number" name="quantity" id="quantity"
                                                            value="{{ $in_cart_quantity }}" min="1"
                                                            max="{{ $selected_variant->stock }}"
                                                            class="form-control text-center webshop-quantity-input">
                                                        <button type="button" class="btn btn-dark webshop-quantity-btn"
                                                            onclick="increaseQuantity()">
                                                            <i class="fa-solid fa-plus"></i>
                                                        </button>
                                                    </div>
                                                </div>
                                            @else
                                                <div class="d-flex align-items-center justify-content-center mb-4">
                                                    <div class="input-group webshop-quantity-group" style="max-width: 200px;">
                                                        <button type="button" class="btn btn-dark webshop-quantity-btn"
                                                            onclick="decreaseQuantity()">
                                                            <i class="fa-solid fa-minus"></i>
                                                        </button>
                                                        <input type="number" name="quantity" id="quantity" value="1"
                                                            min="1" max="{{ $selected_variant->stock }}"
                                                            class="form-control text-center webshop-quantity-input">
                                                        <button type="button" class="btn btn-dark webshop-quantity-btn"
                                                            onclick="increaseQuantity()">
                                                            <i class="fa-solid fa-plus"></i>
                                                        </button>
                                                    </div>
                                                </div>
                                            @endif

                                            <div class="webshop-card-actions mt-auto">
                                                <a href="/webshop" class="btn btn-outline-secondary webshop-card-btn-details">
                                                    <i class="fas fa-arrow-left me-2"></i> Vissza
                                                </a>
                                                <button type="submit" class="btn btn-primary webshop-card-btn-cart">
                                                    <i class="fas fa-shopping-cart me-2"></i> Kosárba
                                                </button>
                                            </div>
                                        </form>

                                        <!-- Külön form a törléshez (csak ha van a kosárban) -->
                                        @if ($in_cart_quantity > 0)
                                            <form action="/webshop/cart/remove/{{ $selected_variant->variant_id }}"
                                                method="POST" class="text-center mt-3">
                                                @csrf
                                                @method('DELETE')
                                                <button type="submit" class="btn btn-danger webshop-delete-btn">
                                                    <i class="fa-solid fa-trash me-2"></i> Törlés a kosárból
                                                </button>
                                            </form>
                                        @endif
                                    @else
                                        <div class="webshop-card-actions mt-auto">
                                            <button class="btn btn-secondary webshop-card-btn-cart" disabled>
                                                <i class="fas fa-ban me-2"></i> Nincs készleten
                                            </button>
                                            <a href="/webshop" class="btn btn-outline-secondary webshop-card-btn-details">
                                                <i class="fas fa-arrow-left me-2"></i> Vissza
                                            </a>
                                        </div>
                                    @endif
                                @else
                                    <div class="webshop-card-actions mt-auto">
                                        <a href="/webshop" class="btn btn-outline-secondary webshop-card-btn-details">
                                            <i class="fas fa-arrow-left me-2"></i> Vissza a webshophoz
                                        </a>
                                    </div>
                                @endif
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

    <script>
        function increaseQuantity() {
            const input = document.getElementById('quantity');
            if (parseInt(input.value) < {{ $selected_variant->stock }}) {
                input.value = parseInt(input.value) + 1;
            }
        }

        function decreaseQuantity() {
            const input = document.getElementById('quantity');
            if (parseInt(input.value) > 1) {
                input.value = parseInt(input.value) - 1;
            }
        }
    </script>
@endsection
