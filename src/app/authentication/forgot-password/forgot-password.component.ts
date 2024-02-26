import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent {
  userData: any;
  errorMessage: string = '';

  constructor(private router: Router){}

  navigateToPassword(event : Event){
    event.preventDefault();
    if (this.userData.length === 0) {
      this.errorMessage = "Enter your email or mobile phone number";
    } 
    else if (!/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(this.userData)) {
      if (/^\d+$/.test(this.userData)) {
        if(this.userData.length != 10){
          this.errorMessage = "Enter correct phone number";
        }
        else{
          this.navigate();
        }
      } 
      else {
        this.errorMessage = "Enter correct email address";
      }
    } 
    else {
      this.navigate()
    }
  }
  navigate(){
    this.router.navigate(['HomePage']);
  }
}
