import { Component, Input } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {  
  isLoginOrReg : boolean = true;

  constructor(private router: Router) { 
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.isLoginOrReg = event.url.includes('/loginPage') || event.url.includes('/forgotPassword') || event.url.includes('/passwordPage'); 
      }
    });
  }
}
