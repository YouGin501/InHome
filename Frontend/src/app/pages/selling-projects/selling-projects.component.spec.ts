import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SellingProjectsComponent } from './selling-projects.component';

describe('DesignProjectsComponent', () => {
  let component: SellingProjectsComponent;
  let fixture: ComponentFixture<SellingProjectsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SellingProjectsComponent]
    });
    fixture = TestBed.createComponent(SellingProjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
