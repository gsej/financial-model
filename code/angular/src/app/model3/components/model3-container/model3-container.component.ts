import { ChangeDetectionStrategy, Component } from '@angular/core';
import { Model3ResultsComponent } from '../model3-results/model3-results.component';
import { HeaderComponent } from '@gsej/tailwind-components';

import { PredictionService } from '../../../prediction.service';
import { Model3Inputs } from '../../models/Model3Inputs';
import { Model3ChartComponent } from '../model3-chart/model3-chart.component';
import { Model3InputsComponent } from '../model3-inputs/model3-inputs.component';
import { Model3Prediction } from '../../models/Model3Prediction';
import { PopupComponent } from '../../../components/popup/popup.component';
import { model3 } from '../../../models';


@Component({
  selector: 'app-model3-container',
  standalone: true,
  imports: [
    Model3InputsComponent,
    Model3ResultsComponent,
    HeaderComponent,
    Model3ChartComponent,
    PopupComponent],
  templateUrl: './model3-container.component.html',
  styleUrl: './model3-container.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Model3ContainerComponent {

  description = model3;

  public prediction: Model3Prediction | null = null;

  constructor(private predictionService: PredictionService) { }

  calculate(inputs: Model3Inputs) {
    this.predictionService.getModel3Prediction(inputs).subscribe(prediction => {
      this.prediction = prediction;
    });
  }
}
