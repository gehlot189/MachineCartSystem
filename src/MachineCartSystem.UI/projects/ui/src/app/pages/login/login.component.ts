import { Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  userLogin;
  isLoading = false;
  formResetToggle = false;
  modalClosedCallback: () => void;
  loginStatusSubscription: any;

  @Input()
  isModal = false;
  constructor(private oidcSecurityService: OidcSecurityService,
    private router: Router) {
  }

  ngOnInit(): void {

  }
  closeModal() {
    // if (this.modalClosedCallback) {
    //   this.modalClosedCallback();
    // }
  }
  login() {
    // this.spinner.show();
    //  this.router.navigate([this.oidcSecurityService.authorize()]);
  }
}
