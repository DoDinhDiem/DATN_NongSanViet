import { Component } from '@angular/core';
import { MessageService } from 'primeng/api';
import { KhachHangService } from 'src/app/Service/khach-hang.service';

@Component({
    selector: 'app-khach-hang',
    templateUrl: './khach-hang.component.html',
    styleUrls: ['./khach-hang.component.css'],
    providers: [MessageService],
})
export class KhachHangComponent {
    title = 'Quản lý khách hàng';

    khachhangs!: any[];

    constructor(private khachhangService: KhachHangService) {}
    ngOnInit(): void {
        this.loadData();
    }
    loadData() {
        this.khachhangService.getAll().subscribe((data) => {
            this.khachhangs = data;
        });
    }
}
