import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { RouterModule, Routes } from '@angular/router';
import { HomeModule  } from '../home/home.module';
import { ProductsService } from '../shared/services/products.service';
import { LoginPageComponent } from './login-page/login-page.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { PasswordComponent } from './login-page/password/password.component';
import { RegistrationComponent } from './registration/registration.component';
import { GenerateOtpComponent } from './forgot-password/generate-otp/generate-otp.component';
import { ChangePasswordComponent } from './change-password/change-password.component';


const routes: Routes = [
  { path: 'loginPage', component: LoginPageComponent },
  { path: 'forgotPassword', component: ForgotPasswordComponent },
  { path: 'passwordPage', component: PasswordComponent},
  { path: 'RegistrationPage', component:RegistrationComponent},
  { path: 'GenerateOTP', component:GenerateOtpComponent},
  { path: 'ChangePassword', component:ChangePasswordComponent}
];


@NgModule({
  declarations: [
    LoginPageComponent,
    ForgotPasswordComponent,
    PasswordComponent,
    RegistrationComponent,
    GenerateOtpComponent,
    ChangePasswordComponent
  ],
  imports: [
    CommonModule,
    HomeModule,
    FormsModule,
    SharedModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule],
  providers: [ProductsService],
})

export class AuthenticationModule { }
