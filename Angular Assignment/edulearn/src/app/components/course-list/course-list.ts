import { Component } from '@angular/core';
import { Course } from '../../models/course';
import { Input, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-course-list',
  imports: [CommonModule],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseListComponent {
  @Input() courses: Course[] = [];
  @Output() selectCourse = new EventEmitter<Course>();

  viewDetails(course: Course) {
    this.selectCourse.emit(course); // Event Binding target in parent
  }
}
