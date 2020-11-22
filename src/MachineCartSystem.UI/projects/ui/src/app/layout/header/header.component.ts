import { AppTranslationService, ComponentConstant } from 'projects/lib/src/public-api';
import { Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Component, OnInit, Input } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Input() isAuthenticated = false;
  Property = false;
  appTitle = "MachineCart";
  appLogo = require("../../../assets/images/logo-white.png").default;
  newNotificationCount = 0;

  constructor(private authService: OidcSecurityService,
    public router: Router, private translationService: AppTranslationService) { }

  ngOnInit(): void {
  }

  get notificationsTitle() {

    let gT = (key: string) => this.translationService.getTranslation(key);

    if (this.newNotificationCount)
      return `${gT("app.Notifications")} (${this.newNotificationCount} ${gT("app.New")})`;
    else
      return gT("app.Notifications");
  }


  markNotificationsAsRead() { }
  logout() {
    this.authService.logoff();
    this.isAuthenticated = false;
    this.router.navigate([ComponentConstant.Login]);
  }

  get userName(): Observable<string> {
    return this.authService.userData$.pipe(map(p => {
      return p.name;
    }));
  }

  get fullName(): Observable<string> {
    return this.authService.userData$.pipe(map(p => p.fullName));
  }

  get canViewCustomers() {
    return true;
    // this.accountService.userHasPermission(Permission.viewUsersPermission); //eg. viewCustomersPermission
  }

  get canViewProducts() {
    return true;

    //return this.accountService.userHasPermission(Permission.viewUsersPermission); //eg. viewProductsPermission
  }

  get canViewOrders() {
    return true; //eg. viewOrdersPermission
  }

  revokeAccessToken() {
    this.authService.revokeAccessToken()
      .subscribe((result) => {
        console.log(result);
      });
  }
}
