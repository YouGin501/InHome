import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocumentsModalComponent } from './documents-modal.component';

describe('DocumentsModalComponent', () => {
  let component: DocumentsModalComponent;
  let fixture: ComponentFixture<DocumentsModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DocumentsModalComponent]
    });
    fixture = TestBed.createComponent(DocumentsModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
