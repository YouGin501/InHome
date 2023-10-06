import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TabComponent } from './tab/tab.component';

export interface TabInput {
  title: string;
  active: boolean;
  items: [];
  isShown: boolean;
}

@Component({
  selector: 'app-tab-holder',
  templateUrl: './tab-holder.component.html',
  styleUrls: ['./tab-holder.component.scss'],
})
export class TabHolderComponent {
  @Input() tabs: TabInput[] = [];
  @Output() OnTabSelected = new EventEmitter<string>();

  constructor() {}

  selectTab(tab: TabComponent) {
    console.log(this.tabs, 'selecte');
    this.OnTabSelected.emit(tab.title);
  }
}
