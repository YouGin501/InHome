import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { FileService } from 'src/app/services/file.service';
import { RealEstateService } from 'src/app/services/real-estate.service';
import { RentService } from 'src/app/services/rent.service';
import { MessageInfoService } from 'src/app/shared/services/message-info.service';
import { Location } from '../../../models/location.model';
import { RentProject } from 'src/app/models/rent-project.model';
import { RealEstateStatus } from 'src/app/models/real-estate-status.model';
import { switchMap } from 'rxjs';
import { ProjectType } from 'src/app/models/project-type.model';
import { DropdownValue } from 'src/app/shared/models/dropdown-value';
import { BuildingType } from 'src/app/models/building-type.model';
import { RealEstateProject } from 'src/app/models/real-estate-project.model';

@Component({
  selector: 'app-add-sell-rent-modal',
  templateUrl: './add-sell-rent-modal.component.html',
  styleUrls: ['./add-sell-rent-modal.component.scss'],
})
export class AddSellRentModalComponent implements OnInit {
  postForm = new FormGroup({
    title: new FormControl('', Validators.required),
    description: new FormControl(''),
    hashtags: new FormControl(''),
    location: new FormGroup({
      country: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      address: new FormControl('', Validators.required),
    }),
    livingSpace: new FormControl(null, Validators.required),
    advertisingLabel: new FormControl(''),
    price: new FormControl(null, Validators.required),
    minimalRentPeriod: new FormControl(null),
    roomsNumber: new FormControl(null, Validators.required),
  });

  createPostModal = false;
  photoToUpload: File[] = [];
  currentUserId?: number;
  closeText = 'CLOSE';
  publishText = 'PUBLISH';
  modalType?: 'rent' | 'sell';
  addRentText = 'ADD_RENT';
  addSellingText = 'ADD_SELLING';
  ownerText = 'OWNER_AGENCY';
  websiteText = 'OFF_WEBSITE';
  chatText = 'CHAT_LOW_CASE';
  charactericsText = 'CHARACTERISTICS';
  locationText = 'LOCATION';

  realEstateStatusOptions: DropdownValue[] = [
    {
      value: RealEstateStatus.NewBuilding.valueOf(),
      title: 'NEW_BUILDING',
    },
    {
      value: RealEstateStatus.OldBuilding.valueOf(),
      title: 'OLD_BUILDING',
    },
    {
      value: RealEstateStatus.UnderConstruction.valueOf(),
      title: 'UNDER_CONSTRUCTION',
    },
  ];

  buildingTypeOptions: DropdownValue[] = [
    {
      value: BuildingType.Apartment.valueOf(),
      title: 'APPARTMENT',
    },
    {
      value: BuildingType.House.valueOf(),
      title: 'HOUSE',
    },
  ];

  @Output() OnSellingAdded = new EventEmitter();
  @Output() OnRentAdded = new EventEmitter();
  currentRealEstateStatus!: DropdownValue;
  currentBuildingType!: DropdownValue;

  constructor(
    private readonly route: ActivatedRoute,
    private readonly rentService: RentService,
    private readonly fileService: FileService,
    private readonly messageInfoService: MessageInfoService,
    private readonly realEstateService: RealEstateService
  ) {}

  ngOnInit(): void {
    this.currentUserId = Number(this.route.snapshot.paramMap.get('id'));
    this.currentRealEstateStatus = this.realEstateStatusOptions[0];
    this.currentBuildingType = this.buildingTypeOptions[0];
  }

  openModal(modalType: 'rent' | 'sell') {
    this.createPostModal = true;
    this.modalType = modalType;
  }

  closeModal() {
    this.createPostModal = false;
    this.postForm.reset();
  }

  onPhotoInput(fileInput: any) {
    this.photoToUpload = <Array<File>>fileInput.target.files;
  }

  selectType($event: DropdownValue) {
    console.log($event, 'event');
    this.currentRealEstateStatus = $event;
  }

  selectBuildingType($event: DropdownValue) {
    console.log($event, 'event');
    this.currentBuildingType = $event;
  }

  createPost() {
    const formData = new FormData();
    for (const photo of this.photoToUpload) {
      formData.append('photos', photo, photo.name);
    }

    if (this.postForm.valid && this.currentUserId) {
      const location: Location = {
        id: 0,
        address: this.postForm.value.location?.address ?? '',
        city: this.postForm.value.location?.city ?? '',
        country: this.postForm.value.location?.country ?? '',
      };

      if (this.modalType === 'rent') {
        const newProject: RentProject = {
          id: 0,
          title: this.postForm.value.title ?? '',
          location: location,
          hashtags: [],
          description: this.postForm.value.description ?? '',
          photosUrls: [],
          comments: [],
          likes: [],
          userId: this.currentUserId,
          livingSpace: this.postForm.value.livingSpace ?? 0,
          realEstateStatus: this.currentRealEstateStatus
            .value as RealEstateStatus,
          advertisingLabel: this.postForm.value.advertisingLabel ?? '',
          price: this.postForm.value.price ?? 0,
          projectType: ProjectType.Rent,
          minimalRentPeriod: this.postForm.value.minimalRentPeriod ?? 0,
          numberOfRooms: this.postForm.value.roomsNumber ?? 0,
          buildingType: this.currentBuildingType.value as number
        };

        this.rentService
          .add(newProject)
          .pipe(
            switchMap((post) =>
              this.fileService.addRentPhoto(formData, post.id)
            )
          )
          .subscribe((x) => {
            this.messageInfoService.showSuccessMessage(
              'Rent offer successfully created!'
            );
            this.closeModal();
            this.OnRentAdded.emit();
          });
      } else {
        const newProject: RealEstateProject = {
          id: 0,
          title: this.postForm.value.title ?? '',
          location: location,
          hashtags: [],
          description: this.postForm.value.description ?? '',
          photosUrls: [],
          comments: [],
          likes: [],
          userId: this.currentUserId,
          livingSpace: this.postForm.value.livingSpace ?? 0,
          realEstateStatus: this.currentRealEstateStatus
            .value as RealEstateStatus,
          advertisingLabel: this.postForm.value.advertisingLabel ?? '',
          price: this.postForm.value.price ?? 0,
          projectType: ProjectType.RealEstate,
          numberOfRooms: this.postForm.value.roomsNumber ?? 0,
          buildingType: this.currentBuildingType.value as number,
        };

        this.realEstateService
          .add(newProject)
          .pipe(
            switchMap((post) =>
              this.fileService.addRealEstatePhoto(formData, post.id)
            )
          )
          .subscribe((x) => {
            this.messageInfoService.showSuccessMessage(
              'Selling offer successfully created!'
            );
            this.closeModal();
            this.OnSellingAdded.emit();
          });
      }
    }
  }
}
