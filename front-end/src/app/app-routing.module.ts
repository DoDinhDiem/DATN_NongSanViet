import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './Layout/layout/layout.component';
import { AuthGuard } from './Guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: '',
        loadChildren: () =>
          import('./Pages/home/home.module').then((m) => m.HomeModule),
      },
      {
        path: 'loaisp/:id',
        loadChildren: () =>
          import('./Pages/loai-san-pham/loai-san-pham.module').then(
            (m) => m.LoaiSanPhamModule
          ),
      },
      {
        path: 'chitietsp/:id',
        loadChildren: () =>
          import('./Pages/chi-tiet-san-pham/chi-tiet-san-pham.module').then(
            (m) => m.ChiTietSanPhamModule
          ),
      },
      {
        path: 'tintuc',
        loadChildren: () =>
          import('./Pages/tin-tuc/tin-tuc.module').then((m) => m.TinTucModule),
      },
      {
        path: 'loaitintuc/:id',
        loadChildren: () =>
          import('./Pages/loai-tin-tuc/loai-tin-tuc.module').then(
            (m) => m.LoaiTinTucModule
          ),
      },
      {
        path: 'chitiettt/:id',
        loadChildren: () =>
          import('./Pages/chi-tiet-tin-tuc/chi-tiet-tin-tuc.module').then(
            (m) => m.ChiTietTinTucModule
          ),
      },
      {
        path: 'chinhsach',
        loadChildren: () =>
          import('./Pages/chinh-sach/chinh-sach.module').then(
            (m) => m.ChinhSachModule
          ),
      },
      {
        path: 'gioithieu',
        loadChildren: () =>
          import('./Pages/gioi-thieu/gioi-thieu.module').then(
            (m) => m.GioiThieuModule
          ),
      },
      {
        path: 'lienhe',
        loadChildren: () =>
          import('./Pages/lien-he/lien-he.module').then((m) => m.LienHeModule),
      },
      {
        path: 'giohang',
        loadChildren: () =>
          import('./Pages/gio-hang/gio-hang.module').then(
            (m) => m.GioHangModule
          ),
        canActivate: [AuthGuard],
      },
      {
        path: 'checkout',
        loadChildren: () =>
          import('./Pages/check-out/check-out.module').then(
            (m) => m.CheckOutModule
          ),
        canActivate: [AuthGuard],
      },

      {
        path: 'success',
        loadChildren: () =>
          import('./Pages/success/success.module').then((m) => m.SuccessModule),
        canActivate: [AuthGuard],
      },
      {
        path: 'search/:searchTerm',
        loadChildren: () =>
          import('./Pages/search/search.module').then((m) => m.SearchModule),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
