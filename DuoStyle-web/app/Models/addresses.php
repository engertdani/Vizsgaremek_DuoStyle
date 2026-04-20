<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class addresses extends Model
{
    protected $table = 'addresses';
    protected $primaryKey = 'address_id';
    public $timestamps = false;
}
