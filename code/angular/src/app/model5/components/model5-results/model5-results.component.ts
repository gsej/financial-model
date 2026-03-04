import { ChangeDetectionStrategy, Component, Input } from '@angular/core';

import { formatCurrency, formatPercentage, formatQuantity } from '../../../utils/formatters';
import { CommonModule } from '@angular/common';
import { Model5Prediction } from '../../models/Model5Prediction';
import { Model5Year } from '../../models/Model5Year';



@Component({
  selector: 'app-model5-results',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './model5-results.component.html',
  styleUrl: './model5-results.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Model5ResultsComponent {

  public formatQuantity = formatQuantity;
  public formatCurrency = formatCurrency;
  public formatPercentage = formatPercentage;

  @Input()
  public prediction: Model5Prediction | null = null;

  public getAmountAtStart(year: Model5Year, allocation: string) {
    return year.allocations.find(a => a.name === allocation)?.amountAtStart;
  }
}
