import { Component, EventEmitter, Output } from '@angular/core';
import { Inputs } from '../inputs';
import { FormsModule } from '@angular/forms';
import { FormLabelComponent } from '../../components/form/form-label.component';
import { ButtonComponent } from '../../components/button/button.component';
import { InputComponent } from '../../components/form/input.component';
import { CardComponent } from '../../components/card/card.component';
import { CardContentComponent } from '../../components/card-content/card-content.component';
import { SeparatorComponent } from '../../components/separator/separator.component';
import { CardTitleComponent } from '../../components/card-title/card-title.component';
import { CardHeaderComponent } from '../../components/card-header/card-header.component';

@Component({
  selector: 'app-inputs',
  standalone: true,
  imports: [
    FormsModule,
    FormLabelComponent,
    InputComponent,
    ButtonComponent,
    CardComponent,
    CardContentComponent,
    SeparatorComponent,
    CardTitleComponent,
    CardHeaderComponent
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
