@extends('layout')
@push('webshop-css')
<link rel="stylesheet" href="{{ asset('assets/css/webshop.css') }}">
@endpush
@section('content')
    <main>
        @auth
        <div class="container">
            <!-- Rendező legördülő menü -->
            <div class="row mb-4">
                <div class="col-12">
                    <div class="d-flex justify-content-start align-items-center">
                        <span class="text-white me-3">Rendezés:</span>

                        <div class="dropdown me-3">
                            <button class="btn btn-outline-secondary dropdown-toggle webshop-sort-btn" type="button"
                                id="sortDropdown" data-bs-toggle="dropdown" aria-expanded="false">
                                @if (request('sort') == 'name_asc')
                                    Név A-Z
                                @elseif(request('sort') == 'name_desc')
                                    Név Z-A
                                @elseif(request('sort') == 'price_asc')
                                    Ár szerint növekvő
                                @elseif(request('sort') == 'price_desc')
                                    Ár szerint csökkenő
                                @elseif(request('sort') == 'barber')
                                    Fodrász termékek
                                @elseif(request('sort') == 'massage')
                                    Masszáz termékek
                                @else
                                    Válassz rendezést
                                @endif
                            </button>

                            <ul class="dropdown-menu dropdown-menu-dark webshop-dropdown-menu"
                                aria-labelledby="sortDropdown">
                                <li>
                                    <a class="dropdown-item {{ request('sort') == 'name_asc' ? 'active' : '' }}"
                                        href="/webshop?sort=name_asc{{ request('search') ? '&search=' . request('search') : '' }}">
                                        <i class="fas fa-sort-alpha-down me-2"></i>Név A-Z
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item {{ request('sort') == 'name_desc' ? 'active' : '' }}"
                                        href="/webshop?sort=name_desc{{ request('search') ? '&search=' . request('search') : '' }}">
                                        <i class="fas fa-sort-alpha-up me-2"></i>Név Z-A
                                    </a>
                                </li>
                                <li>
                                    <hr class="dropdown-divider bg-secondary">
                                </li>

                                <li>
                                    <a class="dropdown-item {{ request('sort') == 'price_asc' ? 'active' : '' }}"
                                        href="/webshop?sort=price_asc{{ request('search') ? '&search=' . request('search') : '' }}">
                                        <i class="fas fa-sort-amount-down me-2"></i>Ár szerint növekvő
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item {{ request('sort') == 'price_desc' ? 'active' : '' }}"
                                        href="/webshop?sort=price_desc{{ request('search') ? '&search=' . request('search') : '' }}">
                                        <i class="fas fa-sort-amount-up me-2"></i>Ár szerint csökkenő
                                    </a>
                                </li>
                                <li>
                                    <hr class="dropdown-divider bg-secondary">
                                </li>
                                <li>
                                    <a class="dropdown-item {{ request('sort') == 'barber' ? 'active' : '' }}"
                                        href="/webshop?sort=barber{{ request('search') ? '&search=' . request('search') : '' }}">
                                        <i class="bi bi-scissors me-2"></i>Fodrász termékek
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item {{ request('sort') == 'massage' ? 'active' : '' }}"
                                        href="/webshop?sort=massage{{ request('search') ? '&search=' . request('search') : '' }}">
                                        <i class="bi bi-person-heart me-2"></i>Masszáz termékek
                                    </a>
                                </li>
                                <li>
                                    <hr class="dropdown-divider bg-secondary">
                                </li>
                                <li>
                                    <a class="dropdown-item {{ request('sort') == '' ? 'active' : '' }}"
                                        href="/webshop{{ request('search') ? '?search=' . request('search') : '' }}">
                                        <i class="fas fa-undo me-2"></i>Alap rendezés
                                    </a>
                                </li>
                            </ul>
                        </div>

                        <form method="GET" action="/webshop" class="d-flex">
                            @if (request('sort'))
                                <input type="hidden" name="sort" value="{{ request('sort') }}">
                            @endif
                            <input type="text" name="search" class="form-control me-2" placeholder="Keresés..."
                                value="{{ request('search') }}">
                            <button class="btn btn-primary" type="submit">
                                🔍
                            </button>
                        </form>
                    </div>
                </div>
            </div>

            <div class="row">
                @if (session('success'))
                    <div class="alert alert-success alert-dismissible fade show" role="alert">
                        {{ session('success') }}
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                @endif

                @forelse ($products as $product)
                    <div class="col-lg-3 col-md-4 col-sm-6 mb-4">
                        <div class="card h-100 d-flex flex-column webshop-card">
                            <div class="card-img-top webshop-card-img-container">
                                <img src="{{ asset('assets/img/' . $product->pn . '.png') }}"
                                    class="img-fluid webshop-product-img" alt="{{ $product->name }}">
                            </div>

                            <div class="card-body d-flex flex-column webshop-card-body">
                                <h5 class="card-title webshop-card-title">
                                    <a href="/webshop/product/{{ $product->pn }}"
                                        class="text-decoration-none webshop-card-title-link">
                                        {{ $product->name }}
                                    </a>
                                </h5>

                                <p class="card-text webshop-card-price mb-2">
                                    <strong>{{ number_format($product->price, 0, ',', ' ') }} Ft</strong>
                                </p>

                                <p class="card-text flex-grow-1 webshop-card-text">
                                    {{ $product->description }}
                                </p>

                                @if ($product->dbvarians > 1)
                                    <p class="card-text webshop-card-variants mb-2">
                                        <i class="fas fa-boxes me-1"></i> {{ $product->dbvarians }} féle variánsban kapható
                                    </p>
                                @endif

                                <div class="mt-auto webshop-card-actions">
                                    <a href="/webshop/product/{{ $product->pn }}"
                                        class="btn btn-outline-secondary btn-sm webshop-card-btn-details">
                                        Részletek
                                    </a>
                                    @if ($product->active == 0)
                                        <button class="btn btn-secondary btn-sm webshop-card-btn-cart" disabled>
                                            Nem áruljuk a terméket!<i class="bi bi-x-circle p-1"></i>
                                        </button>
                                    @elseif ($product->stock == 0)
                                        <button class="btn btn-secondary btn-sm webshop-card-btn-cart" disabled>
                                            Nincs készleten!<i class="bi bi-clock p-1"></i>
                                        </button>
                                    @else
                                        <form method="POST" action="/webshop/cart/add" class="d-inline">
                                            @csrf
                                            <input type="hidden" name="variant_id" value="{{ $product->variant_id }}">
                                            <input type="hidden" name="quantity" value="1">
                                            <button type="submit" class="btn btn-primary btn-sm webshop-card-btn-cart">
                                                Kosárba<i class="bi bi-cart-fill p-1"></i>
                                            </button>
                                        </form>
                                    @endif
                                </div>
                            </div>
                        </div>
                    </div>
                @empty
                    @if (request('search'))
                        <div class="col-12">
                            <div class="text-center py-5">
                                <div class="card webshop-card">
                                    <div class="card-body text-center py-5">
                                        <i class="bi bi-search fa-3x text-muted mb-3"></i>
                                        <h3 class="webshop-card-title mb-3">Nincs ilyen termékünk 😔</h3>
                                        <p class="webshop-card-text mb-4">
                                            A keresésre nem találtunk találatot:
                                            <strong>"{{ request('search') }}"</strong>
                                        </p>
                                        <a href="/webshop" class="btn btn-primary webshop-card-btn-cart">
                                            <i class="fas fa-store me-2"></i>Vissza a webshopba
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    @endif
                @endforelse
            </div>
        </div>
    </main>
@endauth
@guest

    <div class="container">
        <!-- Rendező legördülő menü -->
        <div class="row mb-4">
            <div class="col-12">
                <div class="d-flex justify-content-start align-items-center">
                    <span class="text-white me-3">Rendezés:</span>

                    <div class="dropdown me-3">
                        <button class="btn btn-outline-secondary dropdown-toggle webshop-sort-btn" type="button"
                            id="sortDropdown" data-bs-toggle="dropdown" aria-expanded="false">
                            @if (request('sort') == 'name_asc')
                                Név A-Z
                            @elseif(request('sort') == 'name_desc')
                                Név Z-A
                            @elseif(request('sort') == 'price_asc')
                                Ár szerint növekvő
                            @elseif(request('sort') == 'price_desc')
                                Ár szerint csökkenő
                            @elseif(request('sort') == 'barber')
                                Fodrász termékek
                            @elseif(request('sort') == 'massage')
                                Masszáz termékek
                            @else
                                Válassz rendezést
                            @endif
                        </button>

                        <ul class="dropdown-menu dropdown-menu-dark webshop-dropdown-menu" aria-labelledby="sortDropdown">
                            <li>
                                <a class="dropdown-item {{ request('sort') == 'name_asc' ? 'active' : '' }}"
                                    href="/webshop?sort=name_asc{{ request('search') ? '&search=' . request('search') : '' }}">
                                    <i class="fas fa-sort-alpha-down me-2"></i>Név A-Z
                                </a>
                            </li>
                            <li>
                                <a class="dropdown-item {{ request('sort') == 'name_desc' ? 'active' : '' }}"
                                    href="/webshop?sort=name_desc{{ request('search') ? '&search=' . request('search') : '' }}">
                                    <i class="fas fa-sort-alpha-up me-2"></i>Név Z-A
                                </a>
                            </li>
                            <li>
                                <hr class="dropdown-divider bg-secondary">
                            </li>

                            <li>
                                <a class="dropdown-item {{ request('sort') == 'price_asc' ? 'active' : '' }}"
                                    href="/webshop?sort=price_asc{{ request('search') ? '&search=' . request('search') : '' }}">
                                    <i class="fas fa-sort-amount-down me-2"></i>Ár szerint növekvő
                                </a>
                            </li>
                            <li>
                                <a class="dropdown-item {{ request('sort') == 'price_desc' ? 'active' : '' }}"
                                    href="/webshop?sort=price_desc{{ request('search') ? '&search=' . request('search') : '' }}">
                                    <i class="fas fa-sort-amount-up me-2"></i>Ár szerint csökkenő
                                </a>
                            </li>
                            <li>
                                <hr class="dropdown-divider bg-secondary">
                            </li>
                            <li>
                                <a class="dropdown-item {{ request('sort') == 'barber' ? 'active' : '' }}"
                                    href="/webshop?sort=barber{{ request('search') ? '&search=' . request('search') : '' }}">
                                    <i class="bi bi-scissors me-2"></i>Fodrász termékek
                                </a>
                            </li>
                            <li>
                                <a class="dropdown-item {{ request('sort') == 'massage' ? 'active' : '' }}"
                                    href="/webshop?sort=massage{{ request('search') ? '&search=' . request('search') : '' }}">
                                    <i class="bi bi-person-heart me-2"></i>Masszáz termékek
                                </a>
                            </li>
                            <li>
                                <hr class="dropdown-divider bg-secondary">
                            </li>
                            <li>
                                <a class="dropdown-item {{ request('sort') == '' ? 'active' : '' }}"
                                    href="/webshop{{ request('search') ? '?search=' . request('search') : '' }}">
                                    <i class="fas fa-undo me-2"></i>Alap rendezés
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            @foreach ($products as $product)
                <div class="col-lg-3 col-md-4 col-sm-6 mb-4">
                    <div class="card h-100 d-flex flex-column webshop-card">
                        <div class="card-img-top webshop-card-img-container">
                            <img src="{{ asset('assets/img/' . $product->pn . '.png') }}"
                                class="img-fluid webshop-product-img" alt="{{ $product->name }}">
                        </div>

                        <div class="card-body d-flex flex-column webshop-card-body">
                            <h5 class="card-title webshop-card-title">
                                <a href="/webshop" class="text-decoration-none webshop-card-title-link">
                                    {{ $product->name }}
                                </a>
                            </h5>

                            <p class="card-text webshop-card-price mb-2" style="filter: blur(6px); user-select: none;">
                                <strong>{{ number_format($product->price, 0, ',', ' ') }} Ft</strong>
                            </p>


                            <p class="card-text flex-grow-1 webshop-card-text">
                                {{ $product->description }}
                            </p>

                            @if ($product->dbvarians > 1)
                                <p class="card-text webshop-card-variants mb-2">
                                    <i class="fas fa-boxes me-1"></i> {{ $product->dbvarians }} féle variánsban
                                    kapható
                                </p>
                            @endif

                            <div class="mt-auto webshop-card-actions">
                                <div class="alert alert-info webshop-card-alert mb-3" role="alert">
                                    <i class="fas fa-shopping-cart me-2"></i>
                                    A termékek megtekintéséhez és vásárlásához jelentkezz be!
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            @endforeach
        </div>
    </div>
@endguest
@endsection
{{-- <style>
    @media (max-width: 576px) {
        .dropdown, .text-white{
        display: none;
        align-items: center;
        }
    }
</style> --}}
