import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType, ROOT_EFFECTS_INIT } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { addTask, updateTaskStatus, loadTasks, loadTasksSuccess, clearCompleted } from './task.actions';
import { withLatestFrom, map, tap, filter } from 'rxjs/operators';
import { selectAllTasks } from './task.selectors';
import { of } from 'rxjs';

const STORAGE_KEY = 'ngrx_tasks';

@Injectable()
export class TaskEffects {
  constructor(private actions$: Actions, private store: Store) {}

  // Load from localStorage on init
  init$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ROOT_EFFECTS_INIT, loadTasks),
      map(() => {
        try {
          const raw = localStorage.getItem(STORAGE_KEY);
          const tasks = raw ? JSON.parse(raw) : [];
          return loadTasksSuccess({ tasks });
        } catch {
          return loadTasksSuccess({ tasks: [] });
        }
      })
    )
  );

  // Persist to localStorage whenever tasks change
  persist$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(addTask, updateTaskStatus, clearCompleted),
        withLatestFrom(this.store.select(selectAllTasks)),
        tap(([_, tasks]) => {
          try {
            localStorage.setItem(STORAGE_KEY, JSON.stringify(tasks));
          } catch {}
        })
      ),
    { dispatch: false }
  );
}
