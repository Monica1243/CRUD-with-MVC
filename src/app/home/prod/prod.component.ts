import { Component } from '@angular/core';
import { ProductsService } from 'src/app/shared/services/products.service';

@Component({
  selector: 'app-prod',
  templateUrl: './prod.component.html',
  styleUrls: ['./prod.component.scss']
})
export class ProdComponent {
  products: any[] = [];
  selectedItems: number[] = [];
  cartAdded: boolean = false;

  constructor(private productsService: ProductsService){}
  
  ngOnInit(){
    this.products = this.productsService.getAllProducts();
  }

  addItemToCart(item: any) {
    this.productsService.addToCart(item);
    item.cartAdded = !item.cartAdded;
    console.log(item.cartAdded);
  }

  removeItemToCart(item: any) {
    this.productsService.removeFromCart(item);
    item.cartAdded = !item.cartAdded;
    console.log(item.cartAdded);
  }
}
