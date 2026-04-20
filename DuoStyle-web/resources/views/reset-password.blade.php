@extends('layout')
@section('content')
    <main>
        <div class="container-fluid image-overlay">
            <div class="container text-white">
                <div class="row justify-content-center align-items-center">
                    <div class="col-md-8 strong-overlay my-5 p-3">
                        <form method="POST" action="/profile/reset-password/{{ $token }}">
                            @csrf

                            @if(session('fail'))
                                <div class="alert alert-danger text-danger py-1 text-center"><i class="bi bi-exclamation-triangle-fill"></i>  {{ session('fail') }}</div>
                            @endif

                            <h2 class="text-center">Új jelszó beállítása</h2>

                            <label class="form-label mt-2" for="code">E-mailban kapott kód: <strong
                                            class="text-danger">*</strong></label>
                            <input class="form-control inp" id="code" type="text" name="code" value="{{ old('code') }}" maxlength="6">
                            @error('code')
                                <p class="text-danger">{{ $message }}</p>
                            @enderror

                            <label class="form-label mt-2" for="opassword">Új jelszó: <strong
                                            class="text-danger">*</strong></label>
                            <input class="form-control inp" id="opassword" type="password" name="opassword">
                            @error('opassword')
                                <p class="text-danger">{{ $message }}</p>
                            @enderror

                            <label class="form-label mt-2" for="opassword_confirmation">Új jelszó még egyszer: <strong
                                            class="text-danger">*</strong></label>
                            <input class="form-control inp" id="opassword_confirmation" type="password" name="opassword_confirmation">

                            <button class="btn loginbtn mt-3" type="submit">Jelszó mentése</button>

                        </form>
                    </div>
                </div>
            </div>
        </div>
    </main>
@endsection
