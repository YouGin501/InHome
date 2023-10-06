import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DropdownItemModel } from './models/dropdown-item.model';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.scss']
})
export class DropdownComponent implements OnInit {
  @Input() optionItems: DropdownItemModel [] = [];
  @Output() optionChanged = new EventEmitter<string>();

  selectedOption: DropdownItemModel | undefined = undefined;

  dropdownListHidden: boolean = true;

  ngOnInit(): void {
    if(this.optionItems.length){
      this.selectedOption = this.optionItems[0];
    }
  }

  selectItem(newOption: DropdownItemModel){
    this.selectedOption = newOption;
  }

  openDropdownList(){
    this.dropdownListHidden = false;
  }

  closeDropdown(){
    this.dropdownListHidden = true;
  }

  public onOutsideClick(event: any): void {
    this.closeDropdown();
  }
}

