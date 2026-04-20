<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Carbon\Carbon;

class salons extends Model
{
    protected $table = 'salons';
    public $primaryKey = 'salon_id';
    public function getOpenTimeAttribute($value)
    {
        return Carbon::createFromFormat('H:i:s', $value)->format('H:i');
    }

    public function getCloseTimeAttribute($value)
    {
        return Carbon::createFromFormat('H:i:s', $value)->format('H:i');
    }
}
