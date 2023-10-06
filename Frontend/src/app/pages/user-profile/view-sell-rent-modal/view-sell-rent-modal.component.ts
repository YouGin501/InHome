import { Component, Input } from '@angular/core';
import { BuildingType } from 'src/app/models/building-type.model';
import { ImageUrl } from 'src/app/models/image-url.model';
import { RealEstateProject } from 'src/app/models/real-estate-project.model';
import { RealEstateService } from 'src/app/services/real-estate.service';
import { RentService } from 'src/app/services/rent.service';

@Component({
  selector: 'app-view-sell-rent-modal',
  templateUrl: './view-sell-rent-modal.component.html',
  styleUrls: ['./view-sell-rent-modal.component.scss'],
})
export class ViewSellRentModalComponent {
  @Input() modalType: string | null = null;

  item: RealEstateProject | null = null;
  sideImages: ImageUrl[] = [];
  mainImage: ImageUrl | null = null;

  showModal: boolean = false;
  ownerText = 'ownerText';
  chatText = 'chatText';
  websiteText = 'webstiteText';

  projectTypes = BuildingType;

  constructor(
    private readonly realEstateService: RealEstateService,
    private readonly rentService: RentService
  ) {}

  closeModal() {
    this.showModal = false;
  }

  openModal(item: any, postType: string) {
    this.showModal = true;
    this.item = item;
    console.log(postType, 'type')
    if (postType === 'SELLING') {
      this.realEstateService.getById(item.id).subscribe((res) => {
        this.item = { ...res, photosUrls: res.photosUrls.slice(0, 5) };
        this.mainImage = this.item.photosUrls[0];
        if (this.item.photosUrls.length > 1) {
          this.sideImages = this.item.photosUrls.slice(1);
        }
      });
    } else if (postType === 'RENT') {
      this.rentService.getById(item.id).subscribe((res) => {
        this.item = { ...res, photosUrls: res.photosUrls.slice(0, 5) };
        this.mainImage = this.item.photosUrls[0];
        if (this.item.photosUrls.length > 1) {
          this.sideImages = this.item.photosUrls.slice(1);
        }
      });
    }
  }

  onImgClick(id: number) {
    if (id === this.mainImage?.id || !this.item) {
      return;
    }

    const searchedItem = this.item.photosUrls.find((i) => i.id === id);
    if (!searchedItem) {
      return;
    }
    this.mainImage = searchedItem;
    this.sideImages = this.item.photosUrls.filter((i) => i.id !== id);
  }
}
