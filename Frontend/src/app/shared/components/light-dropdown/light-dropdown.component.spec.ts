import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LightDropdownComponent } from './light-dropdown.component';

describe('LightDropdownComponent', () => {
  let component: LightDropdownComponent;
  let fixture: ComponentFixture<LightDropdownComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LightDropdownComponent]
    });
    fixture = TestBed.createComponent(LightDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
