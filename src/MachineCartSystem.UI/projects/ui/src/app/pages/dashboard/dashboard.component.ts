import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})

export class DashboardComponent implements OnInit {

  constructor(private httpClient: HttpClient, private oidcSecurityService: OidcSecurityService) {
  }

  ngOnInit(): void {

  }
onclick()
{
    this.httpClient.get('http://localhost:5001/api/ag',
      {
        headers: new HttpHeaders(
          {
            Authorization: 'Bearer ' + this.oidcSecurityService.getToken(),
          }),
      }).subscribe();
}
  ngOnDestroy() {
  }
}
