<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Order extends Model
{
    protected $table = "order";
    protected $primaryKey = "order_id";
    public $timestamps = false;

    public function user()
    {
        return $this->belongsTo(User::class, 'user_id', 'user_id');
    }

    public function orderProducts()
    {
        return $this->hasMany(order_products::class, 'order_id', 'order_id');
    }
}


