import { Component } from '@angular/core';
import { HeThongService } from 'src/app/Service/he-thong.service';

@Component({
  selector: 'app-chinh-sach',
  templateUrl: './chinh-sach.component.html',
  styleUrls: ['./chinh-sach.component.css'],
})
export class ChinhSachComponent {
  constructor(private chinhsachService: HeThongService) {}

  ngOnInit() {
    this.GetChinhSach();
  }

  chinhsach!: any[];
  GetChinhSach() {
    this.chinhsachService.GetChinhSach().subscribe((data) => {
      this.chinhsach = data;
      console.log(data);
    });
  }
}
