import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from '@angular/core';
import { Model2ResultsComponent } from '../model2-results/model2-results.component';
import { HeaderComponent } from '@gsej/tailwind-components';

import { PredictionService } from '../../../prediction.service';
import { Model2Inputs } from '../../models/Model2Inputs';
import { Model2ChartComponent } from '../model2-chart/model2-chart.component';
import { Model2InputsComponent } from '../model2-inputs/model2-inputs.component';
import { Model2Prediction } from '../../models/Model2Prediction';
import { PopupComponent } from '../../../components/popup/popup.component';
import { model2 } from '../../../models';

@Component({
  selector: 'app-model2-container',
  standalone: true,
  imports: [
    Model2InputsComponent,
    Model2ResultsComponent,
    HeaderComponent,
    Model2ChartComponent,
    PopupComponent],
  templateUrl: './model2-container.component.html',
  styleUrl: './model2-container.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Model2ContainerComponent {

  description = model2;

  public prediction: Model2Prediction | null = null;

  constructor(
    private predictionService: PredictionService,
    private changeDetector: ChangeDetectorRef
  ) { }

  calculate(inputs: Model2Inputs) {
    this.predictionService.getModel2Prediction(inputs).subscribe(prediction => {
      this.prediction = prediction;
      this.changeDetector.markForCheck();
    });
  }
}
