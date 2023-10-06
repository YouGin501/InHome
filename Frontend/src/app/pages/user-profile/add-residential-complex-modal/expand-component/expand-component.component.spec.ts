import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpandComponentComponent } from './expand-component.component';

describe('ExpandComponentComponent', () => {
  let component: ExpandComponentComponent;
  let fixture: ComponentFixture<ExpandComponentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExpandComponentComponent]
    });
    fixture = TestBed.createComponent(ExpandComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
