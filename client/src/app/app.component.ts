import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from './models/product';
import {IPagination} from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  //pole
  title = 'E_Commerce';
  products: IProduct[];

  constructor(private http: HttpClient) { }

  //metody interfejsu
  ngOnInit(): void {
    this.http.get('https://localhost:44349/api/TProducts?pageSize=50').subscribe((response: IPagination) => {
      this.products = response.data;
    }, error => {
      console.log(error);
    });
  }
}
