import { Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Input() isAuthenticated = false;
  Property = false;
  isUserLoggedIn: boolean;
  appTitle = "MachineCart";
  appLogo = require("../../../assets/images/logo-white.png").default;

  constructor(private oidcSecurityService: OidcSecurityService,
    public router: Router) { }

  ngOnInit(): void {

  }

  logout() {
    //this.spinner.show();
    this.oidcSecurityService.logoff();
  }

  revokeAccessToken() {
    this.oidcSecurityService.revokeAccessToken()
      .subscribe((result) => {
        console.log(result);
      });
  }
}
