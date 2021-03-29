import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { untilDestroyed, UntilDestroy } from '@ngneat/until-destroy';
import { OidcSecurityService } from 'angular-auth-oidc-client';
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

  }

  ngOnInit(): void {
    this.httpClient.get('catalog-all').subscribe(p => {
      debugger;
    });
  }

  ngOnDestroy() {
  }
}
