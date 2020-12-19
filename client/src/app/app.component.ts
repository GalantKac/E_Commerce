import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BasketService } from './basket/basket.service';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'E_Commerce';

  constructor(private basketSerivce: BasketService, private accountService: AccountService) {
  }

  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUser();
  }

  loadCurrentUser() {
    const token = localStorage.getItem('token');
    if (token) {
      this.accountService.loadCurrentUser(token).subscribe(() => {
        console.log('Loaded user');
      }, error => {
        console.log(error);
      });
    }
  }

  loadBasket() {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) {
      this.basketSerivce.getBasket(basketId).subscribe(() => {
        console.log('initalised basket');
      }, error => {
        console.log(error);
      });
    }
  }
}
