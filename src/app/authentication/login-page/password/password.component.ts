import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as CryptoJS from 'crypto-js';
import { UserDetails } from 'src/app/shared/models/user-details.models';
import { UserDetailService } from 'src/app/shared/services/user-detail.service';

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
  value: string = '';

  constructor(private route:ActivatedRoute, private userD: UserDetailService, private router:Router){}

  ngOnInit() : void {
    this.route.queryParams.subscribe(params => {
      this.decryptedData = params["userData"];
      this.value = params["value"]
    })
    this.userData = CryptoJS.AES.decrypt(this.decryptedData , "ManVsWild").toString(CryptoJS.enc.Utf8);
  }

  togglePasswordVisibility() {
    if(this.password.length != 0){
      this.showPassword = !this.showPassword;
    }
  }

  navigateToHome(){
    this.userD.VerifyIdentity(this.userData, this.value,this.password).then(data => {
      if(typeof  data == "string"){
        this.userD.userName = data;
        this.router.navigate(['HomePage'])
      };
    }).catch(error => {
      this.passwordError = 'An error occurred:';
    });
  }
}
