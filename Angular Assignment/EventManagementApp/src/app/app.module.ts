import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app';
import { EventListComponent } from './components/event-list/event-list';
import { PriceFormatPipe } from './pipes/price-format-pipe';
import { HighlightDirective } from './directives/highlight';

@NgModule({
  declarations: [],
  imports: [
    AppComponent,
    BrowserModule,
    FormsModule,
    EventListComponent,
    PriceFormatPipe,
    HighlightDirective
  ],
  providers: [],
  //bootstrap: [AppComponent]
})

export class AppModule { }
