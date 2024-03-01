import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { RouterModule, Routes } from '@angular/router';
import { ProdComponent } from './prod/prod.component';

const homeRoutes: Routes = [
  { path: 'HomePage', component:HomeComponent }, 
];

@NgModule({
  declarations: [HomeComponent, ProdComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(homeRoutes)
  ]
})
export class HomeModule { }
