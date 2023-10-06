import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RentProjectsComponent } from './rent-projects.component';

describe('DesignProjectsComponent', () => {
  let component: RentProjectsComponent;
  let fixture: ComponentFixture<RentProjectsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RentProjectsComponent]
    });
    fixture = TestBed.createComponent(RentProjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
