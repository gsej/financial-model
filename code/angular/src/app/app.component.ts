import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Model1ContainerComponent } from './model1/components/model1-container/model1-container.component';
import { Model2ContainerComponent } from './model2/components/model2-container/model2-container.component';
import localforage from 'localforage';
import { Model3ContainerComponent } from './model3/components/model3-container/model3-container.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    Model1ContainerComponent,
    Model2ContainerComponent,
    Model3ContainerComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'pension-predictor';

  private store: LocalForage;

  public model: string = 'model1';

  constructor() {
    this.store = localforage.createInstance({
      name: "app"
    });

    this.store.getItem("selectedModel").then((selectedModel: any) => {
      if (selectedModel) {
        this.model = selectedModel;
      }
    })
  }

  public changeModel(event: any) {
    console.log("model changed to " + event.target.value);
    this.model = event.target.value;
    this.store.setItem("selectedModel", this.model);
  }
}
