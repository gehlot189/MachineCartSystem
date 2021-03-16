import { Component, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { Router } from '@angular/router';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { AppTranslationService, ComponentConstant } from 'projects/lib/src/public-api';
import { HeaderComponent } from './layout/header/header.component';
const alertify: any = require('../assets/scripts/alertify.js');

@UntilDestroy()
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
    private router: Router,
    private translationService: AppTranslationService) {
  }

  ngOnInit(): void {
    this.translationService.addLanguages(["en", "fr", "de", "pt", "ar", "ko"]);
    this.translationService.setDefaultLanguage('fr');
    this.checkAuthenticate();
  }

  private checkAuthenticate() {
    this.oidcSecurityService.checkAuth().pipe(untilDestroyed(this)).subscribe(isAuthenticated => {
      // debugger;
      this.appHeader.isAuthenticated = isAuthenticated;
      if (!isAuthenticated && '/' + ComponentConstant.Login !== window.location.pathname) {
        this.router.navigate([ComponentConstant.Login]);
      }
    });
  }
}
