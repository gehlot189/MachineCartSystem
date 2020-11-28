import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { untilDestroyed, UntilDestroy } from '@ngneat/until-destroy';
import { OidcSecurityService } from 'angular-auth-oidc-client';
// import { fadeInOut } from 'projects/lib/src/public-api';
import { Observable } from 'rxjs';

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
    //  this.onclick();
  }
  onclick() {
    this.httpClient.get('ag').pipe(untilDestroyed(this)).subscribe(p => {
      debugger;
    });
  }
  ngOnDestroy() {
  }
}
