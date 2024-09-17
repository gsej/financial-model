import { Component, Input } from '@angular/core';
import { Model1Prediction } from '../inputs';

import { formatCurrency, formatPercentage, formatQuantity } from '../../utils/formatters';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-model1-results',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './model1-results.component.html',
  styleUrl: './model1-results.component.scss'
})
export class Model1ResultsComponent {

  public formatQuantity = formatQuantity;
  public formatCurrency = formatCurrency;
  public formatPercentage = formatPercentage;

  @Input()
  public prediction: Model1Prediction | null = null;
}
