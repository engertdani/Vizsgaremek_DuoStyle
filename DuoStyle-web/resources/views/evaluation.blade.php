@extends('layout')
@section('content')
    <main>
        <div class="container-fluid image-overlay">
            <div class="container text-white">
                <div class="row justify-content-center align-items-center">
                    <div class="col-md-8 strong-overlay my-5">

                        <form class="p-3" action="/write_evaluation" method="POST">
                            @csrf

                            <h2 class="text-center mb-3">Értékeld szalonunkat!</h2>

                            <div>
                                <label for="comment" class="form-label">Értékelés szövege:<strong class="text-danger">
                                        *</strong></label>
                                <textarea name="comment" id="comment" class="form-control inp" rows="3" maxlength="300">{{ old('comment') }}</textarea>
                            </div>
                            @error('comment')
                            <p class="text-danger">{{ $message }}</p>
                            @enderror

                            <div class="mt-3">
                                <label class="form-label d-block">Értékelés <strong class="text-danger">
                                        *</strong></label>

                                <div class="star-rating">
                                    @for ($i = 5; $i >= 1; $i--)
                                        <div class="rating-row">
                                            <input type="radio" name="rating" value="{{ $i }}" @checked(old('rating') == $i) id="star{{ $i }}">
                                            <label for="star{{ $i }}">
                                                @for ($j = 1; $j <= $i; $j++)
                                                    <i class="bi bi-star-fill text-warning"></i>
                                                @endfor
                                            </label>
                                        </div>
                                    @endfor
                                </div>
                            </div>
                            @error('rating')
                            <p class="text-danger">{{ $message }}</p>
                            @enderror

                            <div class="my-3 form-check">
                                <input type="checkbox" name="is_public" id="is_public" class="form-check-input" @checked(old('is_public'))>
                                <label for="is_public" class="form-check-label">Hozzájárulok, hogy az értékelés megjelenhet
                                    publikusan!</label>
                            </div>

                            <button type="submit" class="btn loginbtn">Küldés</button>
                        </form>

                    </div>
                </div>
            </div>
        </div>
    </main>
@endsection
