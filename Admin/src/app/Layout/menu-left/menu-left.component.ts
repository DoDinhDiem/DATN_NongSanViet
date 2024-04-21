import { Component } from '@angular/core';
import { AuthService } from 'src/app/Service/auth.service';
import { NhanVienService } from 'src/app/Service/nhan-vien.service';
import { baseUrl } from 'src/app/https';

@Component({
    selector: 'app-menu-left',
    templateUrl: './menu-left.component.html',
    styleUrls: ['./menu-left.component.css'],
})
export class MenuLeftComponent {
    baseUrl = baseUrl;
    public role!: string;
    public fullName!: string;
    public chucvu!: string;
    public id!: string;

    constructor(
        private auth: AuthService,
        private nhanvienService: NhanVienService
    ) {
        this.id = this.auth.getIdFromToken();
        this.getByEmail(this.id);
        this.fullName = this.auth.getfullNameFromToken();
        this.role = this.auth.getRoleFromToken();
    }
    ngOnInit() {}

    avatar: any;
    getByEmail(id: any) {
        this.nhanvienService.getById(id).subscribe((res: any) => {
            this.avatar = res.avatar;
            console.log(res);
        });
    }
}
