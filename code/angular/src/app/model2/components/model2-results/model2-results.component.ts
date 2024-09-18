import { Component, Input } from '@angular/core';

import { formatCurrency, formatPercentage, formatQuantity } from '../../../utils/formatters';
import { CommonModule } from '@angular/common';
import { Model2Prediction } from '../../models/Model2Prediction';



@Component({
  selector: 'app-model2-results',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './model2-results.component.html',
  styleUrl: './model2-results.component.scss'
})
export class Model2ResultsComponent {

  public formatQuantity = formatQuantity;
  public formatCurrency = formatCurrency;
  public formatPercentage = formatPercentage;

  @Input()
  public prediction: Model2Prediction | null = null;
}
