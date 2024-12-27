import { ChangeDetectionStrategy, Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import localforage from 'localforage';
import { Model4Inputs } from '../../models/Model4Inputs';
import { CommonModule } from '@angular/common';
import { ButtonComponent, CardComponent, CardContentComponent, CardHeaderComponent, CardTitleComponent, FormLabelComponent, PopupComponent } from '@gsej/tailwind-components';


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
    CardTitleComponent,
    CardHeaderComponent,
    PopupComponent
  ],
  templateUrl: './model4-inputs.component.html',
  styleUrl: './model4-inputs.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
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
