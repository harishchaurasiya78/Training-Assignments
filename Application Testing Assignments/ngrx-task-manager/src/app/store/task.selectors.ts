import { createSelector, createFeatureSelector } from '@ngrx/store';
import { TaskState } from './task.state';

export const selectTaskState = createFeatureSelector<TaskState>('tasks');

export const selectAllTasks = createSelector(selectTaskState, state => state.tasks);

export const selectCompletedTasks = createSelector(selectAllTasks, tasks => tasks.filter(t => t.completed));

export const selectActiveTasks = createSelector(selectAllTasks, tasks => tasks.filter(t => !t.completed));
