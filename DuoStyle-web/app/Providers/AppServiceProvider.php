<?php

namespace App\Providers;

use Illuminate\Support\ServiceProvider;
use Illuminate\Support\Facades\View;
use Illuminate\Support\Facades\Auth;
use App\Models\salons;
use App\Models\employees;

class AppServiceProvider extends ServiceProvider
{
    public function boot(): void
    {
        View::composer('layout', function ($view) {

            $employees = employees::where('active', 1)
                ->inRandomOrder()
                ->first();

            $login_employee = null;

            if (Auth::check()) {
                $login_employee = employees::where('active', 1)
                    ->where('gender', Auth::user()->gender)
                    ->inRandomOrder()
                    ->first();
            }

            $view->with([
                'salons' => salons::all(),
                'employees' => $employees,
                'login_employee' => $login_employee
            ]);
        });
    }
}
