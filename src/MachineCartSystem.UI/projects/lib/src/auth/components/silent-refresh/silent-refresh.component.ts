import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'lib-silent-refresh',
  templateUrl: './silent-refresh.component.html',
  styleUrls: ['./silent-refresh.component.css']
})
export class SilentRefreshComponent implements OnInit {

  constructor() {
  }

  ngOnInit() {
    console.log('working');

    // debugger;

  }
}
