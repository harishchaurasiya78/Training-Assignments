import { Component, OnInit } from '@angular/core';
import { ProductService } from './product.service';
import { CartService } from './cart.service';
import { Product } from './product.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  error: string | null = null;

  constructor(private productService: ProductService, private cartService: CartService) {}

  ngOnInit() {
    this.productService.getProducts().subscribe({
      next: data => this.products = data,
      error: () => this.error = 'Failed to load products'
    });
  }

  addToCart(product: Product) {
    this.cartService.addToCart(product);
  }
}