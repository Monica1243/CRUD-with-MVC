import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as CryptoJS from 'crypto-js';

@Component({
  selector: 'app-password',
  templateUrl: './password.component.html',
  styleUrls: ['./password.component.scss']
})
export class PasswordComponent {
  userData:string = '';
  passwordError: string = '';
  decryptedData : string = '';
  password: string = '';
  showPassword: boolean = false;

  constructor(private route:ActivatedRoute){}

  ngOnInit() : void {
    this.route.queryParams.subscribe(params => {
      this.decryptedData = params["userData"];
    })
    this.userData = CryptoJS.AES.decrypt(this.decryptedData , "ManVsWild").toString(CryptoJS.enc.Utf8);
  }

  togglePasswordVisibility(): void {
    if(this.password.length != 0){
      console.log(this.showPassword);
      this.showPassword = !this.showPassword;
    }
  }
}
