import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import Chart from 'chart.js/auto';
import annotationPlugin from 'chartjs-plugin-annotation';

import { format000s } from '../../../utils/formatters';
import { Model4Prediction } from '../../models/Model4Prediction';
import { FormLabelComponent } from '../../../components/form/form-label.component';
import { FormsModule } from '@angular/forms';

Chart.register(annotationPlugin);

@Component({
  selector: 'app-model4-chart',
  standalone: true,
  imports: [FormsModule, FormLabelComponent],
  templateUrl: './model4-chart.component.html',
  styleUrl: './model4-chart.component.scss'
})
export class Model4ChartComponent implements OnChanges {

  public chart: any;

  private percentages: number[] = [];
  private values: string[] = [];
  private previousPrediction: string | null = null;

  public cumulative = true;

  @Input()
  public prediction: Model4Prediction | null = null;

  ngOnInit(): void {
    this.previousPrediction = JSON.stringify(this.prediction);
    this.setData(this.cumulative);
    this.createChart();
  }

  ngOnChanges(changes: SimpleChanges): void {
    const serializedPrediction = JSON.stringify(this.prediction);
    if (this.previousPrediction !== serializedPrediction) {
      this.previousPrediction = serializedPrediction;
      this.setData(this.cumulative);
      this.createChart();
    }
  }

  onCumulativeChange(value: boolean) {
    this.cumulative = value;
    this.setData(this.cumulative);
    this.createChart();
  }

  setData(cumulative: boolean) {
    if (this.prediction) {
      if (cumulative) {
        this.values = this.prediction.cumulativeBands.map(band => format000s(band.upper));
        this.percentages = this.prediction.cumulativeBands.map(band => band.percentage * 100);
      }
      else {
        this.values = this.prediction.bands.map(band => format000s(band.upper));
        this.percentages = this.prediction.bands.map(band => band.percentage * 100);
      }


    }
    else {
      this.percentages = [];
      this.values = [];
    }
  }

  createChart() {

    if (this.chart) {
      this.chart.destroy();
      this.chart = null;
    }
    this.chart = new Chart("MyChart", {
      type: 'bar',
      data: {
        labels: this.values,
        datasets: [{
          label: this.cumulative ? 'Cumulative Percentage' : 'Percentage',
          data: this.percentages,
          backgroundColor: 'rgba(75, 192, 192, 0.2)',
          borderColor: 'rgba(75, 192, 192, 1)',
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          x: {
            beginAtZero: true,
            title: {
              display: true,
              text: 'Thousands'
            }

          },
          y: {
            beginAtZero: true
          }
        }
      }
    });
  }
}
