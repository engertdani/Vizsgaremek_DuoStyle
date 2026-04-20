@extends('layout')
@section('content')
    <main>
        <div class="container-fluid image-overlay">
            <div class="container text-white">
                <div class="row justify-content-center align-items-center">
                    <div class="col-md-8 strong-overlay p-3 newpass">
                        <form method="POST" action="/forgot-password">
                            @csrf

                            @if(session('fail'))
                                <div class="alert alert-danger text-danger py-1 text-center"><i class="bi bi-exclamation-triangle-fill"></i>  {{ session('fail') }}</div>
                            @endif

                            <h2 class="text-center">Elfelejtett jelszó helyreállítása</h2>

                            <label class="form-label mt-2" for="reset-email">E-mail cím: <strong
                                            class="text-danger">*</strong></label><br>
                            <input class="form-control inp" type="text" name="reset-email" id="reset-email" placeholder="Adja meg az e-mail címét"
                                value="{{ old('reset-email') }}">
                            @error('reset-email')
                                <div class="text-danger">{{ $message }}</div>
                            @enderror

                            <div class="mt-3">
                                <button type="submit" class="btn loginbtn">Beküldés</button>
                            </div>

                        </form>
                    </div>
                </div>
            </div>
        </div>
    </main>
@endsection
