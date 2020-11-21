import { HeaderComponent } from './layout/header/header.component';
import { Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Component, ViewChild, OnInit, Input, ViewChildren, QueryList } from '@angular/core';
import { ComponentConstant } from 'projects/lib/src/public-api';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  @ViewChild(HeaderComponent, { static: true }) private appHeader: HeaderComponent;

  isAppLoaded: boolean;
  shouldShowLoginModal: boolean;
  removePrebootScreen: boolean;
  newNotificationCount = 0;
  stickyToasties: number[] = [];

  dataLoadingConsecutiveFailurs = 0;
  notificationsLoadingSubscription: any;

  @ViewChildren('loginModal,loginControl')
  modalLoginControls: QueryList<any>;

  // loginModal: ModalDirective;
  // loginControl: LoginComponent;

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
