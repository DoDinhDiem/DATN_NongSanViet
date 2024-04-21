import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoaiTinTucComponent } from './loai-tin-tuc.component';

describe('LoaiTinTucComponent', () => {
  let component: LoaiTinTucComponent;
  let fixture: ComponentFixture<LoaiTinTucComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LoaiTinTucComponent]
    });
    fixture = TestBed.createComponent(LoaiTinTucComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
