<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\WelcomeController;
use App\Http\Controllers\UserController;
use App\Http\Controllers\ReservationController;
use App\Http\Controllers\MassageController;
use App\Http\Controllers\ProfileController;
use App\Http\Controllers\EmployeeController;
use App\Http\Controllers\WebshopController;

// Főoldal nézete
Route::get('/', [WelcomeController::class, 'Welcome']);

// Bejelentkezés nézete és feldolgozása
Route::get('/login', [Usercontroller::class, 'Login']);
Route::post('/login', [UserController::class, 'LoginBtn']);

// Regisztráció nézete és feldolgozása
Route::get('/register', [Usercontroller::class, 'Register']);
Route::post('/register', [UserController::class, 'RegisterBtn']);

// E-mail cím megerősítése
Route::get('/verify/{token}', [UserController::class, 'EmailVerify']);

// Kijelentkezés feldolgozása
Route::get('/logout', [UserController::class, 'Logout']);

// Jelszó visszaállítás nézete és feldolgozása
Route::get('forgot-password', [UserController::class, 'ForgotPassword']);
Route::post('forgot-password', [UserController::class, 'ForgotPasswordBtn']);

// Jelszó visszaállítás tokennel nézete és feldolgozása
Route::get('/profile/reset-password/{token}', [UserController::class, 'ResetPassword']);
Route::post('/profile/reset-password/{token}', [UserController::class, 'ResetPasswordBtn']);

// Sikeres művelet nézete
Route::get('/success/{token}', [UserController::class, 'Success'])->name('success');
Route::get('/editprofile/success', [ProfileController::class, 'SuccessEd']);

// Barber foglalás nézete és feldolgozása
Route::get('/reservation/barber', [ReservationController::class, 'Barber']);
Route::post('/reservation/barber', [ReservationController::class, 'BarberBtn']);
Route::post('reservation/barber/submit', [ReservationController::class, 'SaveBtn']);

// Masszázs foglalás nézete és feldolgozása
Route::get('/reservation/massage', [MassageController::class, 'Massage']);
Route::post('/reservation/massage', [MassageController::class, 'MassageBtn']);
Route::post('reservation/massage/submit', [MassageController::class, 'SaveBtn']);

// Profil nézete, szerkesztése és műveletei
Route::get('/profile', [ProfileController::class, 'Profile']);
Route::post('/profile', [ProfileController:: class, 'PassEditBtn']);
Route::post('/profile/{id}/cancel', [ProfileController::class, 'CancelApp']);
Route::post('/profile/{id}/delete', [ProfileController:: class, 'DeleteProf']);

// Profil szerkesztése nézete és feldolgozása
Route::get('/editprofile/user_id={id}', [ProfileController:: class, 'EditProfile']);
Route::post('/editprofile/user_id={id}', [ProfileController:: class, 'EditBtn']);

// Munkatársak nézete és részletei
Route::get('/our_employees', [EmployeeController:: class, 'Employee']);
Route::get('/our_employees/name={p}', [EmployeeController::class, 'EmployeeDetails']);

// Értékelés írása nézete és feldolgozása
Route::get('/write_evaluation', [WelcomeController:: class, 'Evaluation']);
Route::post('/write_evaluation', [WelcomeController:: class, 'EvaluationBtn']);

//Webshop
Route::get('/webshop', [WebshopController::class, 'Webshop']);
Route::get('/webshop/product/{pn}', [WebshopController::class, 'Products']);
Route::get('/webshop/addcart', [WebshopController::class, 'Kosarba']);
Route::post('/webshop/cart/add', [WebshopController::class, 'addToCart']);
Route::delete('/webshop/cart/remove/{variantId}', [WebshopController::class, 'removeFromCart']);
Route::post('/webshop/cart/update', [WebshopController::class, 'updateCart']);
Route::post('/webshop/cart/clear', [WebshopController::class, 'clearCart']);
Route::get('/webshop/order', [WebshopController::class, 'Order']);
Route::post('/webshop/order', [WebshopController::class, 'OrderBtn']);
