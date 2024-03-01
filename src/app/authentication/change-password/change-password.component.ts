import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserDetailService } from 'src/app/shared/services/user-detail.service';

@Component({
  selector: 'change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent {
  password!:string;
  retypedPassword!:string;
  constructor(private userD: UserDetailService, private router: Router){}

  change(){
    if((this.password.length >= 6 && this.retypedPassword.length >=6) && this.password===this.retypedPassword){
      this.userD.changePass(this.userD.userData,this.password).then(data =>{
        this.router.navigate(['loginPage']);
      })
    }
  }
}

