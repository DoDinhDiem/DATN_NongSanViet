import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../https';

@Injectable({
    providedIn: 'root',
})
export class GioiThieuService {
    constructor(private http: HttpClient) {}

    getAll(): Observable<any[]> {
        return this.http.get<any[]>(baseUrl + 'api/GioiThieu/GetAll_GioiThieu');
    }
    create(GioiThieu: any): Observable<any> {
        return this.http.post<any>(
            baseUrl + 'api/GioiThieu/Create_GioiThieu',
            GioiThieu
        );
    }
    update(GioiThieu: any) {
        return this.http.put<any>(
            baseUrl + 'api/GioiThieu/Update_GioiThieu',
            GioiThieu
        );
    }
    delete(id: number): Observable<any> {
        return this.http.delete<any>(
            baseUrl + 'api/GioiThieu/Delete_GioiThieu/' + id
        );
    }
    getById(id: any): Observable<any> {
        return this.http.get<any>(
            baseUrl + 'api/GioiThieu/GetById_GioiThieu/' + id
        );
    }
}
