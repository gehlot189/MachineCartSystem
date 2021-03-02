import { Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { UserLogin } from './user-login';
import { timer } from 'rxjs';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { AlertService, MessageSeverity } from 'projects/lib/src/public-api';

@UntilDestroy()
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})

export class LoginComponent implements OnInit, OnDestroy {
  userLogin = new UserLogin("alice@alice.com", "alice");
  isLoading = false;
  formResetToggle = true;
  modalClosedCallback: () => void;
  loginStatusSubscription: any;

  @Input()
  isModal = false;
  constructor(private oidcSecurityService: OidcSecurityService,
    private router: Router,
    private alertService: AlertService) {
  }

  ngOnDestroy(): void {
    throw new Error('Method not implemented.');
  }

  showErrorAlert(caption: string, message: string) {
    this.alertService.showMessage(caption, message, MessageSeverity.error);
  }

  ngOnInit(): void {
    debugger;
    //this.userLogin.rememberMe = this.authService.rememberMe;

  }
  closeModal() {
    // if (this.modalClosedCallback) {
    //   this.modalClosedCallback();
    // }
  }
  login() {
    this.isLoading = true;
    this.alertService.startLoadingMessage("", "Attempting login...");
    timer().pipe(untilDestroyed(this)).subscribe(() => {
      this.router.navigate([this.oidcSecurityService.authorize()]);
    });
  }
}
