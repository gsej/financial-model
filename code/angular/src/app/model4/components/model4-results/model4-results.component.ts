import { Component, Input } from '@angular/core';

import { formatCurrency, formatPercentage, formatQuantity } from '../../../utils/formatters';
import { CommonModule } from '@angular/common';
import { Model4Prediction } from '../../models/Model4Prediction';
import { Model4Iteration } from '../../models/Model4Iteration';



@Component({
  selector: 'app-model4-results',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './model4-results.component.html',
  styleUrl: './model4-results.component.scss'
})
export class Model4ResultsComponent {

  public formatQuantity = formatQuantity;
  public formatCurrency = formatCurrency;
  public formatPercentage = formatPercentage;

  @Input()
  public prediction: Model4Prediction | null = null;

  public getAmountAtTargetAge(iteration: Model4Iteration, allocation: string) {
    return iteration.allocations.find(a => a.name === allocation)?.amountAtTargetAge;
  }
}
