import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ChinhSachComponent } from './chinh-sach.component';

@NgModule({
  imports: [
    RouterModule.forChild([{ path: '', component: ChinhSachComponent }]),
  ],
  exports: [RouterModule],
})
export class ChinhSachModule {}
