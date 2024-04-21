import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChinhSachComponent } from './chinh-sach.component';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [
        RouterModule.forChild([{ path: '', component: ChinhSachComponent }]),
    ],
    exports: [RouterModule],
})
export class ChinhSachModule {}
