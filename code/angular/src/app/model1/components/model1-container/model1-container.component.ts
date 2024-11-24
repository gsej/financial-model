import { Component } from '@angular/core';
import { Model1ResultsComponent } from '../model1-results/model1-results.component';
import { HeaderComponent } from '../../../components/header/header.component';
import { Model1Prediction } from '../../models/Model1Prediction';
import { PredictionService } from '../../../prediction.service';
import { Model1Inputs } from '../../models/Model1Inputs';
import { Model1ChartComponent } from '../model1-chart/model1-chart.component';
import { Model1InputsComponent } from '../model1-inputs/model1-inputs.component';
import { PopupComponent } from '../../../components/popup/popup.component';


@Component({
  selector: 'app-model1-container',
  standalone: true,
  imports: [
    Model1InputsComponent,
    Model1ResultsComponent,
    HeaderComponent,
    Model1ChartComponent,
    PopupComponent],
  templateUrl: './model1-container.component.html',
  styleUrl: './model1-container.component.scss'
})
export class Model1ContainerComponent {

  public prediction: Model1Prediction | null = null;

  constructor(private predictionService: PredictionService) { }

  calculate(inputs: Model1Inputs) {
    this.predictionService.getModel1Prediction(inputs).subscribe(prediction => {
      this.prediction = prediction;

    });
  }
}
