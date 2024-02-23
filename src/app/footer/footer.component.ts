import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent {
  isLoginOrReg : boolean = true;

  constructor(private router: Router) { 
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.isLoginOrReg = event.url.includes('/loginPage') || event.url.includes('/forgotPassword'); 
      }
    });
  }
}
