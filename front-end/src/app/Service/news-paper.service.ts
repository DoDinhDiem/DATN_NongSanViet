import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../https';

@Injectable({
  providedIn: 'root',
})
export class NewsPaperService {
  constructor(private http: HttpClient) {}

  GetLoaiTinTuc(): Observable<any[]> {
    return this.http.get<any>(baseUrl + 'api/Client/GetLoaiTinTuc');
  }

  GetTinTuc(): Observable<any[]> {
    return this.http.get<any>(baseUrl + 'api/Client/GetTinTuc');
  }

  GetTinTucByLoai(id: any) {
    return this.http.get<any>(baseUrl + 'api/Client/GetTinTucByLoai/' + id);
  }

  GetTinTucById(id: any) {
    return this.http.get<any>(baseUrl + 'api/Client/GetTinTucById/' + id);
  }

  GetTinTucTuongTu(id: any) {
    return this.http.get<any>(baseUrl + 'api/Client/GetTinTucTuongTu/' + id);
  }
}
