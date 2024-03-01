import { Component } from '@angular/core';
import { Router } from '@angular/router';
import * as CryptoJS from 'crypto-js';
import { UserDetails } from 'src/app/shared/models/user-details.models';
import { UserDetailService } from 'src/app/shared/services/user-detail.service';


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
  value!:string;
  phoneNumber !:string;
  dbPassword!:UserDetails | null;

  constructor(private router: Router,private userD: UserDetailService){}

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
          this.value = 'number'
          this.navigateOTP();
        }
      } 
      else {
        this.errorMessage = "Enter correct email address";
      }
    } 
    else {
      this.value = 'email'
      this.navigateOTP()
    }
  }
  
  navigateOTP(){
    this.userD.VerifyNumber(this.userData, this.value).then(data => {
      if(data == this.userData){
        this.userD.userData = data;
        this.userD.value = this.value;
        this.navi();
      }
      else{
        this.errorMessage = "This is not a valid email or phone number"
      }
      }).catch(error => {
        console.error('An error occurred:', error);
      });      
  }

  navi(){
    this.otp = Math.floor(100000 + Math.random() * 900000).toString();
    this.encryptedOTP = CryptoJS.AES.encrypt(this.otp, 'ManVsWild').toString();
    console.log(this.otp);
    this.router.navigate(['GenerateOTP'], { queryParams: {otp :  this.encryptedOTP }});
  }
}
