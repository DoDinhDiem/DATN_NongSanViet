import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MessageService } from 'primeng/api';
import { CartService } from 'src/app/Service/cart.service';
import { HeThongService } from 'src/app/Service/he-thong.service';
import { ProductDetailService } from 'src/app/Service/product-detail.service';
import { baseUrl } from 'src/app/https';

@Component({
  selector: 'app-chi-tiet-san-pham',
  templateUrl: './chi-tiet-san-pham.component.html',
  styleUrls: ['./chi-tiet-san-pham.component.css'],
  providers: [MessageService],
})
export class ChiTietSanPhamComponent {
  baseUrl = baseUrl;
  id!: any;
  constructor(
    private heThongService: HeThongService,
    private chiTietSanPhamService: ProductDetailService,
    private route: ActivatedRoute,
    private cartService: CartService,
    private messageService: MessageService
  ) {}
  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.id = +params['id'];
      this.GetChiTietSanPham(this.id);
    });
    this.GetLoaiSanPham();
  }
  loaiSanPham: any[] = [];
  GetLoaiSanPham() {
    this.heThongService.GetLoaiSanPham().subscribe((data) => {
      this.loaiSanPham = data;
    });
  }

  sanPham: any | undefined;
  tenLoai: any;
  thongSos: any[] = [];
  Images: any[] = [];

  GetChiTietSanPham(id: any) {
    this.chiTietSanPhamService.GetChiTietSanPham(id).subscribe((data) => {
      this.sanPham = data;
      this.tenLoai = data.tenLoai;
      this.Images = data.imageList;
      const loaiid = data.loaiId;
      console.log(data);

      this.GetSanPhamTuongTu(id, loaiid);
    });
  }

  sanPhams: any[] = [];
  GetSanPhamTuongTu(id: any, loaiid: any) {
    this.chiTietSanPhamService
      .GetSanPhamTuongTu(id, loaiid)
      .subscribe((data) => {
        this.sanPhams = data;
      });
  }

  get activeIndex(): number {
    return this._activeIndex;
  }

  set activeIndex(newValue) {
    if (this.Images && 0 <= newValue && newValue <= this.Images.length - 1) {
      this._activeIndex = newValue;
    }
  }

  _activeIndex: number = 2;

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

  next() {
    this.activeIndex++;
  }

  prev() {
    this.activeIndex--;
  }

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

  quantity: number = 1;

  increment() {
    this.quantity++;
  }

  decrement() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

  addToCart(product: any) {
    this.cartService.addToCartDetail(product, this.quantity);
    this.cartService.loadCart();
    this.messageService.add({
      severity: 'success',
      summary: 'Thông báo',
      detail: 'Thêm vào giỏ hàng thành công',
      life: 3000,
    });
  }
}
