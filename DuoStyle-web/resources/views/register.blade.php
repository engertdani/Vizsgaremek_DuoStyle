@extends('layout')
@section('content')
    <main>
        <div class="container-fluid image-overlay">
            <div class="container text-white">
                <div class="row justify-content-center align-items-center">
                    <div class="col-md-8 strong-overlay my-5">
                        {{-- Regisztrációs űrlap --}}
                        <form class="p-3" action="/register" method="post">
                            @csrf

                            <h2 class="fw-bold text-center">Regisztráció</h2>

                            <div class="row">
                                <div class="col-md-6">
                                    <label class="form-label mt-3" for="lastname">Vezetéknév: <strong
                                            class="text-danger">*</strong></label>
                                    <input class="form-control inp" type="text" id="lastname" name="lastname"
                                        value="{{ old('lastname') }}" placeholder="Kis">
                                    @error('lastname')
                                        <p class="text-danger">{{ $message }}</p>
                                    @enderror
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label mt-3" for="firstname">Keresztnév: <strong
                                            class="text-danger">*</strong></label>
                                    <input class="form-control inp" type="text" id="firstname" name="firstname"
                                        value="{{ old('firstname') }}" placeholder="Béla">
                                    @error('firstname')
                                        <p class="text-danger">{{ $message }}</p>
                                    @enderror
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label class="form-label mt-3" for="register_email">E-mail: <strong
                                            class="text-danger">*</strong></label>
                                    <input class="form-control inp" type="text" name="register_email" id="register_email"
                                        value="{{ old('register_email') }}" placeholder="peldabela@gmail.com">
                                    @error('register_email')
                                        <p class="text-danger">
                                            {{ $message }}
                                            {{-- Ha az e-mail cím már regisztrálva van, akkor megjelenít egy linket a bejelentkezéshez --}}
                                            @if ($errors->get('email') && str_contains($message, 'regisztráltak'))
                                                <a href="/login">Bejelentkezés</a>
                                            @endif
                                        </p>
                                    @enderror
                                </div>
                                <div class="col-md-6">
                                    <div class="row mt-3">
                                        <label class="form-label" for="tel">Tel.: <strong
                                                class="text-danger">*</strong></label>
                                        <div class="col-md-12">
                                            <div class="input-group">
                                                <span class="input-group-text ">+36</span>
                                                <input class="form-control inp" type="text" id="tel" name="tel"
                                                    value="{{ old('tel') }}" placeholder="pl.:301234567" maxlength="9">
                                            </div>
                                            @error('tel')
                                                <p class="text-danger">{{ $message }}</p>
                                            @enderror
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row mt-3">
                                <label class="form-label" for="year">Születési dátum: <strong
                                        class="text-danger">*</strong></label>
                                <div class="col-4">
                                    {{-- 10 éves kortól regisztráció, évek kiválasztása --}}
                                    <input class="form-control inp" type="text" list="years" placeholder="Év"
                                        id="year" name="year" value="{{ old('year') }}" maxlength="4">
                                    <datalist id="years">
                                        @for ($i = date('Y') - 14; $i >= 1960; $i--)
                                            <option value="{{ $i }}"></option>
                                        @endfor
                                    </datalist>
                                    @error('year')
                                        <p class="text-danger">{{ $message }}</p>
                                    @enderror
                                </div>
                                <div class="col-4">
                                    <input class="form-control inp" type="text" list="months" placeholder="Hónap"
                                        id="month" name="month" value="{{ old('month') }}" maxlength="2">
                                    <datalist id="months">
                                        @for ($i = 1; $i <= 12; $i++)
                                            <option value="{{ $i }}"></option>
                                        @endfor
                                    </datalist>
                                    @error('month')
                                        <p class="text-danger">{{ $message }}</p>
                                    @enderror
                                </div>
                                <div class="col-4">
                                    <input class="form-control inp" type="text" list="days" placeholder="Nap"
                                        id="day" name="day" value="{{ old('day') }}" maxlength="2">
                                    <datalist id="days">
                                        @for ($i = 1; $i <= 31; $i++)
                                            <option value="{{ $i }}">
                                            <option>
                                        @endfor
                                    </datalist>
                                    @error('day')
                                        <p class="text-danger">{{ $message }}</p>
                                    @enderror
                                </div>
                            </div>

                            <label class="form-label mt-3" for="register_password">
                                Jelszó: <strong class="text-danger">*</strong>
                            </label>
                            <div class="input-group">
                                <input class="form-control inp" type="password" name="register_password"
                                    id="register_password" maxlength="20" onkeyup="test()">
                                {{-- Jelszó megjelenítés --}}
                                <span class="input-group-text"
                                    onclick="togglePassword('register_password', 'toggleIcon')">
                                    <i class="bi bi-eye" id="toggleIcon"></i>
                                </span>
                            </div>
                            @error('register_password')
                                <p class="text-danger">{{ $message }}</p>
                            @enderror

                            <label class="form-label mt-3" for="register_password_confirmation">
                                Jelszó újra: <strong class="text-danger">*</strong>
                            </label>
                            <div class="input-group mb-2">
                                <input class="form-control inp" type="password" name="register_password_confirmation"
                                    id="register_password_confirmation" maxlength="20">
                                {{-- Jelszó megjelenítés --}}
                                <span class="input-group-text"
                                    onclick="togglePassword('register_password_confirmation', 'conf_toggleIcon')">
                                    <i class="bi bi-eye" id="conf_toggleIcon"></i>
                                </span>
                            </div>
                            <div>
                                <ul>
                                    <li class="text-danger" id="min">Legalább 8 karakter</li>
                                    <li class="text-danger" id="number">Legalább egy számot kell tartalmaznia!</li>
                                    <li class="text-danger" id="spec">Legalább egy speciális karaktert kell tartalmaznia!</li>
                                    <li class="text-danger" id="letter">Kis és nagybetűt kell tartalmaznia!</li>
                                </ul>
                            </div>

                            <label class="form-label mt-3">Nem: <strong class="text-danger">*</strong></label>
                            <div class="d-flex gap-4">
                                <div class="form-check">
                                    <input class="form-check-input" type="radio" name="gender" id="gender_f"
                                        value="f" @checked(old('gender') === 'f')>
                                    <label class="form-check-label" for="gender_f">
                                        Férfi
                                    </label>
                                </div>

                                <div class="form-check">
                                    <input class="form-check-input" type="radio" name="gender" id="gender_n"
                                        value="n" @checked(old('gender') === 'n')>
                                    <label class="form-check-label" for="gender_n">
                                        Nő
                                    </label>
                                </div>
                            </div>
                            @error('gender')
                                <p class="text-danger">{{ $message }}</p>
                            @enderror

                            <div class="form-check mt-1">
                                <input class="form-check-input" type="checkbox" name="terms" id="terms">
                                <label class="form-check-label" for="terms">
                                    Elfogadom a
                                    <a href="/documents/aszf" target="_blank">
                                        szerződési feltételeket
                                    </a>
                                    és az
                                    <a href="/documents/adatvedelmi" target="_blank">
                                        adatvédelmi nyilatkozatot
                                    </a>.
                                    <strong class="text-danger">*</strong>
                                </label>
                            </div>
                            @error('terms')
                                <p class="text-danger">{{ $message }}</p>
                            @enderror

                            <div class="text-center mt-3">
                                <button type="submit" class="btn loginbtn">Regisztráció</button>
                            </div>

                        </form>
                    </div>
                </div>
            </div>
        </div>
    </main>
@endsection
