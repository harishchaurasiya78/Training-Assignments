import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';

@Component({
  selector: 'app-notification',
  template: `
    <div class="notification" [ngClass]="type">
      <span>{{ message }}</span>
      <button class="close-btn" (click)="closeNotification()">✖</button>
    </div>
  `,
  styleUrls: ['./notification.component.css']
})
export class NotificationComponent implements OnInit {
  @Input() message: string = '';
  @Input() type: 'success' | 'error' | 'warning' | 'info' = 'info';
  @Input() autoDismiss: boolean = true;
  @Input() dismissTime: number = 3000;
  @Output() closed = new EventEmitter<void>();

  ngOnInit() {
    if (this.autoDismiss) {
      setTimeout(() => this.closeNotification(), this.dismissTime);
    }
  }

  closeNotification() {
    this.closed.emit();
  }
}
