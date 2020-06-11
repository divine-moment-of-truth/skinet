import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IPagination } from '../shared/models/pagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  // https://localhost:5001/api/products?pageSize=50

  constructor(private http: HttpClient) { }

  getProducts(brandId?: number, typeId?: number, sort?: string) {
    // https://localhost:5001/api/products?brandId=2&typeId=1
    // https://localhost:5001/api/products?brandId=0&typeId=0
    let params = new HttpParams();

    if (brandId) {
      params = params.append('brandId', brandId.toString());
    }

    if (typeId) {
      params = params.append('typeId', typeId.toString());
    }

    if (sort) {
      params = params.append('sort', sort);
    }

    return this.http.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body; // body = an IPagination object
        })
      );
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
}
