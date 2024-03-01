import { NgModule, OnChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './layouts/footer/footer.component';
import { HeaderComponent } from './layouts/header/header.component';
import { SecondHeaderComponent } from './layouts/header/second-header/second-header.component'; 
import { LastFooterComponent } from './layouts/last-footer/last-footer.component';  


@NgModule({
  declarations: [
    FooterComponent,
    HeaderComponent,
    SecondHeaderComponent,
    LastFooterComponent
  ],
  exports:[
    FooterComponent,
    HeaderComponent,
    SecondHeaderComponent,
    LastFooterComponent
  ],
  imports: [
    CommonModule
  ],
  providers:[
  ]
})
export class SharedModule { }
