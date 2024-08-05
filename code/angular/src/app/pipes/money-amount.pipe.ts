import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'moneyAmount',
  standalone: true
})
export class MoneyAmountPipe implements PipeTransform {
  transform(value: number): string {
    if (isNaN(value)) {
      return '';
    }

    const formatter = new Intl.NumberFormat('en-US', {
      minimumFractionDigits: 2,
      maximumFractionDigits: 2
    });
    return formatter.format(value);
  }
}
