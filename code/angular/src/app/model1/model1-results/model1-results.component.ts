import { Component, Input } from '@angular/core';
import { Model1Prediction } from '../inputs';

import { LineChartComponent } from '../line-chart/line-chart.component';
import { formatCurrency, formatPercentage, formatQuantity } from '../../utils/formatters';


@Component({
  selector: 'app-model1-results',
  standalone: true,
  imports: [],
  templateUrl: './model1-results.component.html',
  styleUrl: './model1-results.component.scss'
})
export class Model1ResultsComponent {

  public formatQuantity = formatQuantity;
  public formatCurrency = formatCurrency;
  public formatPercentage = formatPercentage;

  @Input()
  public prediction: Model1Prediction | undefined = undefined;
}
