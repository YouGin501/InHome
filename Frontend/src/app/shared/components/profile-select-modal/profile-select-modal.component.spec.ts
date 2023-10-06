import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileSelectModalComponent } from './profile-select-modal.component';

describe('ProfileSelectModalComponent', () => {
  let component: ProfileSelectModalComponent;
  let fixture: ComponentFixture<ProfileSelectModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProfileSelectModalComponent]
    });
    fixture = TestBed.createComponent(ProfileSelectModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
