import { Component } from '@angular/core';

@Component({
  selector: 'app-download-json',
  standalone: true,
  imports: [],
  templateUrl: './download-json.component.html',
  styleUrl: './download-json.component.scss'
})
export class DownloadJsonComponent {

  public json: string = "";

  constructor() {

    const o = { hello: "world"};
    this.json = JSON.stringify(o);
  }

  downloadJson() {
    const blob = new Blob([this.json], { type: 'application/json' });
    const url = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = 'data.json';
    a.click();
    window.URL.revokeObjectURL(url);
  }
}
