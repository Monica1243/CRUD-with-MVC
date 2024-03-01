import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { ProductsService } from '../../services/products.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent {
  isLoginOrReg : boolean = true;

  constructor(private router: Router, private prodService: ProductsService){}

  ngOnInit(){
    this.prodService.changeHeader().then(isLogin =>{
      this.isLoginOrReg = isLogin
    });
  }
}
