import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../https';

@Injectable({
    providedIn: 'root',
})
export class LoaiTinTucService {
    constructor(private http: HttpClient) {}

    getAll(): Observable<any[]> {
        return this.http.get<any[]>(
            baseUrl + 'api/LoaiTinTuc/GetAll_LoaiTinTuc'
        );
    }
    getAllTrangThai(): Observable<any[]> {
        return this.http.get<any[]>(
            baseUrl + 'api/LoaiTinTuc/GetAll_TrangThai_LoaiTinTuc'
        );
    }
    create(Loai: any): Observable<any> {
        return this.http.post<any>(
            baseUrl + 'api/LoaiTinTuc/Create_LoaiTinTuc',
            Loai
        );
    }
    update(Loai: any) {
        return this.http.put<any>(
            baseUrl + 'api/LoaiTinTuc/Update_LoaiTinTuc',
            Loai
        );
    }
    toggleTrangThai(id: any) {
        return this.http.put<any>(
            baseUrl + `api/LoaiTinTuc/TrangThai/${id}`,
            null
        );
    }
    delete(id: number): Observable<any> {
        return this.http.delete<any>(
            baseUrl + 'api/LoaiTinTuc/Delete_LoaiTinTuc/' + id
        );
    }
    getById(id: any): Observable<any> {
        return this.http.get<any>(
            baseUrl + 'api/LoaiTinTuc/GetById_LoaiTinTuc/' + id
        );
    }
}
