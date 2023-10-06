import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DropdownValue } from 'src/app/shared/models/dropdown-value';

@Component({
  selector: 'app-profile-dropdown',
  templateUrl: './profile-dropdown.component.html',
  styleUrls: ['./profile-dropdown.component.scss'],
})
export class ProfileDropdownComponent {
  @Input({ required: true }) options!: DropdownValue[];
  @Output() currentSelectionChange = new EventEmitter<DropdownValue>();
  _currentSelection: any;
  dropdownOpened: boolean = false;

  get currentSelection() {
    return this._currentSelection;
  }
  @Input()
  set currentSelection(value) {
    this._currentSelection =
      value === '' || value === null || value === undefined
        ? this.options[0].value
        : value;
    this.dropdownOpened = false;
  }

  setCurrentSelection(option: DropdownValue) {
    this.currentSelection = option;
    this.currentSelectionChange.emit(option);
  }

  openDropdown() {
    this.dropdownOpened = true;
  }

  onOutsideClick($event: any){
    this.dropdownOpened = false;
  }
}
