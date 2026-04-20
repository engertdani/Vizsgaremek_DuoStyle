<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\User;
use App\Models\PasswordResetRequest;
use Illuminate\Validation\Rules\Password;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Hash;
use Carbon\Carbon;
use Illuminate\Support\Facades\Mail;
use App\Mail\RegisterMail;
use Illuminate\Support\Str;
use App\Mail\ForgotPasswordMail;

class UserController extends Controller
{
    // Ha be van jelentkezve a felhasználó, átirányítjuk a főoldalra
    public function Register(){
        if(Auth::check()){
            return redirect('/');
        }
        else{
            return view('register');
        }
    }

    // Regisztráció gomb megnyomásakor
    public function RegisterBtn(Request $request){
        // Regisztráció validáció
        $request->validate([
            'lastname'              => 'required|max:50|min:3',
            'firstname'             => 'required|max:50|min:3',
            'register_email'        => 'required|email:rsc,dns|max:100|unique:users,email',
            'tel'                   => 'required|numeric|digits_between:8,9',
            'year'                  => 'required|numeric|min:'.(date('Y') - 100).'|max:'.(date('Y') - 14),
            'month'                 => 'required|numeric|min:1|max:12',
            'day'                   => 'required|numeric|min:1|max:31',
            'register_password'     => ['required', Password::min(8)
                                        ->letters()
                                        ->numbers()
                                        ->mixedCase()
                                        ->symbols()
                                        ->uncompromised(),
                                        'confirmed'],
            'gender'                => 'required',
            'terms'                 => 'required',
        ],[
            // Felhasználóbarát hibaüzenetek magyarul
            'lastname.required' => 'Kérjük, adja meg a vezetéknevét.',
            'lastname.min'      => 'A vezetéknévnek legalább :min karakter hosszúnak kell lennie.',
            'lastname.max'      => 'A vezetéknév legfeljebb :max karakter hosszú lehet.',

            'firstname.required' => 'Kérjük, adja meg a keresztnevét.',
            'firstname.min'      => 'A keresztnévnek legalább :min karakter hosszúnak kell lennie.',
            'firstname.max'      => 'A keresztnév legfeljebb :max karakter hosszú lehet.',

            'register_email.required' => 'Kérjük, adja meg az e-mail címét.',
            'register_email.email'    => 'Kérjük, adjon meg egy érvényes e-mail címet.',
            'register_email.max'      => 'Az e-mail cím legfeljebb :max karakter hosszú lehet.',
            'register_email.unique'   => 'Ezzel az e-mail címmel már regisztráltak.',

            'tel.required'          => 'Kérjük, adja meg a telefonszámát.',
            'tel.numeric'          => 'A telefonszám csak számjegyeket tartalmazhat.',
            'tel.digits_between'   => 'A telefonszámnak 7 vagy 8 számjegyből kell állnia.',

            'year.required'  => 'Kérjük, adja meg a születési évét.',
            'year.numeric'   => 'A születési év csak szám lehet.',
            'year.min'       => 'A születési év nem lehet korábbi, mint :min.',
            'year.max'       => 'A regisztráció minimum 14 éves kortól engedélyezett.',

            'month.required' => 'Kérjük, adja meg a születési hónapot.',
            'month.numeric'  => 'A hónap csak szám lehet.',
            'month.min'      => 'A hónap értéke minimum 1.',
            'month.max'      => 'A hónap értéke maximum 12.',

            'day.required'   => 'Kérjük, adja meg a születési napot.',
            'day.numeric'    => 'A nap csak szám lehet.',
            'day.min'        => 'A nap értéke minimum 1.',
            'day.max'        => 'A nap értéke maximum 31.',

            'register_password.required'        => 'Kérjük, adjon meg egy jelszót.',
            'register_password.confirmed'       => 'A megadott jelszavak nem egyeznek.',
            'register_password.min'             => 'A jelszónak legalább :min karakter hosszúnak kell lennie.',
            'register_password.max'             => 'A jelszó max :max karakter hosszú lehet.',
            'register_password.letters'         => 'A jelszónak tartalmaznia kell legalább egy betűt.',
            'register_password.numbers'         => 'A jelszónak tartalmaznia kell legalább egy számot.',
            'register_password.mixed'           => 'A jelszónak kis- és nagybetűt is tartalmaznia kell.',
            'register_password.symbols'         => 'A jelszónak tartalmaznia kell legalább egy speciális karaktert.',
            'register_password.uncompromised'   => 'A megadott jelszó nem biztonságos, kérjük válasszon másikat.',

            'gender.required' => 'Kérjük, válassza ki a nemét.',

            'terms.required' => 'A regisztrációhoz el kell fogadnia a szerződési feltételeket és az adatvédelmi nyilatkozatot.',
        ]);

        $birthDate = Carbon::createFromDate(
            $request->year,
            $request->month,
            $request->day
        );

        // Adatbázisba mentés
        $data = new user;
        $data->name         = $request->lastname.' '.$request->firstname;
        $data->email        = $request->register_email;
        $data->tel          = '+36'.$request->tel;
        $data->born_date    = $birthDate->format('Y-m-d');
        $data->password     = $request->register_password;
        $data->gender       = $request->gender;

        // E-mail mgerősítő token létrehozása
        $data->verification_token = Str::random(64);

        $data->save();

        // Sikeres regisztráció után e-mail küldés
        Mail::to($data->email)->send(new RegisterMail($data));
        return redirect('/')->with(
            'success', 'Sikeres regisztráció! Kérjük, ellenőrizze e-mail fiókját a megerősítő üzenetért.'
        );
    }

    // E-mail cím megerősítése
    public function EmailVerify($token)
    {
        $user = User::where('verification_token', $token)->first();

        $user->verified_at = now();
        $user->verification_token = null;
        $user->save();

        return view('Verify');
    }


    // Ha be van jelentkezve a felhasználó, átirányítjuk a főoldalra
    public function Login(){
        if(Auth::check()){
            return redirect('/');
        }
        else{
            return redirect('/')->with('openLogin', true);
        }
    }

    // Bejelentkezés gomb megnyomásakor
    public function LoginBtn(Request $request){
        $redirectTo = $request->input('redirect_to', '/');

        $user = User::where('email', $request->email)
                    ->where('active', 1)
                    ->first();

        // Ha nincs ilyen e-mail cím regisztrálva
        if(!$user){
            return redirect('/')
                ->with('openLogin', true)
                ->with('fail', 'Nem található ilyen e-mail cím a rendszerben');
        }

        // E-mail megerősítés ellenőrzése
        if(!$user->verified_at){
            return redirect('/')
                ->with('openLogin', true)
                ->with('fail', 'Kérjük, erősítse meg e-mail címét a bejelentkezés előtt.');
        }

        // Sikeres bejelentkezés
        if(Auth::attempt(['email' => $request->email, 'password' => $request->password])){
            return redirect()->to($redirectTo);
        }
        // Sikertelen bejelentkezés
        else
        {
            return redirect($redirectTo)
                ->with('openLogin', true)
                ->with('fail', 'Hibás e-mail cím vagy jelszó.');
        }
    }

    // Kijelentkezés
    public function Logout(){
        Auth::logout();
        return redirect('/');
    }

    public function ForgotPassword()
    {
        if(Auth::check()){
            return redirect('/');
        }
        else{
            return view('forgot-password');
        }
    }
    // Elfelejtett jelszó űrlap feldolgozása
    public function ForgotPasswordBtn(Request $request)
    {
        // Validáció
        $request->validate(
            [
                'reset-email' => 'required|email:rsc,dns',
            ],
            [
                'reset-email.required' => 'Az e-mail cím megadása kötelező.',
                'reset-email.email'    => 'Érvényes e-mail címet adjon meg.',
            ]
        );

        $user = User::where('email', $request->input('reset-email'))->first();

        if (!$user) {
            return back()->with('fail', 'Ilyen e-mail címmel nem található felhasználó.');
        }

        // Régi kérések törlése
        PasswordResetRequest::where('email', $user->email)->delete();

        // Token és kód generálása
        $token = Str::random(64);
        $code  = strtoupper(Str::random(6));

        // Mentés az adatbázisba
        PasswordResetRequest::create([
            'email' => $user->email,
            'token' => $token,
            'code' => $code,
            'expires_at' => now()->addMinutes(30),
        ]);

        // E-mail küldése
        Mail::to($user->email)->send(
            new ForgotPasswordMail($user, $token, $code)
        );

        return redirect('/')->with(
            'success', 'Jelszó-visszaállító e-mail elküldve. Kérjük, ellenőrizze a beérkező levelek mappáját.'
        );
    }


    public function ResetPassword($token){
        return view('reset-password', compact('token'));
    }

    public function ResetPasswordBtn(Request $request, $token)
    {
        // Validáció
        $request->validate([
            'code' => 'required|size:6',
            'opassword' => ['required', 'confirmed', Password::min(8)
                ->letters()
                ->numbers()
                ->mixedCase()
                ->symbols()
                ->uncompromised()],
        ],[
            'code.required' => 'Kérjük, adja meg a jelszó-visszaállító kódot.',
            'code.size'     => 'A jelszó-visszaállító kód pontosan :size karakter hosszú legyen.',

            'opassword.required'              => 'Kérjük, adjon meg egy új jelszót.',
            'opassword.confirmed'             => 'A megadott jelszavak nem egyeznek.',
            'opassword.min'                   => 'Az új jelszónak legalább :min karakter hosszúnak kell lennie.',
            'opassword.letters'               => 'Az új jelszónak tartalmaznia kell legalább egy betűt.',
            'opassword.numbers'               => 'Az új jelszónak tartalmaznia kell legalább egy számot.',
            'opassword.mixedCase'             => 'Az új jelszónak kis- és nagybetűt is tartalmaznia kell.',
            'opassword.symbols'               => 'Az új jelszónak tartalmaznia kell legalább egy speciális karaktert.',
            'opassword.uncompromised'         => 'A megadott jelszó nem biztonságos, kérjük válasszon másikat.',
        ]);

        // Kód és token ellenőrzése
        $code = trim($request->code);

        // Keresés az adatbázisban
        $reset = PasswordResetRequest::where('token', $token)
            ->where('code', $code)
            ->first();

        if (!$reset) {
            return back()->with('fail', 'Hibás kód vagy érvénytelen link.');
        }

        if ($reset->expires_at && $reset->expires_at->isPast()) {
            return back()->with('fail', 'A jelszó-visszaállító kód lejárt.');
        }

        // Jelszó frissítése
        User::where('email', $reset->email)->update([
            'password' => Hash::make($request->opassword),
        ]);

        $reset->delete();

        return redirect()->route('success', ['token' => $token]);
    }

    public function Success()
    {
        return view('success');
    }
}
