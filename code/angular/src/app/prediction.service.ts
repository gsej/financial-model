import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Inputs, Model1Prediction } from './model1/inputs';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PredictionService {

  constructor(private http: HttpClient) { }

  getModel1Prediction(request: Inputs): Observable<Model1Prediction> {
    return this.http.post<Model1Prediction>("http://localhost:5200/api/model1", request);
  }
}
