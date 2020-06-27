import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:44349/api/';

  constructor(private http: HttpClient) { }

  getProducts(){
    return this.http.get<IPagination>(this.baseUrl + 'TProducts?pageSize=50');
  }

  getBrands(){
    return this.http.get<IBrand[]>(this.baseUrl + 'TProducts/Brands')
  }
  
  getTypes(){
    return this.http.get<IType[]>(this.baseUrl + 'TProducts/Types')
  }
}
