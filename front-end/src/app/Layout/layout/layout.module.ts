import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from '../header/header.component';
import { LayoutComponent } from './layout.component';
import { FooterComponent } from '../footer/footer.component';
import { CartComponent } from '../cart/cart.component';
import { HomeComponent } from 'src/app/Pages/home/home.component';
import { HomeModule } from 'src/app/Pages/home/home.module';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { GalleriaModule } from 'primeng/galleria';
import { CarouselModule } from 'primeng/carousel';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { ToastModule } from 'primeng/toast';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { LoaiSanPhamComponent } from 'src/app/Pages/loai-san-pham/loai-san-pham.component';
import { LoaiSanPhamModule } from 'src/app/Pages/loai-san-pham/loai-san-pham.module';
import { ChiTietSanPhamComponent } from 'src/app/Pages/chi-tiet-san-pham/chi-tiet-san-pham.component';
import { ChiTietSanPhamModule } from 'src/app/Pages/chi-tiet-san-pham/chi-tiet-san-pham.module';
import { TinTucModule } from 'src/app/Pages/tin-tuc/tin-tuc.module';
import { TinTucComponent } from 'src/app/Pages/tin-tuc/tin-tuc.component';
import { LoaiTinTucModule } from 'src/app/Pages/loai-tin-tuc/loai-tin-tuc.module';
import { LoaiTinTucComponent } from 'src/app/Pages/loai-tin-tuc/loai-tin-tuc.component';
import { ChiTietTinTucComponent } from 'src/app/Pages/chi-tiet-tin-tuc/chi-tiet-tin-tuc.component';
import { ChiTietTinTucModule } from 'src/app/Pages/chi-tiet-tin-tuc/chi-tiet-tin-tuc.module';
import { ChinhSachComponent } from 'src/app/Pages/chinh-sach/chinh-sach.component';
import { ChinhSachModule } from 'src/app/Pages/chinh-sach/chinh-sach.module';
import { GioiThieuComponent } from 'src/app/Pages/gioi-thieu/gioi-thieu.component';
import { GioiThieuModule } from 'src/app/Pages/gioi-thieu/gioi-thieu.module';
import { LienHeComponent } from 'src/app/Pages/lien-he/lien-he.component';
import { LienHeModule } from 'src/app/Pages/lien-he/lien-he.module';
import { SafePipe } from 'src/app/Pages/lien-he/safe.pipe';
import { GioHangComponent } from 'src/app/Pages/gio-hang/gio-hang.component';
import { GioHangModule } from 'src/app/Pages/gio-hang/gio-hang.module';
import { CheckOutComponent } from 'src/app/Pages/check-out/check-out.component';
import { CheckOutModule } from 'src/app/Pages/check-out/check-out.module';
import { SuccessComponent } from 'src/app/Pages/success/success.component';
import { SuccessModule } from 'src/app/Pages/success/success.module';
import { SearchComponent } from 'src/app/Pages/search/search.component';
import { SearchModule } from 'src/app/Pages/search/search.module';

@NgModule({
  declarations: [
    HeaderComponent,
    LayoutComponent,
    FooterComponent,
    CartComponent,

    HomeComponent,
    LoaiSanPhamComponent,
    ChiTietSanPhamComponent,
    TinTucComponent,
    LoaiSanPhamComponent,
    LoaiTinTucComponent,
    ChiTietTinTucComponent,
    ChinhSachComponent,
    GioiThieuComponent,
    LienHeComponent,
    SafePipe,
    GioHangComponent,
    CheckOutComponent,
    SuccessComponent,
    SearchComponent,
  ],
  imports: [
    HomeModule,
    LoaiSanPhamModule,
    TinTucModule,
    ChiTietSanPhamModule,
    LoaiTinTucModule,
    ChiTietTinTucModule,
    ChinhSachModule,
    GioiThieuModule,
    LienHeModule,
    GioHangModule,
    CheckOutModule,
    SuccessModule,
    SearchModule,

    BrowserModule,
    CommonModule,
    RouterModule,
    HttpClientModule,
    GalleriaModule,
    CarouselModule,
    FormsModule,
    NgxPaginationModule,
    ToastModule,
    BrowserAnimationsModule,
  ],
})
export class LayoutModule {}
