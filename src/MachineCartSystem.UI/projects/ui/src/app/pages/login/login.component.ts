import { Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private oidcSecurityService: OidcSecurityService,
    private router: Router) {
  }

  ngOnInit(): void {

  }

  login() {
    // this.spinner.show();
    this.router.navigate([this.oidcSecurityService.authorize()]);
  }
}
