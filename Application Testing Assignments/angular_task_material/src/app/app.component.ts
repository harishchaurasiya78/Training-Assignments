import { Component, OnInit } from '@angular/core';
import { TaskService } from './task.service';
import { MatSnackBar } from '@angular/material/snack-bar';

interface Task { userId?: number; id?: number; title: string; completed: boolean; }

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  tasks: Task[] = [];
  newTitle = '';
  loading = true;
  error = '';

  constructor(private taskService: TaskService, private snack: MatSnackBar) {}

  ngOnInit() { this.load(); }

  load() {
    this.loading = true;
    this.error = '';
    this.taskService.getTasks().subscribe({
      next: data => { this.tasks = data.map(t => ({ title: t.title, completed: t.completed, id: t.id })); this.loading = false; },
      error: () => { this.error = 'Failed to load tasks.'; this.loading = false; }
    });
  }

  addTask() {
    if (!this.newTitle.trim()) return;
    const t: Task = { title: this.newTitle.trim(), completed: false, id: Date.now() };
    this.tasks.unshift(t);
    this.newTitle = '';
    this.snack.open('Task added', undefined, { duration: 1200 });
  }

  toggle(task: Task) {
    task.completed = !task.completed;
  }

  completeAll() {
    this.tasks = this.tasks.map(t => ({ ...t, completed: true }));
    this.snack.open('All tasks completed', undefined, { duration: 1200 });
  }
}
