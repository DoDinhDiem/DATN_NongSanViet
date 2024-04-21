import { Component } from '@angular/core';
import { HeThongService } from 'src/app/Service/he-thong.service';

@Component({
  selector: 'app-gioi-thieu',
  templateUrl: './gioi-thieu.component.html',
  styleUrls: ['./gioi-thieu.component.css'],
})
export class GioiThieuComponent {
  constructor(private heThongService: HeThongService) {}

  ngOnInit() {
    this.GetGioiThieu();
  }
  gioiThieu: any;
  GetGioiThieu() {
    this.heThongService.GetGioiThieu().subscribe((data) => {
      this.gioiThieu = data;
      console.log(data);
    });
  }
}
