import {
  Component,
  ComponentRef,
  ElementRef,
  Input,
  ViewChild,
  ViewContainerRef,
} from '@angular/core';
import { MessageInfoService } from '../../services/message-info.service';

@Component({
  selector: 'app-message-info',
  templateUrl: './message-info.component.html',
  styleUrls: ['./message-info.component.scss'],
})
export class MessageInfoComponent {
  constructor(private readonly mesasageInfoService: MessageInfoService) {}
  @Input() message: string = '';
  @Input()
  messageType!: 'error' | 'success';
  @Input() selfComponentRef!: ComponentRef<MessageInfoComponent>;

  errorText = 'ERROR';
  successText = 'SUCCESS';

  close() {
    this.mesasageInfoService.closeMessage(this.selfComponentRef);
  }
}
