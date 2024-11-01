import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import Chart from 'chart.js/auto';
import annotationPlugin from 'chartjs-plugin-annotation';

import { formatCurrency } from '../../../utils/formatters';
import { Model4Prediction } from '../../models/Model4Prediction';

Chart.register(annotationPlugin);

@Component({
  selector: 'app-model4-chart',
  standalone: true,
  imports: [],
  templateUrl: './model4-chart.component.html',
  styleUrl: './model4-chart.component.scss'
})
export class Model4ChartComponent implements OnChanges {

  public chart: any;

  private years: string[] = [];
  private values: number[] = [];
  private previousPrediction: string | null = null;

  @Input()
  public prediction: Model4Prediction | null = null;

  ngOnInit(): void {
    this.previousPrediction = JSON.stringify(this.prediction);
    this.setData();
    this.createChart();
  }

  ngOnChanges(changes: SimpleChanges): void {
    const serializedPrediction = JSON.stringify(this.prediction);
    if (this.previousPrediction !== serializedPrediction) {
      this.previousPrediction = serializedPrediction;
      this.setData();
      this.createChart();
    }
  }

  setData() {
    // if (this.prediction) {
    //   this.years = this.prediction.years.map(y => y.age.toString());
    //   this.values = this.prediction.years.map(y => y.amountAtEnd);
    // }
    // else {
    //   this.years = [];
    //   this.values = [];
    // }
  }

  createChart() {

    // if (this.chart) {
    //   this.chart.destroy();
    //   this.chart = null;
    // }

    // this.chart = new Chart("MyChart", <any>{
    //   type: 'line', //this denotes tha type of chart

    //   data: {// values on X-Axis
    //     labels: this.years,
    //     datasets: [
    //       {
    //         label: "Total £",
    //         data: this.values,
    //         backgroundColor: 'hsl(60, 9.1%, 97.8%)',
    //         borderColor: 'hsl(60, 9.1%, 70%)',
    //         fill: false
    //       }
    //     ]
    //   },
    //   options: {
    //     responsive: true,
    //     maintainAspectRatio: false,
    //     elements: {
    //       point: {
    //         pointStyle: false
    //       }
    //     },
    //     plugins: {
    //       legend: {
    //         position: "chartArea",
    //       },
    //       annotation: {
    //         annotations: {
    //           targetAgeLine: {
    //             type: 'line',
    //             scaleID: 'x',
    //             value: this.prediction?.targetAge.toString(),
    //             borderColor: 'green',
    //             borderWidth: 1,
    //             label: {
    //               content: 'Target Age',
    //               enabled: true,
    //               position: 'top'
    //             }
    //           },
    //           targetLabel: {
    //             type: 'label',
    //             content: this.prediction ? `Amount at ${this.prediction.targetAge}: ${formatCurrency(this.prediction.amountAtTargetAge)}` : '',
    //             position: 'top',
    //             xAdjust: 0,
    //             yAdjust: 0,
    //             //backgroundColor: 'rgba(255,255,255,0.8)',
    //             font: {
    //               size: 12,
    //               style: 'normal',
    //               color: 'red'
    //             }
    //           }
    //         }
    //       }
    //     }
    //   },
    // });
  }
}
