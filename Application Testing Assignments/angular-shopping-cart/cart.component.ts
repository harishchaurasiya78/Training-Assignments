import { Component } from '@angular/core';
import { CartService } from './cart.service';
import { CartItem } from './cart-item.model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {
  cartItems: CartItem[] = [];

  constructor(private cartService: CartService) {
    this.cartService.cart$.subscribe(items => this.cartItems = items);
  }

  removeItem(id: number) {
    this.cartService.removeFromCart(id);
  }

  updateQuantity(id: number, quantity: string, stock: number) {
    this.cartService.updateQuantity(id, +quantity, stock);
  }

  checkout() {
    alert(this.cartService.checkout());
  }
}