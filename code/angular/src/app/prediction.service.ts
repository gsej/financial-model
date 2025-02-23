import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { Model1Prediction } from './model1/models/Model1Prediction';
import { Model1Inputs } from './model1/models/Model1Inputs';
import { Model2Inputs } from './model2/models/Model2Inputs';
import { Model2Prediction } from './model2/models/Model2Prediction';
import { Model3Inputs } from './model3/models/Model3Inputs';
import { Model3Prediction } from './model3/models/Model3Prediction';
import { Model4Prediction } from './model4/models/Model4Prediction';
import { Model4Inputs } from './model4/models/Model4Inputs';
import { SettingsService } from './settings/settings.service';

@Injectable({
  providedIn: 'root'
})
export class PredictionService {

  private apiUrl: string;

  constructor(private http: HttpClient, settingsService: SettingsService) {
    this.apiUrl = settingsService.settings.apiUrl;
  }

  getModel1Prediction(request: Model1Inputs): Observable<Model1Prediction> {
    return this.http.post<Model1Prediction>(`${this.apiUrl}/api/model1`, request);
  }

  getModel2Prediction(request: Model2Inputs): Observable<Model2Prediction> {
    return this.http.post<Model2Prediction>(`${this.apiUrl}/api/model2`, request);
  }

  getModel3Prediction(request: Model3Inputs): Observable<Model3Prediction> {
    return this.http.post<Model3Prediction>(`${this.apiUrl}/api/model3`, request);
  }

  getModel4Prediction(request: Model4Inputs): Observable<Model4Prediction> {
    return this.http.post<Model4Prediction>(`${this.apiUrl}/api/model4`, request);
  }
}
