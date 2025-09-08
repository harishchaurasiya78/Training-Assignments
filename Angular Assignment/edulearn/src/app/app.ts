import { Component } from '@angular/core';
import { Course } from './models/course';
import { CourseDetailComponent } from "./components/course-detail/course-detail";
import { CourseListComponent } from "./components/course-list/course-list";

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
  imports: [CourseDetailComponent, CourseListComponent]
})
export class AppComponent {
  title = 'EduLearn – Course Manager';

  courses: Course[] = [
    { id: 1, title: 'Angular Fundamentals', category: 'Web', durationHours: 12, level: 'Beginner' },
    { id: 2, title: 'TypeScript Essentials', category: 'Programming', durationHours: 8, level: 'Beginner' },
    { id: 3, title: 'RxJS in Practice', category: 'Web', durationHours: 10, level: 'Intermediate' },
    { id: 4, title: 'Advanced Angular Patterns', category: 'Web', durationHours: 14, level: 'Advanced' }
  ];

  selectedCourse: Course | null = null;

  onCourseSelected(course: Course) {
    this.selectedCourse = course; 
  }
}