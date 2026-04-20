<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Order;
use App\Models\order_products;
use App\Models\products;
use App\Models\products_variant;
use App\Models\coupons;
use App\Models\addresses;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Mail;
use App\Mail\OrderMail;

class WebshopController extends Controller
{
public function Webshop(Request $request)
{
    $data = products::select(
            'products.pn',
            'products.name',
            'products.description',
            'product_variant.variant_id',
            'product_variant.stock',
            'product_variant.active',
            'product_variant.price'
        )
        ->join('product_variant', function ($join) {
            $join->on('product_variant.pn', '=', 'products.pn')
                ->whereRaw('product_variant.variant_id = (
                    SELECT MIN(variant_id)
                    FROM product_variant pv
                    WHERE pv.pn = products.pn
                )');
        });


    if ($request->filled('search')) {
        $search = $request->search;

        $data->where(function ($query) use ($search) {
            $query->where('products.name', 'LIKE', '%'.$search.'%')
                  ->orWhere('products.description', 'LIKE', '%'.$search.'%');
        });
    }

    $sort = $request->get('sort', 'default');

    switch ($sort) {
        case 'name_asc':
            $data->orderBy('products.name', 'asc');
            break;

        case 'name_desc':
            $data->orderBy('products.name', 'desc');
            break;

        case 'price_asc':
            $data->orderBy('product_variant.price', 'asc');
            break;

        case 'price_desc':
            $data->orderBy('product_variant.price', 'desc');
            break;

        case 'barber':
            $data->where('products.pn', 'like', 'FOD%');
            break;

        case 'massage':
            $data->where('products.pn', 'like', 'MAS%');
            break;

        default:
            $data->orderBy('products.pn', 'asc');
            break;
    }

    $products = $data->get();

    foreach ($products as $product) {
        $product->dbvarians = products_variant::where('pn', $product->pn)->count();
    }

    return view('webshop', [
        'products' => $products,
        'product_variant' => products_variant::all()
    ]);
}


    public function Products($pn){
    $product = products::findOrFail($pn);
    $variants = products_variant::where('pn', $pn)->get();

    $variantId = request()->get('variant_id');
    $selectedVariant = $variantId
        ? $variants->where('variant_id', $variantId)->first()
        : $variants->where('active', 1)->first();

    if (!$selectedVariant) {
        $selectedVariant = $variants->first();
    }

    // Kosár session lekérdezése
    $cart = session()->get('cart', []);

    // Ellenőrizzük, hogy van-e a kosárban a kiválasztott variáns
    $inCartQuantity = isset($cart[$selectedVariant->variant_id]) ? $cart[$selectedVariant->variant_id]['quantity'] : 0;

    return view('products',[
        'products' => $product,
        'product_variants' => $variants,
        'selected_variant' => $selectedVariant,
        'in_cart_quantity' => $inCartQuantity
    ]);
}
    public function Kosarba(){
        $cart = session()->get('cart', []);

        if (empty($cart)) {
            return view('addcart', [
                'cartItems' => [],
                'total' => 0
            ]);
        }
        $db = 0;
        $cartItems = [];
        $total = 0;

        foreach ($cart as $variantId => $item) {
            $variant = products_variant::find($variantId);

            if ($variant) {
                $product = products::where('pn', $variant->pn)->first();

                $cartItems[] = [
                    'variant_id' => $variantId,
                    'pn' => $variant->pn,
                    'product_name' => $product ? $product->name : 'Ismeretlen termék',
                    'stock' => $variant->stock,
                    'size' => $variant->size,
                    'price' => $variant->price,
                    'quantity' => $item['quantity'],
                    'subtotal' => $variant->price * $item['quantity'],
                    'image' => asset('assets/img/' . $variant->pn . '.png')
                ];


                $total += $variant->price * $item['quantity'];
            }
        }

        return view('addcart', [
            'cartItems' => $cartItems,
            'total' => $total
        ]);
    }

    public function addToCart(Request $req)
{

    $req->validate([
        'variant_id' => 'required|exists:product_variant',
        'quantity' => 'required|integer|min:0'
    ]);

    $variant = products_variant::find($req->variant_id);

    // Ha 0-t küldött, akkor távolítsuk el a kosárból
    if ($req->quantity == 0) {
        $cart = session()->get('cart', []);
        unset($cart[$req->variant_id]);
        session()->put('cart', $cart);

        return redirect()->back()->with('success', 'Termék eltávolítva a kosárból!');
    }

    // Ellenőrizzük a készletet
    if ($variant->stock < $req->quantity) {
        return back()->with('error', 'Nincs elég készlet! Maximum ' . $variant->stock . ' db rendelhető.');
    }

    $cart = session()->get('cart', []);

    $cart[$req->variant_id] = [
        'quantity' => $req->quantity,
        'added_at' => now()
    ];

    session()->put('cart', $cart);

    return redirect('/webshop')->with('success', 'Kosár frissítve!');
}


    public function removeFromCart($variantId)
    {
        $cart = session()->get('cart', []);

        if (isset($cart[$variantId])) {
            unset($cart[$variantId]);
            session()->put('cart', $cart);
        }

        return back()->with('success', 'Termék eltávolítva a kosárból!');
    }

    public function updateCart(Request $req)
    {
        $req->validate([
            'variant_id' => 'required|exists:product_variant',
            'quantity' => 'required|integer|min:1'
        ]);

        if ($req->quantity == 0) {
            return $this->removeFromCart($req->variant_id);
        }

        $variant = products_variant::findOrFail($req->variant_id);

        if ($variant->stock < $req->quantity) {
            return back()->with('error', 'Nincs elég készlet! Maximum ' . $variant->stock . ' db rendelhető.');
        }

        $cart = session()->get('cart', []);

        if (isset($cart[$req->variant_id])) {
            $cart[$req->variant_id]['quantity'] = $req->quantity;
            session()->put('cart', $cart);
        }

        return redirect('/webshop/addcart')->with('success', 'Kosár frissítve!');

    }

    public function clearCart()
    {
        session()->forget('cart');
        return redirect('/webshop/addcart')->with('success', 'Kosár kiürítve!');
    }


    public function Order()
{
    $cart = session()->get('cart', []);

    if (empty($cart)) {
        return view('order', [
            'cartItems' => [],
            'total' => 0
        ]);
    }

    $cartItems = [];
    $total = 0;

    foreach ($cart as $variantId => $item) {
        $variant = products_variant::find($variantId);

        if ($variant) {
            $product = products::where('pn', $variant->pn)->first();

            $subtotal = $variant->price * $item['quantity'];
            $total += $subtotal;

            $cartItems[] = [
                'variant_id' => $variantId,
                'pn' => $variant->pn,
                'product_name' => $product ? $product->name : 'Ismeretlen termék',
                'size' => $variant->size,
                'price' => $variant->price,
                'quantity' => $item['quantity'],
                'subtotal' => $subtotal,
                'image' => asset('assets/img/' . $variant->pn . '.png')
            ];
        }
    }

    return view('order', [
        'cartItems' => $cartItems,
        'total' => $total
    ]);
}

public function OrderBtn(Request $req)
{
    $cart = session()->get('cart', []);

    if (empty($cart)) {
        return redirect('/webshop/order')->with('error', 'A kosár üres!');
    }

    $req->validate([
        'zip' => 'required|digits:4',
        'city' => 'required|max:100',
        'street' => 'required|max:255',
        'coupon_code' => 'nullable|exists:coupons,coupon_code',
        'shipping_method' => 'required',
        'paying_method' => 'required',
        'note' => 'nullable|max:100'
    ],[
        'zip.required' => 'A cím megadása kötelező!',
        'zip.digits' => 'Az irányítószám 4 számjegy lehet!',
        'city.required' => 'A város megadása kötelező!',
        'street.required' => 'Az utca megadása kötelező!',
        'paying_method.required' => 'A fizetési mód megadása kötelező!',
        'shipping_method.required' => 'A szállítási mód megadása kötelező!',
        'address.max' => 'A szállítási cím nem lehet hosszabb :max karakternél!',
        'coupon_code.exists' => 'A megadott kuponkód érvénytelen!',
        'note.max' => 'A megjegyzés nem lehet hosszabb :max karakternél!'
    ]);

    if ($req->filled('coupon_code')) {
        $coupon = coupons::where('coupon_code', $req->coupon_code)->first();

        if ($coupon->active != 1) {
            return redirect()->back()->withErrors(['coupon_code' => 'Ez a kuponkód már fel lett használva!'])->withInput();
        }
    }

    $cartItems = [];
    $total = 0;

    foreach ($cart as $variantId => $item) {
        $variant = products_variant::find($variantId);

        if ($variant) {
            $product = products::where('pn', $variant->pn)->first();

            $subtotal = $variant->price * $item['quantity'];
            $total += $subtotal;

            $cartItems[] = [
                'variant_id' => $variantId,
                'pn' => $variant->pn,
                'product_name' => $product ? $product->name : 'Ismeretlen termék',
                'size' => $variant->size,
                'price' => $variant->price,
                'quantity' => $item['quantity'],
                'subtotal' => $subtotal,
                'image' => asset('assets/img/' . $variant->pn . '.png')
            ];
        }
    }

    $order = new Order();
    $order->user_id = Auth::user()->user_id;
    if ($req->phone != Auth::user()->tel) {
        $order->tel = $req->phone;
    } else {
        $order->tel = null;
    }
        $address = addresses::where('zip_code', $req->zip)
                  ->where('city', $req->city)
                  ->where('street', $req->street)
                  ->first();

    if (!$address) {
        $address = new addresses();
        $address->zip_code = $req->zip;
        $address->city     = $req->city;
        $address->street   = $req->street;
        $address->save();
    }

    $order->address_id = $address->address_id;
    $order->shipping_method = $req->shipping_method;
    $order->paying_method = $req->paying_method;
    $order->coupon_code = $req->coupon_code;
    $order->note = $req->note;
    $order->ordered_at = now();

    $finalTotal = $total;

    $shippingCost = 0;
    if ($finalTotal < 10000) {
        $shippingCost = 1500;
    }
    $finalTotal += $shippingCost;

    // Kedvezmény számítás ha van kupon
    if ($req->filled('coupon_code')) {
        $coupon = coupons::where('coupon_code', $req->coupon_code)
            ->where('active', 1)
            ->first();

        if ($coupon && $coupon->discount_amount > 0) {
            $discountAmount = ($finalTotal * $coupon->discount_amount / 100);
            $finalTotal -= $discountAmount;

            coupons::where('coupon_code', $req->coupon_code)
                ->update(['active' => 0]);
        }
    }

    $order->total_amount = $finalTotal;
    $order->save();

    foreach ($cartItems as $item) {
        $order_products = new order_products();
        $order_products->order_id = $order->order_id;
        $order_products->variant_id = $item['variant_id'];
        $order_products->quantity = $item['quantity'];
        $order_products->unit_price = $item['price'];
        $order_products->save();

        $variant = products_variant::find($item['variant_id']);
        if ($variant) {
            $variant->stock = $variant->stock - $item['quantity'];
            $variant->save();
        }
    }

    // email küldés
    Mail::to(Auth::user()->email)->send(
        new OrderMail($order, $cartItems, $order->total_amount)
    );

    // kosár ürítés
    session()->forget('cart');

    return redirect('/webshop')->with('success', 'Rendelés sikeresen leadva!');
}

}
