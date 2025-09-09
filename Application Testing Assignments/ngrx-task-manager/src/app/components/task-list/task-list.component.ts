import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Task } from '../../models/task.model';
import { selectAllTasks } from '../../store/task.selectors';
import { updateTaskStatus, clearCompleted } from '../../store/task.actions';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent {
  tasks$: Observable<Task[]> = this.store.select(selectAllTasks);

  constructor(private store: Store) {}

  toggle(task: Task) {
    this.store.dispatch(updateTaskStatus({ id: task.id, completed: !task.completed }));
  }

  clearCompleted() {
    this.store.dispatch(clearCompleted());
  }
}
