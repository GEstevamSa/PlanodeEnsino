import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { APIResponse } from '@classes/apiresponse';

@Injectable({
  providedIn: 'root'
})

export class IProvider {

  constructor() { }

  public get(url: string): Observable<APIResponse> {
    return Observable.create();
  }

  public getByFilter(url: string, any: object): Observable<APIResponse> {
    return Observable.create();
  }

  public getByQueryString(url: string, queryString: object): Observable<APIResponse> {
    return Observable.create();
  }

  public post(url: string, body: any, options?: any): Observable<APIResponse> {
    return Observable.create();
  }

  public put(url: string, id: string, body: any): Observable<APIResponse> {
    return Observable.create();
  }

  public delete(url: string, id: string): Observable<APIResponse> {
    return Observable.create();
  }

}
