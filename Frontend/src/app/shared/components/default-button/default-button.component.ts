import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-default-button',
  templateUrl: './default-button.component.html',
  styleUrls: ['./default-button.component.scss']
})
export class DefaultButtonComponent {
  @Input() buttonText: string = '';
  @Input() buttonImg: string | undefined;
  @Input() maxWidth: string | undefined;
  @Output() OnButtonCliked = new EventEmitter();
  
  clicked(){
    this.OnButtonCliked.emit();
  }
}
