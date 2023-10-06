import {
  Component,
  ComponentFactoryResolver,
  ComponentRef,
  Inject,
  Injectable,
  ViewContainerRef,
  ViewRef,
} from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { MessageInfoComponent } from '../components/message-info/message-info.component';

export interface AuthModalState {
  isOpened: boolean;
}

@Injectable({
  providedIn: 'root',
})
export class MessageInfoService {
  rootViewContainer!: ViewContainerRef;

  public showSuccessMessage(message: string) {
    if (this.rootViewContainer) {
      const component = this.createComponent(message, 'success');
      setTimeout(() => {
        this.closeMessage(component);
      }, 3000);
    }
  }

  setRootViewContainerRef(viewContainerRef: ViewContainerRef) {
    this.rootViewContainer = viewContainerRef;
  }

  showErrorMessage(message: string) {
    if (this.rootViewContainer) {
      const component = this.createComponent(message, 'error');
      setTimeout(() => {
        this.closeMessage(component);
      }, 3000);
    }
  }

  closeMessage(component: ComponentRef<MessageInfoComponent>) {
    const index = this.rootViewContainer.indexOf(component.hostView);
    if (index != -1) this.rootViewContainer.remove(index);
  }

  private createComponent(
    message: string,
    type: 'error' | 'success'
  ): ComponentRef<MessageInfoComponent> {
    const component =
      this.rootViewContainer?.createComponent(MessageInfoComponent);
    component.instance.message = message;
    component.instance.messageType = type;
    component.instance.selfComponentRef = component;
    this.rootViewContainer.insert(component.hostView);
    return component;
  }
}
