import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as CryptoJS from 'crypto-js';

@Component({
  selector: 'app-generate-otp',
  templateUrl: './generate-otp.component.html',
  styleUrls: ['./generate-otp.component.scss']
})
export class GenerateOtpComponent {
  otp!: string;
  decryptedOTP !: string;
  enteredOTP : string = '';
  errorMessage!:string;

  constructor(private route:ActivatedRoute, private router: Router){}

  ngOnInit() : void {
    this.route.queryParams.subscribe(params => {
      this.decryptedOTP = params["otp"];
    })
    this.otp = CryptoJS.AES.decrypt(this.decryptedOTP , "ManVsWild").toString(CryptoJS.enc.Utf8);
  }

  verifyOTP(){
    if (this.enteredOTP && this.otp) {
      if (this.enteredOTP.toString() == this.otp.toString()) {
        this.router.navigate(['ChangePassword']);
      } else {
        this.errorMessage = "Entered OTP does not match decrypted OTP";
      }
    } else {
      this.errorMessage = "Please enter OTP and decrypt it before verification";
    }
  }


}
