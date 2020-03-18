import { HeaderComponent } from './layout/header/header.component';
import { Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Component, ViewChild, OnInit, Input } from '@angular/core';
import { ComponentConstant } from 'projects/lib/src/public-api';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  @ViewChild(HeaderComponent, { static: true }) private appHeader: HeaderComponent;

  constructor(private oidcSecurityService: OidcSecurityService,
    private router: Router) {
  }

  ngOnInit(): void {
    this.checkAuthenticate();
  }

  private checkAuthenticate() {
    this.oidcSecurityService.checkAuth().subscribe(isAuthenticated => {
      this.appHeader.isAuthenticated = isAuthenticated;
      if (!isAuthenticated && '/' + ComponentConstant.Login !== window.location.pathname) {
        this.router.navigate([ComponentConstant.Login]);
      }
    });
  }
}
