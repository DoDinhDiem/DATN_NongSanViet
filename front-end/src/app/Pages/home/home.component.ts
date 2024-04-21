import { Component, ElementRef, Renderer2, ViewChild } from '@angular/core';
import { MessageService } from 'primeng/api';
import { CartService } from 'src/app/Service/cart.service';
import { HeThongService } from 'src/app/Service/he-thong.service';
import { HomeService } from 'src/app/Service/home.service';
import { baseUrl } from 'src/app/https';

declare var $: any;
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [MessageService],
})
export class HomeComponent {
  baseUrl = baseUrl;
  currentIndex = 0;

  constructor(
    private homeService: HomeService,
    private heThongService: HeThongService,
    private cartService: CartService,
    private messageService: MessageService
  ) {}

  ngOnInit() {
    this.GetSlide();
    this.GetSanPhamBanChay();
    this.GetSanPhamGiamGia();
    this.GetSanPhamMoi();
    this.startSlideShow();
  }

  images!: any[];
  GetSlide() {
    this.homeService.GetSlide().subscribe((data) => {
      this.images = data;
    });
  }

  sanPhamBanChay: any[] = [];
  GetSanPhamBanChay() {
    this.homeService.GetSanPhamBanChay().subscribe((data) => {
      this.sanPhamBanChay = data;
    });
  }

  sanPhamGiamGia: any[] = [];
  GetSanPhamGiamGia() {
    this.homeService.GetSanPhamGiamGia().subscribe((data) => {
      this.sanPhamGiamGia = data;
    });
  }

  sanPhamMoi: any[] = [];
  GetSanPhamMoi() {
    this.homeService.GetSanPhamMoi().subscribe((data) => {
      this.sanPhamMoi = data;
    });
  }

  startSlideShow(): void {
    setInterval(() => {
      this.currentIndex = (this.currentIndex + 1) % this.images.length;
    }, 2000); // Change image every 2 seconds
  }

  responsiveOptions: any[] = [
    {
      breakpoint: '1024px',
      numVisible: 5,
    },
    {
      breakpoint: '768px',
      numVisible: 3,
    },
    {
      breakpoint: '560px',
      numVisible: 1,
    },
  ];

  responsiveOptionProducts = [
    {
      breakpoint: '1199px',
      numVisible: 1,
      numScroll: 1,
    },
    {
      breakpoint: '991px',
      numVisible: 2,
      numScroll: 1,
    },
    {
      breakpoint: '767px',
      numVisible: 1,
      numScroll: 1,
    },
  ];

  addToCart(product: any) {
    console.log(product);
    this.cartService.addToCart(product);
    this.cartService.loadCart();
    this.messageService.add({
      severity: 'success',
      summary: 'Thông báo',
      detail: 'Thêm vào giỏ hàng thành công',
      life: 3000,
    });
  }
}
