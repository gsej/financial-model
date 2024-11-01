import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import localforage from 'localforage';
import { ButtonComponent } from '../../../components/button/button.component';
import { CardContentComponent } from '../../../components/card-content/card-content.component';
import { CardHeaderComponent } from '../../../components/card-header/card-header.component';
import { CardTitleComponent } from '../../../components/card-title/card-title.component';
import { CardComponent } from '../../../components/card/card.component';
import { FormLabelComponent } from '../../../components/form/form-label.component';
import { SeparatorComponent } from '../../../components/separator/separator.component';
import { Model4Inputs } from '../../models/Model4Inputs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-model4-inputs',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    FormLabelComponent,
    ButtonComponent,
    CardComponent,
    CardContentComponent,
    SeparatorComponent,
    CardTitleComponent,
    CardHeaderComponent
  ],
  templateUrl: './model4-inputs.component.html',
  styleUrl: './model4-inputs.component.scss'
})
export class Model4InputsComponent implements OnInit {

  public inputs: Model4Inputs = new Model4Inputs();

  private store: LocalForage;

  @Output()
  public onCalculate = new EventEmitter<Model4Inputs>();

  constructor() {
    this.store = localforage.createInstance({
      name: "model4"
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

  reset() {
    this.inputs = new Model4Inputs();
    this.calculate();
  }
}
