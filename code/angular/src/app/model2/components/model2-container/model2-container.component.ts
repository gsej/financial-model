import { Component } from '@angular/core';
import { Model2ResultsComponent } from '../model2-results/model2-results.component';
import { HeaderComponent } from '../../../components/header/header.component';

import { PredictionService } from '../../../prediction.service';
import { Model2Inputs } from '../../models/Model2Inputs';
import { Model2ChartComponent } from '../model2-chart/model2-chart.component';
import { Model2InputsComponent } from '../model2-inputs/model2-inputs.component';
import { Model2Prediction } from '../../models/Model2Prediction';

@Component({
  selector: 'app-model2-container',
  standalone: true,
  imports: [
    Model2InputsComponent,
    Model2ResultsComponent,
    HeaderComponent,
    Model2ChartComponent],
  templateUrl: './model2-container.component.html',
  styleUrl: './model2-container.component.scss'
})
export class Model2ContainerComponent {

  public prediction: Model2Prediction | null = null;

  constructor(private predictionService: PredictionService) { }

  calculate(inputs: Model2Inputs) {
    this.predictionService.getModel2Prediction(inputs).subscribe(prediction => {
      this.prediction = prediction;
    });
  }
}
