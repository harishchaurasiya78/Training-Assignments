import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CartItem } from './cart-item.model';
import { Product } from './product.model';

@Injectable({ providedIn: 'root' })
export class CartService {
  private cartItems: CartItem[] = [];
  private cartSubject = new BehaviorSubject<CartItem[]>([]);
  cart$ = this.cartSubject.asObservable();

  addToCart(product: Product) {
    const item = this.cartItems.find(i => i.productId === product.id);
    if (item) {
      if (item.quantity < product.stock) {
        item.quantity++;
      }
    } else {
      this.cartItems.push({ productId: product.id, name: product.name, price: product.price, quantity: 1 });
    }
    this.cartSubject.next([...this.cartItems]);
  }

  removeFromCart(productId: number) {
    this.cartItems = this.cartItems.filter(i => i.productId !== productId);
    this.cartSubject.next([...this.cartItems]);
  }

  updateQuantity(productId: number, quantity: number, stock: number) {
    const item = this.cartItems.find(i => i.productId === productId);
    if (item) {
      if (quantity > stock) {
        item.quantity = stock;
      } else if (quantity > 0) {
        item.quantity = quantity;
      }
    }
    this.cartSubject.next([...this.cartItems]);
  }

  checkout() {
    this.cartItems = [];
    this.cartSubject.next([]);
    return 'Checkout successful!';
  }
}