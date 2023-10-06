import { Component, OnInit } from '@angular/core';
import { TranslateService } from 'src/app/services/translate.service';

type HTMLElementEvent<T extends HTMLElement> = Event & {
  target: T; 
}

@Component({
  selector: 'app-search-input',
  templateUrl: './search-input.component.html',
  styleUrls: ['./search-input.component.scss'],
})
export class SearchInputComponent {
  search = 'SEARCH';
  searchInCategory = 'SEARCH_IN_CATEGORY';
  newBuildings = 'NEW_BUILDINGS';
  rent = 'RENT';
  selling = 'SELLING';
  design = 'DESIGN';
  news = 'NEWS';

  isDropdownListOpened: boolean = false;

  searchInput: string = '';
  isReadOnly: boolean = true;

  constructor() {}

  onSearch($event: Event) {
    const searchValue: string = ($event.target as HTMLInputElement).value;
    if (searchValue.length) {
      this.isDropdownListOpened = true;
    } else {
      this.isDropdownListOpened = false;
    }
  }

  onOutsideClick($event: any) {
    this.isDropdownListOpened = false;
  }

  removeReadonly() {
    this.isReadOnly = false;
  }
}
