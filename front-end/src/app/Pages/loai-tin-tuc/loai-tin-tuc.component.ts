import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NewsPaperService } from 'src/app/Service/news-paper.service';
import { baseUrl } from 'src/app/https';

@Component({
  selector: 'app-loai-tin-tuc',
  templateUrl: './loai-tin-tuc.component.html',
  styleUrls: ['./loai-tin-tuc.component.css'],
})
export class LoaiTinTucComponent {
  baseUrl = baseUrl;
  constructor(
    private tintucService: NewsPaperService,
    private route: ActivatedRoute
  ) {}
  id!: any;
  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.id = +params['id'];
      this.GetTinTucByLoai(this.id);
    });
    this.GetLoaiTinTuc();
  }

  loaiTin: any;
  GetLoaiTinTuc() {
    this.tintucService.GetLoaiTinTuc().subscribe((data) => {
      this.loaiTin = data;
    });
  }

  tinTuc: any;
  tenLoai: any;
  GetTinTucByLoai(id: any) {
    this.tintucService.GetTinTucByLoai(id).subscribe((data) => {
      this.tinTuc = data;
      this.tenLoai = this.tinTuc[0]?.tenLoai;
      console.log(this.tenLoai);
    });
  }
  p: number = 1;
}
