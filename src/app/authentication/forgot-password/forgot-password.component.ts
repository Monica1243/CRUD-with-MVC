import { Component } from '@angular/core';
import { Router } from '@angular/router';
import * as CryptoJS from 'crypto-js';


@Component({
  selector: 'forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent {
  userData: string = '';
  errorMessage: string = '';
  encryptedOTP!: string; 
  otp!: string;

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
    this.otp = Math.floor(100000 + Math.random() * 900000).toString();
    this.encryptedOTP = CryptoJS.AES.encrypt(this.otp, 'ManVsWild').toString();
    console.log(this.otp);
    this.router.navigate(['GenerateOTP'], { queryParams: {otp :  this.encryptedOTP }});
  }
}
