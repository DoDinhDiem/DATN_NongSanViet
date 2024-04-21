import { baseUrl } from 'src/app/https';
import { Component } from '@angular/core';
import { NewsPaperService } from 'src/app/Service/news-paper.service';

@Component({
  selector: 'app-tin-tuc',
  templateUrl: './tin-tuc.component.html',
  styleUrls: ['./tin-tuc.component.css'],
})
export class TinTucComponent {
  baseUrl = baseUrl;
  constructor(private tintucService: NewsPaperService) {}

  ngOnInit() {
    this.GetLoaiTinTuc();
    this.GetTinTuc();
  }

  loaiTin: any;
  GetLoaiTinTuc() {
    this.tintucService.GetLoaiTinTuc().subscribe((data) => {
      this.loaiTin = data;
    });
  }

  tinTuc: any;
  GetTinTuc() {
    this.tintucService.GetTinTuc().subscribe((data) => {
      this.tinTuc = data;
      console.log(this.tinTuc);
    });
  }
  p: number = 1;
}
