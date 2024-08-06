import { Component, Input } from '@angular/core';
import { Model1Prediction } from '../inputs';
import { MoneyAmountPipe } from '../../pipes/money-amount.pipe';
import { LineChartComponent } from '../line-chart/line-chart.component';


@Component({
  selector: 'app-model1-results',
  standalone: true,
  imports: [MoneyAmountPipe],
  templateUrl: './model1-results.component.html',
  styleUrl: './model1-results.component.scss'
})
export class Model1ResultsComponent {
  @Input()
  public prediction: Model1Prediction | undefined = undefined;
}
