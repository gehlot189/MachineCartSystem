import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, Route } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ComponentConstant } from '../../configs/component-constant';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private oidcSecurityService: OidcSecurityService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    debugger;
    return this.checkUser();
  }

  canLoad(state: Route): Observable<boolean> {
    return this.checkUser();
  }

  private checkUser(): Observable<boolean> {
    return this.oidcSecurityService.isAuthenticated$.pipe(
      map((isAuthorized: boolean) => {
        if (!isAuthorized) {
          this.router.navigate([ComponentConstant.Login]);
          return false;
        }
        return true;
      })
    );
  }
}
