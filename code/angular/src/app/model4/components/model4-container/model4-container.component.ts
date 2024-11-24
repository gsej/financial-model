import { ChangeDetectionStrategy, Component } from '@angular/core';
import { Model4ResultsComponent } from '../model4-results/model4-results.component';
import { HeaderComponent } from '../../../components/header/header.component';

import { PredictionService } from '../../../prediction.service';
import { Model4Inputs } from '../../models/Model4Inputs';
import { Model4ChartComponent } from '../model4-chart/model4-chart.component';
import { Model4InputsComponent } from '../model4-inputs/model4-inputs.component';
import { Model4Prediction } from '../../models/Model4Prediction';
import { PopupComponent } from '../../../components/popup/popup.component';

@Component({
  selector: 'app-model4-container',
  standalone: true,
  imports: [
    Model4InputsComponent,
    Model4ResultsComponent,
    HeaderComponent,
    Model4ChartComponent,
    PopupComponent],
  templateUrl: './model4-container.component.html',
  styleUrl: './model4-container.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Model4ContainerComponent {

  public prediction: Model4Prediction | null = null;

  constructor(private predictionService: PredictionService) { }

  calculate(inputs: Model4Inputs) {
    this.predictionService.getModel4Prediction(inputs).subscribe(prediction => {
      this.prediction = prediction;
    });
  }
}
