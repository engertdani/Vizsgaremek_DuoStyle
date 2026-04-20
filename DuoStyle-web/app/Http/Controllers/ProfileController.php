<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use App\Models\User;
use Illuminate\Validation\Rules\Password;
use Illuminate\Support\Facades\Hash;
use Carbon\Carbon;
use App\Models\appointments;
use App\Models\order;
use App\Models\order_products;
use App\Models\variant;
use App\Models\products_variant;
use App\Models\prices;

class ProfileController extends Controller
{
    public function Profile(){
        if(Auth::check()){
            return view('profile',[
                'activeBookings' => appointments::with(['service','employee'])
                                                ->where('user_id', Auth::user()->user_id)
                                                ->where('active', 1)
                                                ->where(function ($query) {
                                                    $query->where('appointment_date', '>', now()->toDateString())
                                                        ->orWhere(function ($q) {
                                                            $q->where('appointment_date', now()->toDateString())
                                                                ->where('start_time', '>', now()->format('H:i:s'));
                                                        });
                                                })
                                                ->get(),
                'closedBookings'  => appointments::with(['service','employee'])
                                                ->where('user_id', Auth::user()->user_id)
                                                ->where('appointment_date','<',now()->format('Y-m-d'))
                                                ->where('active', 1)
                                                ->get(),
                'cancelledBookings'  => appointments::with(['service','employee'])
                                                ->where('user_id', Auth::user()->user_id)
                                                ->where('active', 0)
                                                ->get(),
                'orders' => Order::with([
                                'orderProducts' => function ($q) {
                                    $q->select('order_products_id', 'order_id', 'variant_id', 'quantity', 'unit_price');
                                },
                                'orderProducts.variant' => function ($q) {
                                    $q->select('variant_id', 'pn', 'size', 'price');
                                },
                                'orderProducts.variant.Products' => function ($q) {
                                    $q->select('pn', 'name');
                                },
                            ])
                            ->where('user_id', Auth::user()->user_id)
                            ->orderByDesc('ordered_at')
                            ->get(),
        ]);
        }
        else{
            return redirect('/');
        }
    }

    // Más felhasználó adatváltoztatásának tiltása
    public function EditProfile($id)
    {
        abort_unless(
            Auth::check() && Auth::id() === (int) $id,
            403
        );

        return view('editprofile',[
            'names' => explode(' ', Auth::user()->name),
            'date' => explode('-', Auth::user()->born_date)
        ]);
    }

    public function EditBtn(Request $req){
        $req->validate([
            'lastname' => 'required|min:2|max:50',
            'firstname' => 'required|min:3|max:50',
            'edit_email' => 'required|email:rfc,dns|max:100',
            'tel' => 'required|numeric|digits_between:8,9',
            'year' => 'required|numeric|min:1960|max:'.(date('Y') - 14),
            'month' => 'required|numeric|min:1|max:12',
            'day' => 'required|numeric|min:1|max:31',
        ],[
            'lastname.required' => 'A vezetéknév megadása kötelező.',
            'lastname.min' => 'A vezetéknév legalább :min karakter hosszú legyen.',
            'lastname.max' => 'A vezetéknév legfeljebb :max karakter hosszú lehet.',

            'firstname.required' => 'A keresztnév megadása kötelező.',
            'firstname.min' => 'A keresztnév legalább :min karakter hosszú legyen.',
            'firstname.max' => 'A keresztnév legfeljebb :max karakter hosszú lehet.',

            'edit_email.required' => 'Az e-mail cím megadása kötelező.',
            'edit_email.email' => 'Az e-mail cím formátuma nem megfelelő.',
            'edit_email.unique' => 'Ez az e-mail cím már használatban van.',
            'edit_email.max' => 'Az e-mail cím legfeljebb :max karakter hosszú lehet.',

            'tel.required' => 'A telefonszám megadása kötelező.',
            'tel.numeric' => 'A telefonszám csak számokat tartalmazhat.',
            'tel.digits_between' => 'A telefonszám :min és :max számjegy között lehet.',

            'year.required' => 'A születési év megadása kötelező.',
            'year.numeric' => 'A születési év csak szám lehet.',
            'year.min' => 'A születési év nem lehet kisebb mint :min.',
            'year.max' => 'Legalább 14 évesnek kell lenned a regisztrációhoz.',

            'month.required' => 'A születési hónap megadása kötelező.',
            'month.numeric' => 'A születési hónap csak szám lehet.',
            'month.min' => 'A hónap minimum :min lehet.',
            'month.max' => 'A hónap maximum :max lehet.',

            'day.required' => 'A születési nap megadása kötelező.',
            'day.numeric' => 'A születési nap csak szám lehet.',
            'day.min' => 'A nap minimum :min lehet.',
            'day.max' => 'A nap maximum :max lehet.',
        ]);

        $birthDate = Carbon::createFromDate(
            $req->year,
            $req->month,
            $req->day
        );

        // Adatbázisba mentés
        $data = user::where('user_id', Auth::user()->user_id)->first();
        $data->name         = $req->lastname.' '.$req->firstname;
        $data->email        = $req->edit_email;
        $data->tel          = '+36'.$req->tel;
        $data->born_date    = $birthDate->format('Y-m-d');

        $data->save();

        return redirect('/editprofile/success');
    }

    public function SuccessEd(){
        return view('success');
    }

    public function PassEditBtn(Request $req){
        $req->validate([
            'opassword' => 'required',
            'password' => [
                            'required',
                            Password::min(8)
                            ->letters()
                            ->numbers()
                            ->mixedCase()
                            ->symbols()
                            ->uncompromised(),
                            'confirmed'
                        ],
        ],[
            '*.required'            => 'Kötelező kitölteni!',
            'password.confirmed'    => 'A jelszó nem egyezik!',
            'password.min'          => 'A jelszónak legalább 8 karakternek kell lennie!',
            'password.letters'      => 'A jelszónak kell betűt tartalmaznia!',
            'password.numbers'      => 'A jelszónak kell számot tartalmaznia!',
            'password.mixed'        => 'A jelszónak kis és nagybetűt is kell tartalmaznia!',
            'password.symbols'      => 'A jelszónak legalább 1 speciális karaktert kell tartalmaznia!',
            'password.uncompromised'=> 'Ez a jelszó már szerepelt korábbi adatvédelmi incidensekben, ezért nem biztonságos!'
        ]);

        // Jelszómodósítás és ellenőrzés
        if (!Hash::check($req->opassword, Auth::user()->password)) {
            return redirect('/profile')
                ->with(['fail' => 'A jelenlegi jelszó nem megfelelő!']);
        }

        if (Hash::check($req->password, Auth::user()->password)) {
            return redirect('/profile')
                ->with(['fail' => 'Nem adhatja meg újra a korábbi jelszavát!']);
        }

        Auth::user()->update([
            'password' => Hash::make($req->password)
        ]);

        return redirect('/profile')
            ->with(['success' => 'Sikeresen megváltoztatta a jelszavát!']);
    }

    public function CancelApp($id){
        $data = appointments::where('appointment_id', $id)
            ->where('user_id', Auth::user()->user_id)
            ->firstOrFail();
        $data->active = 0;
        $data->Save();
        return redirect('/profile')
            ->with(['success' => 'Sikeresen lemondta az időpontot!']);
    }

    public function DeleteProf($id){
        $user = User::where('user_id', $id)
                    ->first();
        if($user){
            $user->active = 0;
            $user->save();

            appointments::where('user_id', $id)
                ->update(['active' => 0]);
        }
        return redirect('/logout');
    }
}
