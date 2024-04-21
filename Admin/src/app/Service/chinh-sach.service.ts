import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../https';

@Injectable({
    providedIn: 'root',
})
export class ChinhSachService {
    constructor(private http: HttpClient) {}

    getAll(): Observable<any[]> {
        return this.http.get<any[]>(baseUrl + 'api/ChinhSach/GetAll_ChinhSach');
    }
    create(ChinhSach: any): Observable<any> {
        return this.http.post<any>(
            baseUrl + 'api/ChinhSach/Create_ChinhSach',
            ChinhSach
        );
    }
    update(ChinhSach: any) {
        return this.http.put<any>(
            baseUrl + 'api/ChinhSach/Update_ChinhSach',
            ChinhSach
        );
    }
    delete(id: number): Observable<any> {
        return this.http.delete<any>(
            baseUrl + 'api/ChinhSach/Delete_ChinhSach/' + id
        );
    }
    getById(id: any): Observable<any> {
        return this.http.get<any>(
            baseUrl + 'api/ChinhSach/GetById_ChinhSach/' + id
        );
    }
}
