import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import localforage from 'localforage';
import { ButtonComponent } from '../../../components/button/button.component';
import { CardContentComponent } from '../../../components/card-content/card-content.component';
import { CardHeaderComponent } from '../../../components/card-header/card-header.component';
import { CardTitleComponent } from '../../../components/card-title/card-title.component';
import { CardComponent } from '../../../components/card/card.component';
import { FormLabelComponent } from '../../../components/form/form-label.component';
import { InputComponent } from '../../../components/form/input.component';
import { SeparatorComponent } from '../../../components/separator/separator.component';
import { Model1Inputs } from '../../models/Model1Inputs';

@Component({
  selector: 'app-model1-inputs',
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
  templateUrl: './model1-inputs.component.html',
  styleUrl: './model1-inputs.component.scss'
})
export class Model1InputsComponent implements OnInit {

  public inputs: Model1Inputs = new Model1Inputs();

  private store: LocalForage;

  @Output()
  public onCalculate = new EventEmitter<Model1Inputs>();

  constructor() {

    this.store = localforage.createInstance({
      name: "model1"
    });

    this.store.getItem("inputs").then((inputs: any) => {
      if (inputs) {
        this.inputs = JSON.parse(inputs);
      }
      this.calculate();
    })
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
