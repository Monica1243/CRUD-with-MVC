import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Route, Router, RouterModule, Routes } from '@angular/router';

import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

//Define Routes

const routes: Routes = [
  {path: 'forgotPassword', component: ForgotPasswordComponent},
  {path: 'loginPage', component: LoginPageComponent}
  // {path: '**', component: NotFoundComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    ForgotPasswordComponent,
    HeaderComponent,
    FooterComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes) // <-- include for root routing
  ],
  exports: [RouterModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
