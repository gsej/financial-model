import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-line-chart',
  standalone: true,
  imports: [],
  templateUrl: './line-chart.component.html',
  styleUrl: './line-chart.component.scss'
})
export class LineChartComponent implements OnChanges  {

  @Input()
  public years: string[] = [];

  @Input()
  public values: number[] = [];

  ngOnInit(): void {
    this.createChart();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['years']) {
      this.updateChart();
    }
    else if (changes['values']) {
      this.createChart();
    }
  }


  updateChart() {
    if (this.chart) {
      this.chart.data.labels = this.years;
      this.chart.data.datasets[0].data = this.values;
      this.chart.update();
    }
  }

  public chart: any;

  createChart() {

    this.chart = new Chart("MyChart", {
      type: 'line', //this denotes tha type of chart

      data: {// values on X-Axis
        // labels: ['2022-05-10', '2022-05-11', '2022-05-12', '2022-05-13',
        //   '2022-05-14', '2022-05-15', '2022-05-16', '2022-05-17',],
        labels: this.years,
        datasets: [
          {
            label: "Total £",
            data: this.values,
            // data: ['467', '576', '572', '79', '92',
            //   '574', '573', '576'],
            backgroundColor: 'blue'
          },
          // {
          //   label: "Profit",
          //   data: ['542', '542', '536', '327', '17',
          //     '0.00', '538', '541'],
          //   backgroundColor: 'limegreen'
          // }
        ]
      },
      options: {
   //     aspectRatio: 2.5
      }

    });
  }



}
