import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../https';

@Injectable({
    providedIn: 'root',
})
export class LoaiSanPhamService {
    constructor(private http: HttpClient) {}

    getAll(): Observable<any[]> {
        return this.http.get<any[]>(baseUrl + 'api/LoaiNongSan/GetAll_Loai');
    }
    getAllTrangThai(): Observable<any[]> {
        return this.http.get<any[]>(
            baseUrl + 'api/LoaiNongSan/GetAll_Loai_TrangThai'
        );
    }
    create(Loai: any): Observable<any> {
        return this.http.post<any>(
            baseUrl + 'api/LoaiNongSan/Create_Loai',
            Loai
        );
    }
    update(Loai: any) {
        return this.http.put<any>(
            baseUrl + 'api/LoaiNongSan/Update_Loai',
            Loai
        );
    }
    toggleTrangThai(id: any) {
        return this.http.put<any>(
            baseUrl + `api/LoaiNongSan/TrangThai/${id}`,
            null
        );
    }
    delete(id: number): Observable<any> {
        return this.http.delete<any>(
            baseUrl + 'api/LoaiNongSan/Delete_Loai/' + id
        );
    }
    getById(id: any): Observable<any> {
        return this.http.get<any>(
            baseUrl + 'api/LoaiNongSan/GetById_Loai/' + id
        );
    }
}
