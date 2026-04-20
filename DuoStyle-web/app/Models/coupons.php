<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class coupons extends Model
{
    protected $table = "coupons";
    protected $primaryKey = "coupon_code";
    public $timestamps = false;
}
