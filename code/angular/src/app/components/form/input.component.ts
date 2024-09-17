import { CommonModule } from '@angular/common';
import { Component, EventEmitter, forwardRef, Input, Output } from '@angular/core';
import { ControlValueAccessor, FormsModule, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-input',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './input.component.html',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputComponent),
      multi: true
    }
  ]
})
export class InputComponent implements ControlValueAccessor {

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

  private onChange: (value: any) => void = () => {};
  private onTouched: () => void = () => {};

  writeValue(value: any): void {
    this.ngModel = value;
  }

  registerOnChange(fn: (value: any) => void): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: () => void): void {
    this.onTouched = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    // Implement if needed
  }

  onInputChange(event: any): void {
    const value = event;
    this.ngModel = value;
    this.ngModelChange.emit(value);
    this.onChange(value);
  }

  onInputBlur(): void {
    this.onTouched();
  }
}
