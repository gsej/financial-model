import { Component, Input } from '@angular/core';
import { Model1Prediction } from '../inputs';

@Component({
  selector: 'app-model1-results',
  standalone: true,
  imports: [],
  templateUrl: './model1-results.component.html',
  styleUrl: './model1-results.component.scss'
})
export class Model1ResultsComponent {

  @Input()
  public resultsJson: string | undefined;

  @Input()
  public prediction: Model1Prediction | undefined = undefined;



}
