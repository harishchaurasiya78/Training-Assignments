import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { addTask } from '../../store/task.actions';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-task-input',
  templateUrl: './task-input.component.html',
  styleUrls: ['./task-input.component.css']
})
export class TaskInputComponent {
  form = this.fb.group({
    title: ['', [Validators.required, Validators.maxLength(120)]],
    description: ['']
  });

  constructor(private store: Store, private fb: FormBuilder) {}

  submit() {
    if (this.form.valid) {
      const { title, description } = this.form.value;
      this.store.dispatch(addTask({ title: title!, description: description || '' }));
      this.form.reset({ title: '', description: '' });
    }
  }
}
