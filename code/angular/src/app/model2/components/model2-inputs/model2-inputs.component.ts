import { ChangeDetectionStrategy, Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import localforage from 'localforage';
import { Model2Inputs } from '../../models/Model2Inputs';
import { ButtonComponent, CardComponent, CardContentComponent, CardHeaderComponent, CardTitleComponent, FormLabelComponent, HeaderComponent } from '@gsej/tailwind-components';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-model2-inputs',
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
    HeaderComponent
  ],
  templateUrl: './model2-inputs.component.html',
  styleUrl: './model2-inputs.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Model2InputsComponent implements OnInit {

  public inputs: Model2Inputs = new Model2Inputs();

  private store: LocalForage;

  @Output()
  public onCalculate = new EventEmitter<Model2Inputs>();

  constructor() {
    this.store = localforage.createInstance({
      name: "model2"
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
    this.inputs = new Model2Inputs();
    this.calculate();
  }
}
