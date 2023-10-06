import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSellRentModalComponent } from './add-sell-rent-modal.component';

describe('AddSellRentModalComponent', () => {
  let component: AddSellRentModalComponent;
  let fixture: ComponentFixture<AddSellRentModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddSellRentModalComponent]
    });
    fixture = TestBed.createComponent(AddSellRentModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
