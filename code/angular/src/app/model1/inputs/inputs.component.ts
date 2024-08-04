import { Component, EventEmitter, Output } from '@angular/core';
import { Inputs } from '../inputs';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-inputs',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './inputs.component.html',
  styleUrl: './inputs.component.scss'
})
export class InputsComponent {

  public inputs: Inputs;

  @Output()
  public onCalculate = new EventEmitter<Inputs>();

  constructor() {
    this.inputs = new Inputs();
  }

  calculate() {
    this.onCalculate.next(this.inputs);
  }
}
