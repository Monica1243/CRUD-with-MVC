import { Component } from '@angular/core';
import { Router } from '@angular/router';
import * as CryptoJS from 'crypto-js';

@Component({
  selector: 'login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})

export class LoginPageComponent {
  constructor(private router: Router) {}

  userData: string = '';
  errorMessage : string = '';
  encryptedData: string = '';
  countryCode: string = '';
  isContentVisible: boolean = false;
  value:string = 'number'

  toggleArrow(): void {
    const arrow = document.querySelector('.help .rotate') as HTMLElement;
    if (arrow) {
        arrow.classList.toggle('down');
    }
    const content = document.querySelector('.login-box .help .content');
    this.isContentVisible = !this.isContentVisible;
  }

  navigateToPassword(event: Event) {
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
          this.value = 'number';
          this.navigateToPass();
        }
      } 
      else {
        this.errorMessage = "Enter correct email address";
      }
    } 
    else {
      this.value = 'email';
      this.navigateToPass()
    }
  }

  navigateToPass(){
    this.encryptedData = CryptoJS.AES.encrypt(this.userData, 'ManVsWild').toString();
    this.router.navigate(['passwordPage'], { queryParams: { userData: this.encryptedData, value: this.value } });
  }
  
}
