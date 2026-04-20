<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\employees;
use App\Models\prices;

class EmployeeController extends Controller
{
    public function Employee(){
        return view('employee',[
            'employees' => employees::all()
        ]);
    }

    public function EmployeeDetails($p){
        $employeeId = employees::where('name', $p)
                                ->value('employee_id');
        return view('details',[
            'employee' => employees::where('name', $p)
                                    ->first(),
            'prices' => prices::where('prices.employee_id', $employeeId)
                    ->join('services', 'services.service_id', 'prices.service_id')
                    ->select('prices.price', 'services.name as service_name', 'services.service_id')
                    ->orderBy('services.service_id')
                    ->get()
        ]);
    }
}
