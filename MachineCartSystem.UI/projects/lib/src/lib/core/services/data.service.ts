import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable()
export class DataService {
  private _data$: Subject<any>;
  data$: Observable<any>;

  constructor() {
    this._data$ = new Subject<any>();
    this.data$ = this._data$.asObservable();
  }

  send(data: any): void {
    this._data$.next(data);
  }
}
