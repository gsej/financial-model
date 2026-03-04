import { ChangeDetectionStrategy, Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import localforage from 'localforage';
import { Model5Inputs } from '../../models/Model5Inputs';
import { CommonModule } from '@angular/common';
import { CardComponent, CardContentComponent, CardHeaderComponent, CardTitleComponent, FormLabelComponent } from '@gsej/tailwind-components';
import { PopupComponent } from '../../../components/popup/popup.component';
import { ButtonComponent } from '../../../components/button/button.component';

@Component({
  selector: 'app-model5-inputs',
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
  templateUrl: './model5-inputs.component.html',
  styleUrl: './model5-inputs.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Model5InputsComponent implements OnInit {

  public inputs: Model5Inputs = new Model5Inputs();

  private store: LocalForage;

  @Output()
  public onCalculate = new EventEmitter<Model5Inputs>();

  constructor() {
    this.store = localforage.createInstance({
      name: "model5"
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
    this.inputs = new Model5Inputs();
    this.calculate();
  }
}
