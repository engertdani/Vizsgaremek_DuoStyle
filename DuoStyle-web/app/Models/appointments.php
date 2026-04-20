<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class appointments extends Model
{
    protected $table = 'appointments';
    protected $primaryKey = 'appointment_id';
    public $timestamps = false;

    public function User(){
        return $this->belongsTo(User::class, 'user_id', 'user_id');
    }
    public function Service()
    {
        return $this->belongsTo(services::class, 'service_id', 'service_id');
    }
    public function Employee()
    {
        return $this->belongsTo(employees::class, 'employee_id', 'employee_id');
    }

    protected $fillable = [
        'reminder_sent',
    ];
}
