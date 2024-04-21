import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GioiThieuComponent } from './gioi-thieu.component';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [
        RouterModule.forChild([{ path: '', component: GioiThieuComponent }]),
    ],
    exports: [RouterModule],
})
export class GioiThieuModule {}
