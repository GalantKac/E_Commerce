import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  //pole
  title = 'E_Commerce';

  constructor(private http: HttpClient) { }

  //metody interfejsu
  ngOnInit(): void {
  }
}
