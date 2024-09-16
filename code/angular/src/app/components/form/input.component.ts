import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-input',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './input.component.html',
})
export class InputComponent {

  @Input()
  class: string = '';

  @Input()
  type: string = '';

  @Input()
  id: string = '';

  @Input()
  name: string = '';

  @Input()
  ngModel: any;

  @Output()
  ngModelChange: EventEmitter<any> = new EventEmitter<any>();

  onModelChange(value: any) {
    this.ngModel = value;
    this.ngModelChange.emit(value);
  }
}
