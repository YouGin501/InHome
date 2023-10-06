import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddResidentialComplexModalComponent } from './add-residential-complex-modal.component';

describe('AddResidentialComplexModalComponent', () => {
  let component: AddResidentialComplexModalComponent;
  let fixture: ComponentFixture<AddResidentialComplexModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddResidentialComplexModalComponent]
    });
    fixture = TestBed.createComponent(AddResidentialComplexModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
