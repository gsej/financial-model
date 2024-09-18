import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { Model1Prediction } from './model1/models/Model1Prediction';
import { Model1Inputs } from './model1/models/Model1Inputs';
import { Model2Inputs } from './model2/models/Model2Inputs';
import { Model2Prediction } from './model2/models/Model2Prediction';

@Injectable({
  providedIn: 'root'
})
export class PredictionService {

  constructor(private http: HttpClient) { }

  getModel1Prediction(request: Model1Inputs): Observable<Model1Prediction> {
    return this.http.post<Model1Prediction>("http://localhost:5200/api/model1", request);
  }

  getModel2Prediction(request: Model2Inputs): Observable<Model2Prediction> {
    return this.http.post<Model2Prediction>("http://localhost:5200/api/model2", request);
  }
}
