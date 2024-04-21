import { Component, ViewChild } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { ILoaiTinTuc } from 'src/app/Models/loai-tin-tuc';
import { LoaiTinTucService } from 'src/app/Service/loai-tin-tuc.service';

@Component({
    selector: 'app-loai-tin-tuc',
    templateUrl: './loai-tin-tuc.component.html',
    styleUrls: ['./loai-tin-tuc.component.css'],
    providers: [MessageService, ConfirmationService],
})
export class LoaiTinTucComponent {
    @ViewChild('dt') dt: Table | undefined;

    title = 'Quản lý loại tin tức';

    loai!: ILoaiTinTuc;

    loais!: ILoaiTinTuc[];

    submitted: boolean = false;

    Dialog: boolean = false;

    Save = 'Lưu';

    constructor(
        private loaiService: LoaiTinTucService,
        private messageService: MessageService,
        private confirmationService: ConfirmationService
    ) {}

    ngOnInit(): void {
        this.loadData();
    }

    loadData() {
        this.loaiService.getAll().subscribe((data) => {
            this.loais = data;
        });
    }

    toggleTrangThai(loai: ILoaiTinTuc) {
        this.loaiService.toggleTrangThai(loai.id).subscribe((data) => {
            this.loadData();
        });
    }
    openNew() {
        this.loai = {};
        this.submitted = false;
        this.Dialog = true;
        this.Save = 'Lưu';
    }

    shouldDisplayImage: boolean = false;
    edit(loai: ILoaiTinTuc) {
        this.loaiService.getById(loai.id).subscribe((data) => {
            this.loai = data;
            this.Dialog = true;
            this.Save = 'Cập nhập';
        });
    }

    deleteOnly(loai: ILoaiTinTuc) {
        this.confirmationService.confirm({
            message: 'Bạn có chắc chắn muốn xóa ' + loai.tenLoaiTin + '?',
            header: 'Thông báo',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.loaiService.delete(loai.id!).subscribe((res) => {
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
        this.loai = {};
        this.shouldDisplayImage = false;
        this.submitted = false;
    }

    save() {
        this.submitted = true;

        if (this.loai.tenLoaiTin) {
            if (this.loai.id) {
                this.loaiService.update(this.loai).subscribe({
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
                this.loaiService.create(this.loai).subscribe({
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

    onInputChange(event: any) {
        if (this.dt) {
            this.dt.filterGlobal(event.target.value, 'contains');
        }
    }
}
