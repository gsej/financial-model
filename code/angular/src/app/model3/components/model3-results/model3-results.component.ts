import { ChangeDetectionStrategy, Component, Input } from '@angular/core';

import { formatCurrency, formatPercentage, formatQuantity } from '../../../utils/formatters';
import { CommonModule } from '@angular/common';
import { Model3Prediction } from '../../models/Model3Prediction';
import { Model3Year } from '../../models/Model3Year';



@Component({
  selector: 'app-model3-results',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './model3-results.component.html',
  styleUrl: './model3-results.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Model3ResultsComponent {

  public formatQuantity = formatQuantity;
  public formatCurrency = formatCurrency;
  public formatPercentage = formatPercentage;

  @Input()
  public prediction: Model3Prediction | null = null;

  public getAmountAtStart(year: Model3Year, allocation: string) {
    return year.allocations.find(a => a.name === allocation)?.amountAtStart;
  }
}
