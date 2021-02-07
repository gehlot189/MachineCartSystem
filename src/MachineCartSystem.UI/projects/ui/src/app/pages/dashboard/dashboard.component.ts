import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { untilDestroyed, UntilDestroy } from '@ngneat/until-destroy';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { time } from 'console';
// import { fadeInOut } from 'projects/lib/src/public-api';
import { from, Observable } from 'rxjs';

@UntilDestroy()
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})

export class DashboardComponent implements OnInit {
  data$: Observable<any>;

  constructor(private httpClient: HttpClient, private oidcSecurityService: OidcSecurityService) {
    //debugger;

  }

  ngOnInit(): void {

    // this.httpClient.get('account').pipe(untilDestroyed(this)).subscribe(p => {
    //   debugger;
    // });
    // this.httpClient.get('account').pipe(untilDestroyed(this)).subscribe(p => {
    //   debugger;
    // });

    //  this.onclick();
  }
  ff() {
    this.httpClient.get('account').pipe(untilDestroyed(this)).subscribe(p => {
      debugger;
    });
  }

  onclick() {
    this.httpClient.get('account').pipe(untilDestroyed(this)).subscribe(p => {
      debugger;
    });
  }
  ngOnDestroy() {
  }
}
