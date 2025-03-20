import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from '@angular/core';
import { Model1ResultsComponent } from '../model1-results/model1-results.component';
import { HeaderComponent } from '@gsej/tailwind-components';
import { Model1Prediction } from '../../models/Model1Prediction';
import { PredictionService } from '../../../prediction.service';
import { Model1Inputs } from '../../models/Model1Inputs';
import { Model1ChartComponent } from '../model1-chart/model1-chart.component';
import { Model1InputsComponent } from '../model1-inputs/model1-inputs.component';
import { PopupComponent } from '../../../components/popup/popup.component';
import { model1 } from '../../../models';


@Component({
  selector: 'app-model1-container',
  standalone: true,
  imports: [
    Model1InputsComponent,
    Model1ResultsComponent,
    Model1ChartComponent,
    HeaderComponent,
    PopupComponent],
  templateUrl: './model1-container.component.html',
  styleUrl: './model1-container.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Model1ContainerComponent {

  description = model1;

  public prediction: Model1Prediction | null = null;

  constructor(
    private predictionService: PredictionService,
    private changeDetector: ChangeDetectorRef) { }

  calculate(inputs: Model1Inputs) {
    this.predictionService.getModel1Prediction(inputs).subscribe(prediction => {
      this.prediction = prediction;
      this.changeDetector.markForCheck();
    });
  }
}
