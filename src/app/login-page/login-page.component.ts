import { Component } from '@angular/core';

@Component({
  selector: 'login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})

export class LoginPageComponent {
  isContentVisible: boolean = false;

  toggleArrow(): void {
    const arrow = document.querySelector('.help .rotate') as HTMLElement;
    if (arrow) {
        arrow.classList.toggle('down');
    }

    const content = document.querySelector('.login-box .help .content');
    this.isContentVisible = !this.isContentVisible;
  }
}
