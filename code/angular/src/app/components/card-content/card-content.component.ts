import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-card-content',
  standalone: true,
  imports: [],
  templateUrl: './card-content.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CardContentComponent {

}
