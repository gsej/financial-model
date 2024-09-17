import { Component, EventEmitter, OnInit, Output } from '@angular/core';
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
import localforage from 'localforage';

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
export class InputsComponent implements OnInit {

  public inputs!: Inputs;

  private store: LocalForage;

  @Output()
  public onCalculate = new EventEmitter<Inputs>();

  constructor() {

    this.store = localforage.createInstance({
      name: "model1"
    });

    this.store.getItem("inputs").then((inputs: any) => {
      if (inputs) {
        this.inputs = JSON.parse(inputs);
        this.calculate();
      }
      else {
        this.inputs = new Inputs();
        this.calculate();
      }
    })

    // this.inputs = new Inputs();
  }


  ngOnInit(): void {
    this.calculate();
  }

  calculate() {
    this.store.setItem("inputs", JSON.stringify(this.inputs));
    if (this.inputs) {
      this.onCalculate.next(this.inputs);
    }
  }

  useDefaults() {
    // this.onCalculate.next(this.inputs);
  }
}
