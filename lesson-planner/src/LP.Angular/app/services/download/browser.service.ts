import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BrowserService {

  constructor() {
  }

  public isIEOrEdge(): boolean {
    return /msie\s|trident\/|edge\//i.test(window.navigator.userAgent);
  }
}
