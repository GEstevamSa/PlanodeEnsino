import { Injectable } from '@angular/core';
import { IProvider } from '@services/interfaces/iprovider.service';
import { Observable } from 'rxjs';
import { User } from '@classes/user';
import { JsonConvert } from 'json2typescript';

@Injectable({
  providedIn: 'root'
})
export class UserCollectorService {

  constructor(private provider: IProvider) { }

  getApprovers(): Observable<User[]> {
    return Observable.create(observer => {
      this.provider.get(`/user`).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response.Result, User));
        });
    });
  }
}
