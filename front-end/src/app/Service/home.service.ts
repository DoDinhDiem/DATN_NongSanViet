import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../https';

@Injectable({
  providedIn: 'root',
})
export class HomeService {
  constructor(private http: HttpClient) {}

  GetSlide(): Observable<any[]> {
    return this.http.get<any>(baseUrl + 'api/Client/All_Slide');
  }

  GetSanPhamGiamGia(): Observable<any[]> {
    return this.http.get<any>(baseUrl + 'api/Client/GetSanPhamGiamGia');
  }

  GetSanPhamMoi(): Observable<any[]> {
    return this.http.get<any>(baseUrl + 'api/Client/GetSanPhamMoi');
  }

  GetSanPhamBanChay(): Observable<any[]> {
    return this.http.get<any>(baseUrl + 'api/Client/GetSanPhamBanChay');
  }
}
