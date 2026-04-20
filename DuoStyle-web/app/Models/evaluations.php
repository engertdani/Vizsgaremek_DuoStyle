<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class evaluations extends Model
{
    protected $table = 'evaluations';
    protected $primaryKey = 'evaluation_id';
    public $timestamps = false;

    public function User()
    {
        return $this->belongsTo(User::class, 'user_id', 'user_id');
    }
}
