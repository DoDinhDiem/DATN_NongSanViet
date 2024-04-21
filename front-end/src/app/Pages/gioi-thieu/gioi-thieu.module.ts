import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GioiThieuComponent } from './gioi-thieu.component';

@NgModule({
  imports: [
    RouterModule.forChild([{ path: '', component: GioiThieuComponent }]),
  ],
  exports: [RouterModule],
})
export class GioiThieuModule {}
