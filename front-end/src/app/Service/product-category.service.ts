import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../https';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ProductCategoryService {
  constructor(private http: HttpClient) {}
  GetSanPhamByLoai(id: any, sapxep: any): Observable<any[]> {
    const params = `?id=${id}&sapXep=${sapxep}}`;
    return this.http.get<any[]>(
      baseUrl + `api/Client/GetSanPhamToLoai${params}`
    );
  }
}
