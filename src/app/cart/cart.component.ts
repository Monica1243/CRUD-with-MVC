import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductsService } from '../shared/services/products.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent {
  cartItems: any[];
  selectedItems: any[] = [];
  totalPrice :number = 0;
  quantity: number = 1;

  constructor(private productsService: ProductsService) {
    this.cartItems = this.productsService.getCartItems();
  }

  removeItem(index: number) {
    this.cartItems.splice(index, 1);
    // Update cart items after removal
    this.cartItems = this.productsService.getCartItems();
  }

  toggleSelected(item: any) {
    item.selected = !item.selected;
    this.updateSubtotal();
  }

  updateSubtotal() {
    this.selectedItems = this.cartItems.filter(item => item.selected);
  }

  calculateSubtotal() {
    return this.selectedItems.reduce((total, item) => total + (item.price - (item.price * (item.discountPercentage / 100))), 0).toFixed(2);
  }

  updateQuantity(index: number, quantity: number) {
    // Implement your logic to update quantity
  }
  
}
