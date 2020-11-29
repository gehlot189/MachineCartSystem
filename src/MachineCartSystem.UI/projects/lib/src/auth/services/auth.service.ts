import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Constant } from '../../configs/constant';
import { UserService } from './user.service';
import { DataService } from '../../services/data.service';

@Injectable()
export class AuthService {
  private manager;
  _
  constructor(private router: Router,
    private toast: ToastrService,
    private userService: UserService,
    private dataService: DataService) {
    this.initialSetup();
  }

  private initialSetup() {
    // this.manager = new UserManager(this.authSetting.identityServerSetting);
    this.manager.getUser().then(user => {
      this.userService.user = user;
    });
    this.subscribeAuthEvents();
  }

  private subscribeAuthEvents(): void {
    this.manager.events.addUserSignedOut(() => {
      this.toast.warning(Constant.SessionExpired);
      this.manager.removeUser();
      this.dataService.send(false);
    });

    this.manager.events.addSilentRenewError((p) => {
      debugger;
      this.toast.warning(Constant.SlientRefreshError);
    });

    this.manager.events.addAccessTokenExpired(() => {
      debugger;
      this.toast.warning(Constant.SessionExpired);
      this.manager.removeUser();
      this.logout();
    });
  }

  refreshCallBack(): void {
    this.manager.signinSilentCallback()
      .then(() => console.log("refresh success"))
      .catch(err => console.log("refresh error"));
  }

  login() {
    this.manager.signinRedirect();
  }

  logout() {
    this.manager.signoutRedirect();
  }

  isLoggedIn = () => {
    return this.userService.user != null && !this.userService.user.expired;
  }

  completeAuthentication() {
    this.manager.signinRedirectCallback().then(user => {
      this.toast.success(Constant.LoginSuccess);
      this.userService.user = user;
      this.navigateToHome();
    });
  }

  navigateToHome = () => this.router.navigate(['/']);

  startAuthenticationSaveState(state: any): Promise<void> {
    return this.manager.signinRedirect(state);
  }

  completeSignOutPopup() {
    this.manager.signoutRedirectCallback().then(() => {
      this.navigateToHome();
    });
  }

  // this.manager.events.addAccessTokenExpiring((p) => {
  //   console.log("access token expiring");
  // });

}
