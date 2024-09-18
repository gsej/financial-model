import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Model1ContainerComponent } from './model1/components/model1-container/model1-container.component';
import { Model2ContainerComponent } from './model2/components/model2-container/model2-container.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    Model1ContainerComponent,
    Model2ContainerComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'pension-predictor';

  public model: string = 'model1';

   public changeModel(event: any) {
    console.log("model changed to " + event.target.value);
    this.model = event.target.value;
   }
}
