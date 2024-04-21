import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../https';

@Injectable({
  providedIn: 'root',
})
export class ProductDetailService {
  constructor(private http: HttpClient) {}

  GetChiTietSanPham(id: any) {
    return this.http.get<any>(baseUrl + 'api/Client/GetChiTiet/' + id);
  }

  GetSanPhamTuongTu(spid: any, loaiid: any) {
    return this.http.get<any>(
      baseUrl + 'api/Client/GetTuongTu/' + spid + '/' + loaiid
    );
  }
}
