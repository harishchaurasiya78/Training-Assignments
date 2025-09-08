import { Component, Input, NgModule } from '@angular/core';
import { Course } from '../../models/course';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.html',
  styleUrls: ['./course-detail.css'],
  imports: [CommonModule, FormsModule]
})
export class CourseDetailComponent {
  @Input() course: Course | null = null; // Property Binding target
}