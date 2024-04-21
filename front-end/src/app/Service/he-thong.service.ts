import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../https';

@Injectable({
  providedIn: 'root',
})
export class HeThongService {
  constructor(private http: HttpClient) {}

  GetLoaiSanPham(): Observable<any[]> {
    return this.http.get<any>(baseUrl + 'api/Client/All_Loai');
  }

  GetSearchSanPham(key: string): Observable<any[]> {
    const params = `?key=${key}`;
    return this.http.get<any[]>(
      baseUrl + `api/Client/GetSearchSanPham${params}`
    );
  }

  GetGioiThieu(): Observable<any> {
    return this.http.get<any>(baseUrl + 'api/Client/GetGioiThieu');
  }

  GetLienHe(): Observable<any> {
    return this.http.get<any>(baseUrl + 'api/Client/GetLienHe');
  }

  GetChinhSach(): Observable<any[]> {
    return this.http.get<any>(baseUrl + 'api/Client/GetChinhSach');
  }
}
