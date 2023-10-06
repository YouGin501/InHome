import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorizationModalComponent } from './authorization-modal.component';

describe('AuthorizationModalComponent', () => {
  let component: AuthorizationModalComponent;
  let fixture: ComponentFixture<AuthorizationModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AuthorizationModalComponent]
    });
    fixture = TestBed.createComponent(AuthorizationModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
