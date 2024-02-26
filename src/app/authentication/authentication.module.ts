import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { RouterModule, Routes } from '@angular/router';

import { LoginPageComponent } from './login-page/login-page.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { PasswordComponent } from './login-page/password/password.component';
import { RegistrationComponent } from './registration/registration.component';


const routes: Routes = [
  { path: 'loginPage', component: LoginPageComponent },
  { path: 'forgotPassword', component: ForgotPasswordComponent },
  { path: 'passwordPage', component: PasswordComponent},
  { path: 'RegistrationPage', component:RegistrationComponent}
];


@NgModule({
  declarations: [
    LoginPageComponent,
    ForgotPasswordComponent,
    PasswordComponent,
    RegistrationComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule],
  providers: [],
})

export class AuthenticationModule { }