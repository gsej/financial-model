import { Component } from '@angular/core';
import { InputsComponent } from '../inputs/inputs.component';
import { Inputs, Model1Prediction, Year } from '../inputs';
import { PredictionService } from '../../prediction.service';
import { Model1ResultsComponent } from '../model1-results/model1-results.component';
import { LineChartComponent } from '../line-chart/line-chart.component';

@Component({
  selector: 'app-model1-container',
  standalone: true,
  imports: [InputsComponent, Model1ResultsComponent, LineChartComponent],
  templateUrl: './model1-container.component.html',
  styleUrl: './model1-container.component.scss'
})
export class Model1ContainerComponent {

  public prediction: Model1Prediction | undefined;

  public years: string[] = [];
  public values: number[] = [];

  constructor(private predictionService: PredictionService) { }

  calculate(inputs: Inputs) {
    this.predictionService.getModel1Prediction(inputs).subscribe(prediction => {
      this.prediction = prediction;

      this.years = this.prediction.years.map(y => y.age.toString());
      this.values = this.prediction.years.map(y => y.amountAtEnd);

    });
  }
}
