import { PreloadingStrategy, Route } from '@angular/router';
import { Observable, of, timer } from 'rxjs';
import { mergeMap } from 'rxjs/operators';

export class AppPreloadingStrategy implements PreloadingStrategy {
  preload(route: Route, load: () => Observable<any>): Observable<any> {
    const loadRoute = (delay) => delay ? timer(150).pipe(mergeMap(_ => load())) : load();
    return route.data?.preload ? (route.data.delay) : of(null);
  }

}
