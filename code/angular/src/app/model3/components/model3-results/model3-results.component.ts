import { Component, Input } from '@angular/core';

import { formatCurrency, formatPercentage, formatQuantity } from '../../../utils/formatters';
import { CommonModule } from '@angular/common';
import { Model3Prediction } from '../../models/Model3Prediction';



@Component({
  selector: 'app-model3-results',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './model3-results.component.html',
  styleUrl: './model3-results.component.scss'
})
export class Model3ResultsComponent {

  public formatQuantity = formatQuantity;
  public formatCurrency = formatCurrency;
  public formatPercentage = formatPercentage;

  @Input()
  public prediction: Model3Prediction | null = null;
}
