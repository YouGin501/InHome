import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { RealEstateProject } from 'src/app/models/real-estate-project.model';

export interface ModalState {
  isOpened: boolean;
  project?: RealEstateProject | null,
  appartType?: string
}

@Injectable({
  providedIn: 'root',
})
export class AddApartmentService {
  private modalState: BehaviorSubject<ModalState> =
    new BehaviorSubject<ModalState>({
        isOpened: false
    });

  public setModalState(modalState: ModalState) {
    this.modalState.next(modalState);
  }

  public getCurrentModalState() {
    return this.modalState.asObservable();
  }
}
