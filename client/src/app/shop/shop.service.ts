import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { IProduct } from '../shared/models/product';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {

    let params = new HttpParams();

    if (shopParams.brandId !== 0) { params = params.append('BrandId', shopParams.brandId.toString()); }
    if (shopParams.typeId !== 0) { params = params.append('TypeId', shopParams.typeId.toString()); }
    if (shopParams.search) { params = params.append('Search', shopParams.search); }

    params = params.append('Sort', shopParams.sort);
    params = params.append('PageIndex', shopParams.pageNumber.toString());
    params = params.append('PageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'Products', { observe: 'response', params })
      .pipe(map(response => {
        return response.body;
      }));
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'Products/' + id);
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'Products/Brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'Products/Types');
  }
}
