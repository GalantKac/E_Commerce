import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {BehaviorSubject} from 'rxjs';
import {Basket, IBasket, IBasketItem, IBasketTotals} from '../shared/models/basket';
import {map} from 'rxjs/operators';
import {IProduct} from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baserUrl = environment.baseUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<IBasketTotals>(null);
  basketTotals$ = this.basketTotalSource.asObservable();

  constructor(private http: HttpClient) {
  }

  getBasket(id: string) {
    return this.http.get(this.baserUrl + 'basket?id=' + id)
      .pipe(map((basket: IBasket) => {
        this.basketSource.next(basket);
        this.calculateTotals();
      }));
  }

  setBasket(basket: IBasket) {
    return this.http.post(this.baserUrl + 'basket', basket).subscribe((response: IBasket) => {
      this.basketSource.next(response);
      this.calculateTotals();
    }, error => {
      console.log(error);
    });
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemToBasket(item: IProduct, quantity = 1) {
    const itemToAdd: IBasketItem = this.mapProductItemToBasketItem(item, quantity);
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasket(basket);
  }

  incrementItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    const foundIndex = basket.items.findIndex(i => i.id === item.id);
    basket.items[foundIndex].quantity++;
    this.setBasket(basket);
  }

  decrementItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    const foundIndex = basket.items.findIndex(i => i.id === item.id);
    if (basket.items[foundIndex].quantity > 1) {
      basket.items[foundIndex].quantity--;
      this.setBasket(basket);
    } else {
      this.removeItemFromBasket(item);
    }
  }

  removeItemFromBasket(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    if (basket.items.some(i => i.id === item.id)) {
      basket.items = basket.items.filter(i => i.id !== item.id);
      if (basket.items.length > 0) {
        this.setBasket(basket);
      } else {
        this.deleteBasket(basket);
      }
    }
  }

  deleteBasket(basket: IBasket) {
    return this.http.delete(this.baserUrl + 'basket?id=' + basket.id).subscribe(() => {
      this.basketSource.next(null);
      this.basketTotalSource.next(null);
      localStorage.removeItem('basket_id');
    }, error => {
      console.log(error);
    });
  }

  private mapProductItemToBasketItem(item: IProduct, quantity: number): IBasketItem {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      picturePath: item.picturePath,
      quantity,
      brand: item.productBrand,
      type: item.productType
    };
  }

  private createBasket(): IBasket {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  private calculateTotals() {
    const basket = this.getCurrentBasketValue();
    const shipping = 0;
    const subtotal = basket.items.reduce((all, item) => (item.price * item.quantity) + all, 0);
    const total = subtotal + shipping;
    this.basketTotalSource.next({shipping, total, subtotal});
  }

  private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const index = items.findIndex(i => i.id === itemToAdd.id);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    }
    return items;
  }
}
