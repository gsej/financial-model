import { ChangeDetectionStrategy, Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import localforage from 'localforage';
import { Model1Inputs } from '../../models/Model1Inputs';
import { CardComponent, CardContentComponent, CardHeaderComponent, CardTitleComponent, FormLabelComponent } from '@gsej/tailwind-components';
import { ButtonComponent } from '../../../components/button/button.component';

@Component({
  selector: 'app-model1-inputs',
  standalone: true,
  imports: [
    FormsModule,
    FormLabelComponent,
    ButtonComponent,
    CardComponent,
    CardContentComponent,
    CardTitleComponent,
    CardHeaderComponent
  ],
  templateUrl: './model1-inputs.component.html',
  styleUrl: './model1-inputs.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
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

  reset() {
    this.inputs = new Model1Inputs();
    this.calculate();
  }
}
