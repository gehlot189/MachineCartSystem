import { NgxSpinnerService } from 'ngx-spinner';
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

  constructor(private oidcSecurityService: OidcSecurityService,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {

  }

  logout() {
    this.spinner.show();
    this.oidcSecurityService.logoff();
  }

  revokeAccessToken() {
    this.oidcSecurityService.revokeAccessToken()
      .subscribe((result) => {
        console.log(result);
      });
  }
}
