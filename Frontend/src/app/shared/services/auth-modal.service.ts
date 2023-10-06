import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User, UserRole } from 'src/app/models/user.model';

export interface AuthModalState {
    modalType: 'signin' | 'signup',
    isOpened: boolean
}

@Injectable({
  providedIn: 'root',
})

export class AuthModalService {
  private modalState: BehaviorSubject<AuthModalState | null> =
    new BehaviorSubject<AuthModalState | null>(null);

  public setModalState(modalState: AuthModalState) {
    this.modalState.next(modalState);
  }

  public getCurrentModalState() {
    return this.modalState.asObservable();
  }
}
