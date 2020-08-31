import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';
import {map} from 'rxjs/operators'
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:44349/api/';

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams){

    let params = new HttpParams();

    if(shopParams.brandId !== 0) params = params.append('BrandId', shopParams.brandId.toString());
    if(shopParams.typeId !== 0) params = params.append('TypeId', shopParams.typeId.toString());
    if(shopParams.search) params = params.append('Search', shopParams.search);

    params = params.append('Sort', shopParams.sort);
    params = params.append('PageIndex', shopParams.pageNumber.toString());
    params = params.append('PageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'TProducts', {observe: 'response', params})
    .pipe(map(response => {
        return response.body;
    }));
  }

  getBrands(){
    return this.http.get<IBrand[]>(this.baseUrl + 'TProducts/Brands')
  }
  
  getTypes(){
    return this.http.get<IType[]>(this.baseUrl + 'TProducts/Types')
  }
}
