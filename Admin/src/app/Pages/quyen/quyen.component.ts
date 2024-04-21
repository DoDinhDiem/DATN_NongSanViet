import { ConfirmationService, MessageService } from 'primeng/api';
import { Component } from '@angular/core';
import { IQuyen } from 'src/app/Models/quyen';
import { QuyenService } from 'src/app/Service/quyen.service';
import { baseUrl } from 'src/app/https';

@Component({
    selector: 'app-quyen',
    templateUrl: './quyen.component.html',
    styleUrls: ['./quyen.component.css'],
    providers: [MessageService, ConfirmationService],
})
export class QuyenComponent {
    baseUrl = baseUrl;

    title = 'Quản lý quyền';

    quyen!: IQuyen;

    quyens!: IQuyen[];

    submitted: boolean = false;

    Dialog: boolean = false;

    Save = 'Lưu';
    constructor(
        private quyenService: QuyenService,
        private messageService: MessageService,
        private confirmationService: ConfirmationService
    ) {}

    ngOnInit(): void {
        this.loadData();
    }

    loadData() {
        this.quyenService.getAll().subscribe((data) => {
            this.quyens = data;
        });
    }
    openNew() {
        this.quyen = {};
        this.submitted = false;
        this.Dialog = true;
        this.Save = 'Lưu';
    }

    edit(quyen: IQuyen) {
        this.quyenService.getById(quyen.id).subscribe((data) => {
            this.quyen = data;
            this.Dialog = true;
            this.Save = 'Cập nhập';
        });
    }

    deleteOnly(quyen: IQuyen) {
        this.confirmationService.confirm({
            message: 'Bạn có chắc chắn muốn xóa ?',
            header: 'Thông báo',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.quyenService.delete(quyen.id!).subscribe((res) => {
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
        this.quyen = {};
        this.submitted = false;
    }
    toggleTrangThai(quyen: IQuyen) {
        this.quyenService.toggleTrangThai(quyen.id).subscribe(() => {
            this.loadData();
        });
    }

    save() {
        this.submitted = true;

        if (this.quyen.tenQuyen) {
            if (this.quyen.id) {
                this.quyenService.update(this.quyen).subscribe({
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
                this.quyenService.create(this.quyen).subscribe({
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
