import { Component } from '@angular/core';
import { InputsComponent } from '../inputs/inputs.component';
import { Inputs, Model1Prediction, Year } from '../inputs';
import { PredictionService } from '../../prediction.service';
import { Model1ResultsComponent } from '../model1-results/model1-results.component';

@Component({
  selector: 'app-model1-container',
  standalone: true,
  imports: [InputsComponent, Model1ResultsComponent],
  templateUrl: './model1-container.component.html',
  styleUrl: './model1-container.component.scss'
})
export class Model1ContainerComponent {

  public prediction: Model1Prediction | undefined;

  constructor(private predictionService: PredictionService) { }

  calculate(inputs: Inputs) {
    this.predictionService.getModel1Predication(inputs).subscribe(prediction => {
      this.prediction = prediction;
    });
  }
}
