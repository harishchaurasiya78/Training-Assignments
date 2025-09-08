# EduLearn – Course Management SPA

## Setup
1. Install Node.js LTS and Angular CLI (`npm i -g @angular/cli`).
2. Install deps: `npm install`
3. Run: `ng serve -o`

## What This App Demonstrates
- **Component Architecture**: `AppComponent` (container), `CourseListComponent` (list), `CourseDetailComponent` (detail).
- **Property Binding**: `AppComponent` → `CourseDetailComponent` via `[course]`.
- **Event Binding**: `CourseListComponent` emits `selectCourse`, handled by `AppComponent` with `(selectCourse)`.
- **Two‑Way Binding**: `CourseDetailComponent` uses `[(ngModel)]` to edit `course.title` live.

## File Map
- `src/app/models/course.ts` – Course interface
- `src/app/app.module.ts` – Root module (imports `FormsModule`)
- `src/app/app.component.*` – Holds course array + selected course; wires list ↔ detail
- `src/app/components/course-list/*` – Displays courses + emits selection
- `src/app/components/course-detail/*` – Shows & edits selected course

## How Binding Works Together
1. Clicking **View Details** in the list triggers `(click)` → `selectCourse.emit(course)`.
2. `AppComponent` handles the event and sets `selectedCourse`.
3. `AppComponent` passes `selectedCourse` to detail via `[course]`.
4. Editing the title in detail uses `[(ngModel)]` and updates the **same object**, so the list title updates instantly without refresh.