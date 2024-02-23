import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginPageComponent } from './login-page/login-page.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { RouterModule, Routes } from '@angular/router';
import { PasswordComponent } from './login-page/password/password.component';


const routes: Routes = [
  { path: 'loginPage', component: LoginPageComponent },
  { path: 'forgotPassword', component: ForgotPasswordComponent },
  { path: 'passwordPage', component: PasswordComponent}
];


@NgModule({
  declarations: [
    LoginPageComponent,
    ForgotPasswordComponent,
    PasswordComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})

export class AuthenticationModule { }
