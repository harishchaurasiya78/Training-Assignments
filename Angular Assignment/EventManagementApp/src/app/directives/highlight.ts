import { Directive, ElementRef, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[appHighlight]'
})
export class HighlightDirective implements OnInit 
{
  @Input('appHighlight') price: number = 0;

  constructor(private el: ElementRef) {}

  ngOnInit() 
  {
    if (this.price > 2000) 
    {
      this.el.nativeElement.style.backgroundColor = '#e6f7ff';
    }
  }
}
