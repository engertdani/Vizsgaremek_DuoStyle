<?php

namespace App\Http\Middleware;

use Closure;
use Illuminate\Http\Request;
use Symfony\Component\HttpFoundation\Response;
use Illuminate\Support\Facades\Auth;

class SessionTimeout
{
    private int $timeoutSeconds = 15 * 60; // 15 perc
    public function handle(Request $request, Closure $next): Response
    {
        if(Auth::check()){
            $last = session('last_activity_at');

            // Ellenőrizzük az inaktivitás időtartamát
            if($last && now()->diffInSeconds($last) >= $this->timeoutSeconds){
                Auth::logout();
                session()->invalidate();
                $request->session()->regenerateToken();

                // Átirányítás bejelentkezési oldalra
                return redirect('/');
            }
            session(['last_activity_at' => now()]);
        }
        return $next($request);
    }
}
