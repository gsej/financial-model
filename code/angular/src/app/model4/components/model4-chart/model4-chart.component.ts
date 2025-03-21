import { ChangeDetectionStrategy, Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import Chart from 'chart.js/auto';
import annotationPlugin from 'chartjs-plugin-annotation';

import { format000s } from '../../../utils/formatters';
import { Model4Prediction } from '../../models/Model4Prediction';
import { FormsModule } from '@angular/forms';
import { FormLabelComponent } from '@gsej/tailwind-components';

Chart.register(annotationPlugin);

@Component({
  selector: 'app-model4-chart',
  standalone: true,
  imports: [FormsModule, FormLabelComponent],
  templateUrl: './model4-chart.component.html',
  styleUrl: './model4-chart.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Model4ChartComponent implements OnChanges {

  public chart: any;

  private percentages: number[] = [];
  private values: string[] = [];
  private previousPrediction: string | null = null;

  public chartType = 'cumulative';
  private label = '';

  @Input()
  public prediction: Model4Prediction | null = null;

  ngOnInit(): void {
    this.previousPrediction = JSON.stringify(this.prediction);
    this.setData(this.chartType);
    this.createChart();
  }

  ngOnChanges(changes: SimpleChanges): void {
    const serializedPrediction = JSON.stringify(this.prediction);
    if (this.previousPrediction !== serializedPrediction) {
      this.previousPrediction = serializedPrediction;
      this.setData(this.chartType);
      this.createChart();
    }
  }

  onCumulativeChange(value: string) {
    this.chartType = value;
    this.setData(this.chartType);
    this.createChart();
  }

  setData(chartType: string) {
    if (this.prediction) {
      if (chartType === 'cumulative') {
        this.label = 'percentage of outcomes having less than this';
        this.values = this.prediction.cumulativeBands.map(band => `${format000s(band.upper)}k`);
        this.percentages = this.prediction.cumulativeBands.map(band => band.percentage * 100);
      }
      else if (chartType === 'frequency') {
        this.label = 'percentage of outcomes falling in this band';
        this.values = this.prediction.bands.map(band =>`${format000s(band.lower)}k-${format000s(band.upper)}k`);
        this.percentages = this.prediction.bands.map(band => band.percentage * 100);
      }
      if (chartType === 'reverse-cumulative') {
        this.label = 'percentage of outcomes having more than this';
        this.values = this.prediction.reverseCumulativeBands.map(band => `${format000s(band.lower)}k`);
        this.percentages = this.prediction.reverseCumulativeBands.map(band => band.percentage * 100);
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
          label: this.label,
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
              display: false,
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
