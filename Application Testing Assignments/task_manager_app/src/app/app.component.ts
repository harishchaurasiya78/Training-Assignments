import { Component, OnInit } from '@angular/core';
import { TaskService } from './task.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  tasks: any[] = [];
  newTask = { title: '', description: '' };

  constructor(private taskService: TaskService) {}

  ngOnInit() {
    this.loadTasks();
  }

  loadTasks() {
    this.taskService.getTasks().subscribe({
      next: (data) => this.tasks = data,
      error: () => alert('Error fetching tasks')
    });
  }

  addTask() {
    if (!this.newTask.title || !this.newTask.description) return;
    this.taskService.addTask(this.newTask).subscribe({
      next: () => { this.loadTasks(); this.newTask = { title: '', description: '' }; },
      error: () => alert('Error adding task')
    });
  }

  deleteTask(id: number) {
    this.taskService.deleteTask(id).subscribe({
      next: () => this.loadTasks(),
      error: () => alert('Error deleting task')
    });
  }
}