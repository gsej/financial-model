import { Component } from '@angular/core';

@Component({
  selector: 'app-upload-json',
  standalone: true,
  imports: [],
  templateUrl: './upload-json.component.html',
  styleUrl: './upload-json.component.scss'
})
export class UploadJsonComponent {

  private jsonData: any;

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      const file = input.files[0];
      const reader = new FileReader();
      reader.onload = (e) => {
        try {
          this.jsonData = JSON.parse(e.target?.result as string);
          console.log(this.jsonData);
        } catch (error) {
          console.error('Error parsing JSON:', error);
        }
      };
      reader.readAsText(file);
    }
  }
}
