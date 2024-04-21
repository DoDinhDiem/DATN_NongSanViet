import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CartService } from 'src/app/Service/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  isActive: boolean = false;

  cartItems: any[] = [];
  quantity = 0;
  totalPrice: number = 0;
  constructor(private cartService: CartService) {}

  ngOnInit() {
    this.cartService.loadCart();
    this.cartService.products$.subscribe((products) => {
      this.getQuantity();
      this.calculateTotalPrice();
      this.updateCart(products);
    });
    this.cartItems = this.cartService.getCartItem();
  }

  toggleDemoChanger() {
    this.isActive = !this.isActive;
  }

  getQuantity() {
    this.quantity = this.cartService.getQuantity();
  }

  calculateTotalPrice() {
    this.totalPrice = this.cartService.getTotalPrice();
  }

  removeFromCart(product: any) {
    this.cartService.removeProduct(product);
    this.cartItems = this.cartService.getCartItem();
    this.getQuantity();
    this.calculateTotalPrice();
  }

  updateCart(cartItems: any[]) {
    this.cartItems = cartItems;
    this.getQuantity();
    this.calculateTotalPrice();
  }
}
