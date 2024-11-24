import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, Input } from '@angular/core';

@Component({
  selector: 'app-card-title',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './card-title.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CardTitleComponent {


  @Input()
  class: string = '';

}
