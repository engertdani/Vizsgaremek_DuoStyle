<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use App\Models\evaluations;

class WelcomeController extends Controller
{
    public function Welcome(){
        $stars = evaluations::avg('star');
        return view('welcome',[
            'avgStars'      => $stars,
            'roundedStars' => round($stars),
            'lastEvaluations' => evaluations::with(['user:user_id,name'])
                                    ->where('public', 1)
                                    ->orderBy('evaluation_date', 'desc')
                                    ->take(3)
                                    ->get(),
        ]);
    }

    public function Evaluation(){
        if(Auth::check()){
            return view('evaluation');
        }
        else{
            return redirect('/');
        }
    }

    public function EvaluationBtn(request $req){
        $req->validate([
            'comment' => 'required|max:300|min:3',
            'rating' => 'required'
        ],[
            'comment.required' => 'A megjegyzés mező kitöltése kötelező.',
            'comment.max' => 'A megjegyzés nem lehet hosszabb 300 karakternél.',
            'comment.min' => 'A megjegyzésnek legalább 3 karakter hosszúnak kell lennie.',
            'rating.required' => 'Kérem válassza ki a csillagok számát a értékeléshez.',
        ]);

        $data = new evaluations();
        $data->user_id = Auth::user()->user_id;
        $data->evaluation_text = $req->comment;
        $data->star = $req->rating;
        if($req->has('is_public')){
            $data->public = 1;
        }
        else{
            $data->public = 0;
        }

        $data->save();
        return redirect('/')->with([
            "success" => "Köszönjük, hogy megosztotta velünk véleményét!"
        ]);
    }
}
