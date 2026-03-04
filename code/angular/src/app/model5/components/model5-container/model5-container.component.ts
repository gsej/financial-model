import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from '@angular/core';
import { Model5ResultsComponent } from '../model5-results/model5-results.component';
import { HeaderComponent } from '@gsej/tailwind-components';

import { PredictionService } from '../../../prediction.service';
import { Model5Inputs } from '../../models/Model5Inputs';
import { Model5ChartComponent } from '../model5-chart/model5-chart.component';
import { Model5InputsComponent } from '../model5-inputs/model5-inputs.component';
import { Model5Prediction } from '../../models/Model5Prediction';
import { PopupComponent } from '../../../components/popup/popup.component';
import { model5 } from '../../../models';

@Component({
  selector: 'app-model5-container',
  standalone: true,
  imports: [
    Model5InputsComponent,
    Model5ResultsComponent,
    HeaderComponent,
    Model5ChartComponent,
    PopupComponent],
  templateUrl: './model5-container.component.html',
  styleUrl: './model5-container.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Model5ContainerComponent {

  description = model5;

  public prediction: Model5Prediction | null = null;

  constructor(private predictionService: PredictionService,
     private changeDetector: ChangeDetectorRef
  ) { }

  calculate(inputs: Model5Inputs) {
    this.predictionService.getModel5Prediction(inputs).subscribe(prediction => {
      this.prediction = prediction;
      this.changeDetector.markForCheck();
    });
  }
}
