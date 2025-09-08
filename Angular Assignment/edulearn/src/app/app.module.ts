import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app';
import { CourseListComponent } from './components/course-list/course-list';
import { CourseDetailComponent } from './components/course-detail/course-detail';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    NgModule,
    CommonModule,
    BrowserModule
  ],

  imports: [
    BrowserModule,
    FormsModule,
    AppComponent,
    CourseListComponent,
    CourseDetailComponent,
  ],
  providers: [],
  //bootstrap: [AppComponent]
})
export class AppModule {}