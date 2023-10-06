import { Component, Input } from '@angular/core';
import { Document } from 'src/app/models/document.model';

@Component({
  selector: 'app-documents-modal',
  templateUrl: './documents-modal.component.html',
  styleUrls: ['./documents-modal.component.scss'],
})
export class DocumentsModalComponent {
  isOpenedModal: boolean = false;
  documentsText = 'DOCUMENTS';
  @Input({required: true}) documents?: Document[] = [];

  closeModal() {
    this.isOpenedModal = false;
  }

  openModal() {
    this.isOpenedModal = true;
  }
}
