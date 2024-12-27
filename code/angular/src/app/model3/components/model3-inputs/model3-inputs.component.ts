import { ChangeDetectionStrategy, Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import localforage from 'localforage';
import { Model3Inputs } from '../../models/Model3Inputs';
import { CommonModule } from '@angular/common';
import { ButtonComponent, CardComponent, CardContentComponent, CardHeaderComponent, CardTitleComponent, FormLabelComponent, PopupComponent } from '@gsej/tailwind-components';

@Component({
  selector: 'app-model3-inputs',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    FormLabelComponent,
    ButtonComponent,
    CardComponent,
    CardContentComponent,
    CardTitleComponent,
    CardHeaderComponent,
    PopupComponent
  ],
  templateUrl: './model3-inputs.component.html',
  styleUrl: './model3-inputs.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Model3InputsComponent implements OnInit {

  public inputs: Model3Inputs = new Model3Inputs();

  private store: LocalForage;

  @Output()
  public onCalculate = new EventEmitter<Model3Inputs>();

  constructor() {
    this.store = localforage.createInstance({
      name: "model3"
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
    this.inputs = new Model3Inputs();
    this.calculate();
  }
}
