<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class order_products extends Model
{
    protected $table = "order_products";
    protected $primaryKey = "order_products_id";
    public $timestamps = false;

    public function variant()
    {
        return $this->belongsTo(products_variant::class, 'variant_id', 'variant_id');
    }
}
