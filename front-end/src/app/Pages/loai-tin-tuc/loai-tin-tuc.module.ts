import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { LoaiTinTucComponent } from './loai-tin-tuc.component';

@NgModule({
  imports: [
    RouterModule.forChild([{ path: '', component: LoaiTinTucComponent }]),
  ],
  exports: [RouterModule],
})
export class LoaiTinTucModule {}
