<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class products extends Model
{
    protected $table = "products";
    protected $primaryKey = "products.pn";


    public function Variants(){
        return $this->hasMany(products_variant::class, 'pn', 'pn');
    }
}
