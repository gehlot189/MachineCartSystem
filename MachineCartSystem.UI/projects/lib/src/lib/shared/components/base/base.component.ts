import { Subject } from 'rxjs';
import { Component, OnDestroy } from '@angular/core';
import { takeUntil } from "rxjs/operators";

@Component({
  selector: 'lib-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.css']
})
export class BaseComponent implements OnDestroy {
  protected subscription$: Subject<void>;

  constructor() {
    this.subscription$ = new Subject();
  }

  ngOnDestroy() {
    this.subscription$.next();
    this.subscription$.complete();
  }

}
