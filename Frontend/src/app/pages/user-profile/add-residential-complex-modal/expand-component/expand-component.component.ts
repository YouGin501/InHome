import {
  Component,
  Input,
  ViewChild,
} from '@angular/core';
import { AddApartmentComponent } from '../add-apartment/add-apartment.component';
import { ModalWindowComponent } from 'src/app/shared/components/modal-window/modal-window.component';
import { AddApartmentService } from '../services/add-apartment.service';

@Component({
  selector: 'app-expand-component',
  templateUrl: './expand-component.component.html',
  styleUrls: ['./expand-component.component.scss'],
})
export class ExpandComponentComponent {
  @Input() appartType!: string;
  @ViewChild('addAppartModal') addAppartModal:
    | AddApartmentComponent
    | undefined;

  isOpened: boolean = false;
  @Input() appartments: any[] = [];

  constructor(private readonly addApartmentService: AddApartmentService) {}

  get filteredAppartments() {
    return this.appartments.filter(
      (x) => x.residentialComplexAppartmentType === this.appartType
    );
  }

  openExpand() {
    this.isOpened = !this.isOpened;
  }

  createAppartment() {
    this.addApartmentService.setModalState({
      isOpened: true,
      appartType: this.appartType,
    });
  }

  getImgUrl(url: string): string {
    return `url(${url})`;
  }

  deleteAppartment(id: number) {
    this.appartments = this.appartments.filter((x) => x.id != id);
  }

  editAppartment(item: any) {
    console.log(item, 'item')
    this.addApartmentService.setModalState({
      isOpened: true,
      appartType: this.appartType,
      project: item
    });
  }
}
