import { Component } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { IChinhSach } from 'src/app/Models/chinh-sach';
import { ChinhSachService } from 'src/app/Service/chinh-sach.service';

@Component({
    selector: 'app-chinh-sach',
    templateUrl: './chinh-sach.component.html',
    styleUrls: ['./chinh-sach.component.css'],
    providers: [MessageService, ConfirmationService],
})
export class ChinhSachComponent {
    title = 'Quản lý chính sách';

    chinhsach!: IChinhSach;

    chinhsachs!: IChinhSach[];

    submitted: boolean = false;

    Dialog: boolean = false;

    Save = 'Lưu';
    constructor(
        private chinhSachService: ChinhSachService,
        private messageService: MessageService,
        private confirmationService: ConfirmationService
    ) {}

    ngOnInit(): void {
        this.loadData();
    }

    loadData() {
        this.chinhSachService.getAll().subscribe((data) => {
            this.chinhsachs = data;
        });
    }
    openNew() {
        this.chinhsach = {};
        this.submitted = false;
        this.Dialog = true;
        this.Save = 'Lưu';
    }

    edit(chinhsach: IChinhSach) {
        this.chinhSachService.getById(chinhsach.id).subscribe((data) => {
            this.chinhsach = data;
            this.Dialog = true;
            this.Save = 'Cập nhập';
        });
    }

    deleteOnly(chinhsach: IChinhSach) {
        this.confirmationService.confirm({
            message: 'Bạn có chắc chắn muốn xóa ?',
            header: 'Thông báo',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.chinhSachService.delete(chinhsach.id!).subscribe((res) => {
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
        this.chinhsach = {};
        this.submitted = false;
    }

    save() {
        this.submitted = true;

        if (this.chinhsach.tieuDe) {
            if (this.chinhsach.id) {
                this.chinhSachService.update(this.chinhsach).subscribe({
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
                this.chinhSachService.create(this.chinhsach).subscribe({
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
