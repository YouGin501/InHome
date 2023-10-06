import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-modal-window',
  templateUrl: './modal-window.component.html',
  styleUrls: ['./modal-window.component.scss']
})
export class ModalWindowComponent {
  @Input() isOpened: boolean = false;
  @Input() pageTitle: string = '';
  @Input() bgColor: string = 'white';

  @Output() onClosedModal = new EventEmitter();

  closeModal() {
    this.onClosedModal.emit();
  }
}
