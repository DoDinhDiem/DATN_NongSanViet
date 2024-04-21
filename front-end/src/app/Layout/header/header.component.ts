import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HeThongService } from 'src/app/Service/he-thong.service';
import { baseUrl } from 'src/app/https';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent {
  baseUrl = baseUrl;
  searchTerm = '';
  constructor(
    private heThongService: HeThongService,
    // private accountService: AccountService,
    activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    activatedRoute.params.subscribe((params: any) => {
      if (params.serchTerm) {
        this.searchTerm = params.searchTerm;
      }
    });
    // this.isLoggedIn = this.accountService.isLoggedIn();
  }

  ngOnInit() {
    this.GetLoaiSanPham();
  }

  loaiSanPham: any[] = [];
  GetLoaiSanPham() {
    this.heThongService.GetLoaiSanPham().subscribe((data) => {
      this.loaiSanPham = data;
    });
  }

  search(term: string): void {
    if (term) this.router.navigateByUrl('/search/' + term);
  }
}
