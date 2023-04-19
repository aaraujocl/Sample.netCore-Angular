import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css'],
})
export class AlertComponent {
  @Input() childMessage: string = '';
  success: boolean = false;
  constructor() {
    if (this.childMessage == 'success') {
      this.success = true;
    }
  }
}
