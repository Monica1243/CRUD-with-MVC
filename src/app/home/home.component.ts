import { Component } from '@angular/core';
import { ProductsService } from '../shared/services/products.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  products: any[] = [];
  selectedItems: number[] = [];

  constructor(private router: Router, private productsService: ProductsService) {}

  ngOnInit(){
    this.products = this.productsService.getAllProducts();
  }
  
  addItemToCart(item: any) {
    this.productsService.addToCart(item);
    console.log(item);
  }

}
