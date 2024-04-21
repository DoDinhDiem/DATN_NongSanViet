import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CheckOutComponent } from './check-out.component';

@NgModule({
  imports: [
    RouterModule.forChild([{ path: '', component: CheckOutComponent }]),
  ],
  exports: [RouterModule],
})
export class CheckOutModule {}
