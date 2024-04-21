import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../https';

@Injectable({
  providedIn: 'root',
})
export class CheckOutService {
  constructor(private http: HttpClient) {}

  GetLinkVnpay(hoadon: any) {
    return this.http.post<any>(baseUrl + 'api/VnPay/VnPay', hoadon);
  }

  GetKhacHangById(id: any) {
    return this.http.get<any>(baseUrl + 'api/Client/GetKhacHangById/' + id);
  }

  createHoaDonBan(HoaDonBan: any): Observable<any> {
    return this.http.post<any>(
      baseUrl + 'api/Client/Create_HoaDonBan',
      HoaDonBan
    );
  }
}
