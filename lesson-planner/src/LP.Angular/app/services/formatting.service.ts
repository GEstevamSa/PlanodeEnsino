import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FormattingService {

  constructor() {
  }

  public formatMoney(amount, thousands = ',') {
    try {
      const negativeSign = amount < 0 ? '-' : '';

      const i = parseInt(amount = Math.abs(Number(amount) || 0).toFixed(0), 10).toString();
      const j = (i.length > 3) ? i.length % 3 : 0;

      return negativeSign + (j ? i.substr(0, j) + thousands : '') + i.substr(j).replace(/(\d{3})(?=\d)/g, '$1' + thousands);
    } catch (e) {
      console.log(e);
    }
  }
}
