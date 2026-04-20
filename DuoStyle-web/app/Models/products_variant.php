<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class products_variant extends Model
{
        protected $table = "product_variant";
        protected $primaryKey = "variant_id";
        public $timestamps = false;

        public function Products(){
            return $this->belongsTo(products::class, 'pn','pn');
        }
}
