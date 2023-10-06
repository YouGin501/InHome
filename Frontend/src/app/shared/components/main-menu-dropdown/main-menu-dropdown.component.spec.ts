import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainMenuDropdownComponent } from './main-menu-dropdown.component';

describe('MainMenuDropdownComponent', () => {
  let component: MainMenuDropdownComponent;
  let fixture: ComponentFixture<MainMenuDropdownComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MainMenuDropdownComponent]
    });
    fixture = TestBed.createComponent(MainMenuDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
