import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SearchComponent } from './search.component';

@NgModule({
  imports: [RouterModule.forChild([{ path: '', component: SearchComponent }])],
  exports: [RouterModule],
})
export class SearchModule {}
