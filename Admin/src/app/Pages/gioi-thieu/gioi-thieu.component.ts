import { Component } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { IGioiThieu } from 'src/app/Models/gioi-thieu';
import { GioiThieuService } from 'src/app/Service/gioi-thieu.service';
import { baseUrl } from 'src/app/https';

@Component({
    selector: 'app-gioi-thieu',
    templateUrl: './gioi-thieu.component.html',
    styleUrls: ['./gioi-thieu.component.css'],
    providers: [MessageService, ConfirmationService],
})
export class GioiThieuComponent {
    baseUrl = baseUrl;

    title = 'Quản lý Giới Thiệu';

    gioithieu!: IGioiThieu;

    gioithieus!: IGioiThieu[];

    submitted: boolean = false;

    Dialog: boolean = false;

    Save = 'Lưu';
    constructor(
        private gioithieuService: GioiThieuService,
        private messageService: MessageService,
        private confirmationService: ConfirmationService
    ) {}

    ngOnInit(): void {
        this.loadData();
    }

    loadData() {
        this.gioithieuService.getAll().subscribe((data) => {
            this.gioithieus = data;
        });
    }
    openNew() {
        this.gioithieu = {};
        this.submitted = false;
        this.Dialog = true;
        this.Save = 'Lưu';
    }

    edit(gioithieu: IGioiThieu) {
        this.gioithieuService.getById(gioithieu.id).subscribe((data) => {
            this.gioithieu = data;
            this.Dialog = true;
            this.Save = 'Cập nhập';
        });
    }

    deleteOnly(gioithieu: IGioiThieu) {
        this.confirmationService.confirm({
            message: 'Bạn có chắc chắn muốn xóa ?',
            header: 'Thông báo',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.gioithieuService.delete(gioithieu.id!).subscribe((res) => {
                    this.loadData();
                    this.messageService.add({
                        severity: 'success',
                        summary: 'Successful',
                        detail: res.message,
                        life: 3000,
                    });
                });
            },
        });
    }

    hidenDialog() {
        this.Dialog = false;
        this.gioithieu = {};
        this.submitted = false;
    }

    save() {
        this.submitted = true;

        if (this.gioithieu.gioiThieu1) {
            if (this.gioithieu.id) {
                this.gioithieuService.update(this.gioithieu).subscribe({
                    next: (res) => {
                        this.loadData();
                        this.hidenDialog();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Thông báo',
                            detail: res.message,
                            life: 3000,
                        });
                    },
                    error: (err) => {
                        this.loadData();
                        this.messageService.add({
                            severity: 'error',
                            summary: 'Thông báo',
                            detail: 'Lỗi',
                            life: 3000,
                        });
                    },
                });
            } else {
                this.gioithieuService.create(this.gioithieu).subscribe({
                    next: (res) => {
                        this.loadData();
                        this.hidenDialog();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Thông báo',
                            detail: res.message,
                            life: 3000,
                        });
                    },
                    error: (err) => {
                        this.messageService.add({
                            severity: 'error',
                            summary: 'Thông báo',
                            detail: 'Lỗi',
                            life: 3000,
                        });
                    },
                });
            }
        }
    }
}
