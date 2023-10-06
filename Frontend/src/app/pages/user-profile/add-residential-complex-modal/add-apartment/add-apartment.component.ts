import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RealEstateProject } from 'src/app/models/real-estate-project.model';
import { ActivatedRoute } from '@angular/router';
import { RealEstateStatus } from 'src/app/models/real-estate-status.model';
import { ProjectType } from 'src/app/models/project-type.model';
import { AddApartmentService } from '../services/add-apartment.service';
import { BuildingType } from 'src/app/models/building-type.model';

@Component({
  selector: 'app-add-apartment',
  templateUrl: './add-apartment.component.html',
  styleUrls: ['./add-apartment.component.scss'],
})
export class AddApartmentComponent {
  postForm = new FormGroup({
    title: new FormControl('', Validators.required),
    description: new FormControl(''),
    livingSpace: new FormControl(null, Validators.required),
    price: new FormControl(null, Validators.required),
    roomsNumber: new FormControl(null, Validators.required),
  });

  isModalOpened = false;
  photoToUpload: File[] = [];
  currentUserId?: number;
  closeText = 'CLOSE';
  publishText = 'PUBLISH';
  charactericsText = 'CHARACTERISTICS';
  currentAppartType = '';
  currentProject: any | null;

  @Output() OnSellingAdded = new EventEmitter();

  constructor(
    private readonly route: ActivatedRoute,
    private readonly addApartmentService: AddApartmentService
  ) {}

  ngOnInit(): void {
    this.currentUserId = Number(this.route.snapshot.paramMap.get('id'));
    this.addApartmentService.getCurrentModalState().subscribe((x) => {
      this.isModalOpened = x?.isOpened;
      this.currentAppartType = x.appartType ?? '';
      this.currentProject = x.project;

      console.log(this.currentProject, 'project')
      if (this.currentProject) {
        this.postForm.patchValue({
          title: this.currentProject.title,
          description: this.currentProject.description,
          livingSpace: this.currentProject.livingSpace,
          price: this.currentProject.price,
          roomsNumber: this.currentProject.numberOfRooms
        })
      }
    });
  }

  openModal() {
    this.isModalOpened = true;
  }

  closeModal() {
    this.isModalOpened = false;
    this.postForm.reset();
    this.addApartmentService.setModalState({
      isOpened: false,
      project: null,
      appartType: '',
    });
  }

  onPhotoInput(fileInput: any) {
    this.photoToUpload = <Array<File>>fileInput.target.files;
  }

  createPost() {

    if (this.postForm.valid && this.currentUserId) {
      const newProject: RealEstateProject = {
        id: this.currentProject ? this.currentProject.id : 0,
        title: this.postForm.value.title ?? '',
        hashtags: [],
        description: this.postForm.value.description ?? '',
        photosUrls: [],
        comments: [],
        likes: [],
        userId: this.currentUserId,
        livingSpace: this.postForm.value.livingSpace ?? 0,
        realEstateStatus: RealEstateStatus.NewBuilding,
        price: this.postForm.value.price ?? 0,
        projectType: ProjectType.RealEstate,
        numberOfRooms: this.postForm.value.roomsNumber ?? 0,
        buildingType: BuildingType.Apartment,
        photos: this.photoToUpload,
        residentialComplexAppartmentType: this.currentAppartType,
      };

      this.addApartmentService.setModalState({
        isOpened: false,
        project: newProject,
        appartType: this.currentAppartType,
      });
    }

    this.closeModal();
  }
}
