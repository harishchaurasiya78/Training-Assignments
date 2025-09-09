import { createReducer, on } from '@ngrx/store';
import { addTask, updateTaskStatus, loadTasksSuccess, clearCompleted } from './task.actions';
import { initialTaskState } from './task.state';

export const taskReducer = createReducer(
  initialTaskState,
  on(loadTasksSuccess, (state, { tasks }) => ({ ...state, tasks })),
  on(addTask, (state, { title, description }) => ({
    ...state,
    tasks: [
      ...state.tasks,
      { id: Date.now().toString(), title, description, completed: false }
    ]
  })),
  on(updateTaskStatus, (state, { id, completed }) => ({
    ...state,
    tasks: state.tasks.map(t => t.id === id ? { ...t, completed } : t)
  })),
  on(clearCompleted, (state) => ({
    ...state,
    tasks: state.tasks.filter(t => !t.completed)
  }))
);
