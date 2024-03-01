import { Component, DoCheck } from '@angular/core';
import { Router } from '@angular/router';
import { ProductsService } from '../../services/products.service';
import { UserDetailService } from '../../services/user-detail.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {  
  
  isLoginOrReg: boolean = true;
  userName!:string;
  constructor(private router: Router, private prodService: ProductsService, private userD: UserDetailService) {}

  ngDoCheck(): void {
    this.prodService.changeHeader().then(isLoginOrReg => {
      this.isLoginOrReg = isLoginOrReg;
    });
    this.userName = this.userD.userName;
  }

  navigate(){
    this.router.navigate(['/CartPage']);
  }
}
