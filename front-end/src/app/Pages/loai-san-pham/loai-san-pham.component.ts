import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MessageService } from 'primeng/api';
import { CartService } from 'src/app/Service/cart.service';
import { HeThongService } from 'src/app/Service/he-thong.service';
import { ProductCategoryService } from 'src/app/Service/product-category.service';
import { baseUrl } from 'src/app/https';

@Component({
  selector: 'app-loai-san-pham',
  templateUrl: './loai-san-pham.component.html',
  styleUrls: ['./loai-san-pham.component.css'],
  providers: [MessageService],
})
export class LoaiSanPhamComponent {
  baseUrl = baseUrl;
  id!: any;

  constructor(
    private danhMucSanPhamService: ProductCategoryService,
    private heThongService: HeThongService,
    private route: ActivatedRoute,
    private cartService: CartService,
    private messageService: MessageService
  ) {}

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.id = +params['id'];
      this.GetSanPhamByLoai(this.id);
      this.GetLoaiSanPham();
    });
  }

  loaiSanPham: any[] = [];
  GetLoaiSanPham() {
    this.heThongService.GetLoaiSanPham().subscribe((data) => {
      this.loaiSanPham = data;
    });
  }

  sanPhams: any;
  tenLSP: any;
  totalItem: any;
  GetSanPhamByLoai(id: any) {
    this.danhMucSanPhamService
      .GetSanPhamByLoai(id, this.sapxepSelects)
      .subscribe((data) => {
        this.sanPhams = data;
        this.totalItem = this.sanPhams.totalItems;
        this.tenLSP = this.sanPhams.category;
      });
  }

  sapxep: any[] = [
    {
      value: 'date',
      name: 'Mới',
    },
    {
      value: 'pricemin',
      name: 'Giá thấp đến cao',
    },
    {
      value: 'pricemax',
      name: 'Giá cao đến thấp',
    },
    {
      value: 'name',
      name: 'Tên',
    },
  ];
  sapxepSelects: any = 'date';

  onSapXepChange() {
    this.GetSanPhamByLoai(this.id);
  }
  //Phân trang
  p: number = 1;

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
