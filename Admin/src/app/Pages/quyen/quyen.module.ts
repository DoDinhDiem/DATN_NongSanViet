import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuyenComponent } from './quyen.component';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [RouterModule.forChild([{ path: '', component: QuyenComponent }])],
    exports: [RouterModule],
})
export class QuyenModule {}
