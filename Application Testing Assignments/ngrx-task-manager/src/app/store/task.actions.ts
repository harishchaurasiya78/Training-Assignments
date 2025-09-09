import { createAction, props } from '@ngrx/store';
import { Task } from '../models/task.model';

export const loadTasks = createAction('[Task] Load Tasks From Storage');
export const loadTasksSuccess = createAction('[Task] Load Tasks Success', props<{ tasks: Task[] }>());

export const addTask = createAction('[Task] Add Task', props<{ title: string; description: string }>());

export const updateTaskStatus = createAction('[Task] Update Task Status', props<{ id: string; completed: boolean }>());

export const clearCompleted = createAction('[Task] Clear Completed Tasks');

// Internal - persist side effects completed
export const persistSuccess = createAction('[Task] Persist Success');
