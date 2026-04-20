@extends('layout')
@section('content')
    <main>
        <div class="container-fluid image-overlay">
            <div class="container text-white">
                <div class="row justify-content-center align-items-center">
                    <div class="col-md-8 strong-overlay my-5">
                        <form class="p-3" action="/editprofile/user_id={{ Auth::user()->user_id }}"" method="post">
                            @csrf

                            <h2 class="fw-bold text-center">Adatok módosítása</h2>

                            <div class="row">
                                <div class="col-md-6">
                                    <label class="form-label mt-3" for="lastname">Vezetéknév: <strong
                                            class="text-danger">*</strong></label>
                                    <input class="form-control inp" type="text" id="lastname" name="lastname"
                                        value="{{ old('lastname', $names[0]) }}">
                                    @error('lastname')
                                        <p class="text-danger">{{ $message }}</p>
                                    @enderror
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label mt-3" for="firstname">Keresztnév: <strong
                                            class="text-danger">*</strong></label>
                                    <input class="form-control inp" type="text" id="firstname" name="firstname"
                                        value="{{ old('firstname', $names[1]) }}">
                                    @error('firstname')
                                        <p class="text-danger">{{ $message }}</p>
                                    @enderror
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label class="form-label mt-3" for="edit_email">E-mail: <strong
                                            class="text-danger">*</strong></label>
                                    <input class="form-control inp" type="text" name="edit_email" id="edit_email"
                                        value="{{ old('edit_email', Auth::user()->email) }}">
                                    @error('edit_email')
                                        <p class="text-danger">
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
                                                    value="{{ old('tel', str_replace('+36', '', Auth::user()->tel)) }}"
                                                    maxlength="9">
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
                                    <input class="form-control inp" type="text" list="years" id="year"
                                        name="year" value="{{ old('year', $date[0]) }}" maxlength="4">
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
                                    <input class="form-control inp" type="text" list="months" id="month"
                                        name="month" value="{{ old('month', $date[1]) }}" maxlength="2">
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
                                    <input class="form-control inp" type="text" list="days" id="day"
                                        name="day" value="{{ old('day', $date[2]) }}" maxlength="2">
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

                            <div class="text-center mt-3">
                                <button type="submit" id="saveBtn" class="btn loginbtn" disabled>Mentés</button>
                            </div>

                        </form>
                    </div>
                </div>
            </div>
        </div>
    </main>
    <script>
        window.addEventListener('load', function() {
            const form = document.querySelector('form');
            const button = document.getElementById('saveBtn');
            const inputs = form.querySelectorAll('input[type="text"]');
            const originalValues = {};

            inputs.forEach(input => {
                originalValues[input.name] = input.value.trim();
            });

            function checkChanges() {
                let changed = false;

                inputs.forEach(input => {
                    if (input.value.trim() !== originalValues[input.name]) {
                        changed = true;
                    }
                });

                button.disabled = !changed;
            }

            inputs.forEach(input => {
                input.addEventListener('input', checkChanges);
                input.addEventListener('change', checkChanges);
                input.addEventListener('keyup', checkChanges);
            });

            checkChanges();
        });
    </script>
@endsection
