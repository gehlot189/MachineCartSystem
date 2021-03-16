import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { timer } from 'rxjs';
import { UserLogin } from './user-login';

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
    private router: Router) {
  }

  ngOnDestroy(): void {
    throw new Error('Method not implemented.');
  }

  showErrorAlert(caption: string, message: string) {
    //this.AlertService.showMessage(caption, message, MessageSeverity.error);
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
    //  this.AlertService.startLoadingMessage("", "Attempting login...");
    timer().pipe(untilDestroyed(this)).subscribe(() => {
      this.router.navigate([this.oidcSecurityService.authorize()]);
    });
  }
}
