import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NewsPaperService } from 'src/app/Service/news-paper.service';
import { baseUrl } from 'src/app/https';

@Component({
  selector: 'app-chi-tiet-tin-tuc',
  templateUrl: './chi-tiet-tin-tuc.component.html',
  styleUrls: ['./chi-tiet-tin-tuc.component.css'],
})
export class ChiTietTinTucComponent {
  baseUrl = baseUrl;
  constructor(
    private tintucService: NewsPaperService,
    private route: ActivatedRoute
  ) {}
  id!: any;
  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.id = +params['id'];
      this.GetTinTucById(this.id);
    });
    this.GetLoaiTinTuc();
  }

  loaiTin: any;
  GetLoaiTinTuc() {
    this.tintucService.GetLoaiTinTuc().subscribe((data) => {
      this.loaiTin = data;
    });
  }

  chiTiet: any;
  GetTinTucById(id: any) {
    this.tintucService.GetTinTucById(id).subscribe((data) => {
      this.chiTiet = data;
      console.log(this.chiTiet);
    });
  }
}
