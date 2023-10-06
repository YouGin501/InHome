import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSellRentModalComponent } from './view-sell-rent-modal.component';

describe('ViewSellRentModalComponent', () => {
  let component: ViewSellRentModalComponent;
  let fixture: ComponentFixture<ViewSellRentModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewSellRentModalComponent]
    });
    fixture = TestBed.createComponent(ViewSellRentModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
