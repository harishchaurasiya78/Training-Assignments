import { Component, signal } from '@angular/core';
import { EventListComponent } from "./components/event-list/event-list";

@Component({
  selector: 'app-root',
  imports: [EventListComponent],
  templateUrl: './app.html',
  styleUrl: './app.css',
  standalone: true
})
export class AppComponent {
  protected readonly title = signal('EventMgmtApp');
}
