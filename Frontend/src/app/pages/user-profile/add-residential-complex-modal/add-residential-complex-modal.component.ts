import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import {
  Observable,
  forkJoin,
  switchMap,
} from 'rxjs';
import { FileService } from 'src/app/services/file.service';
import { DropdownValue } from 'src/app/shared/models/dropdown-value';
import { MessageInfoService } from 'src/app/shared/services/message-info.service';
import { AddApartmentService } from './services/add-apartment.service';
import { RealEstateProject } from 'src/app/models/real-estate-project.model';
import { Location } from 'src/app/models/location.model';
import { ResidentialComplexProject } from 'src/app/models/residential-complex-project.model';
import { RealEstateService } from 'src/app/services/real-estate.service';
import { ResidentialComplexService } from 'src/app/services/residential-complex.service';

@Component({
  selector: 'app-add-residential-complex-modal',
  templateUrl: './add-residential-complex-modal.component.html',
  styleUrls: ['./add-residential-complex-modal.component.scss'],
})
export class AddResidentialComplexModalComponent {
  postForm = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl(''),
    hashtags: new FormControl(''),
    location: new FormGroup({
      country: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      address: new FormControl('', Validators.required),
    }),
    advertisingLabel: new FormControl(''),
  });

  newAppartType: string = '';

  isModalOpened = false;
  isEditingMode = false;

  photoToUpload: File[] = [];
  currentUserId?: number;
  closeText = 'CLOSE';
  publishText = 'PUBLISH';
  modalType?: 'rent' | 'sell';
  addComplexText = 'ADD_RESIDENTIAL_COMPLEX';
  websiteText = 'OFF_WEBSITE';
  chatText = 'CHAT_LOW_CASE';
  charactericsText = 'CHARACTERISTICS';
  locationText = 'LOCATION';
  developerPageText = 'DEVELOPER_PAGE';
  developerNameText = 'DEVELOPER_NAME';
  attendanceText = 'ATTENDANCE_CALENDAR';
  saleDepText = 'SALES_DEPARTMENT';
  cityText = 'CITY';
  countryText = 'COUNTRY';
  appartmentTypeText = 'ADD_APPARTMENT_TYPE';

  appartmentTypes: string[] = [];
  appartments: any[] = [];

  @Output() OnComplexAdded = new EventEmitter();

  constructor(
    private readonly route: ActivatedRoute,
    private readonly fileService: FileService,
    private readonly messageInfoService: MessageInfoService,
    private readonly addApartmentService: AddApartmentService,
    private readonly realEstateService: RealEstateService,
    private readonly residentialComplexService: ResidentialComplexService
  ) {}

  ngOnInit(): void {
    this.currentUserId = Number(this.route.snapshot.paramMap.get('id'));
    this.addApartmentService.getCurrentModalState().subscribe((x) => {
      console.log(x);
      if (this.isEditingMode) {
        this.isModalOpened = !x.isOpened;

        if (x.project && x.project.photos) {
          let project = this.appartments.find((p) => p.id == x.project?.id);
          console.log(project, 'proj');
          if (!project) {
            this.appartments.push({
              ...x.project,
              id: this.appartments.length
                ? this.appartments[this.appartments.length - 1].id + 1
                : 1,
              mainPhoto: URL.createObjectURL(x.project.photos[0]),
            });
          } else {
            this.appartments = this.appartments.map((i) => {
              return i.id === x?.project?.id
                ? {
                    ...x.project,
                    mainPhoto: URL.createObjectURL(
                      (x as any).project.photos[0]
                    ),
                  }
                : i;
            });
          }
        }
      }
    });
  }

  openModal() {
    this.isModalOpened = true;
    this.isEditingMode = true;
  }

  addAppartType() {
    if (this.newAppartType.length) {
      this.appartmentTypes.push(this.newAppartType);
      this.newAppartType = '';
    }

    console.log(this.appartmentTypes);
  }

  closeModal() {
    this.isModalOpened = false;
    this.postForm.reset();
    this.isEditingMode = false;
    this.appartmentTypes = [];
    this.photoToUpload = [];
    this.appartments = [];
  }

  onPhotoInput(fileInput: any) {
    this.photoToUpload = <Array<File>>fileInput.target.files;
  }

  createPost() {
    const formData = new FormData();
    for (const photo of this.photoToUpload) {
      formData.append('photos', photo, photo.name);
    }

    if (!this.photoToUpload.length) {
      this.messageInfoService.showErrorMessage(
        'You can not save offer without any photo!'
      );
    }

    if (
      this.postForm.valid &&
      this.currentUserId &&
      this.photoToUpload.length
    ) {
      const location: Location = {
        id: 0,
        address: this.postForm.value.location?.address ?? '',
        city: this.postForm.value.location?.city ?? '',
        country: this.postForm.value.location?.country ?? '',
      };

      let requests: Observable<any>[] = [];
      let resultAppartments: RealEstateProject[] = [];

      this.appartments.forEach((app) => {
        const req = this.realEstateService
          .add({
            ...app,
            id: 0,
            location: location,
            advertisingLabel: this.postForm.value.advertisingLabel,
            hashtags: this.postForm.value.hashtags,
          })
          .pipe(
            switchMap((pr) => {
              resultAppartments.push(pr);
              const prData = new FormData();
              for (const photo of this.photoToUpload) {
                prData.append('photos', photo, photo.name);
              }
              return this.fileService.addRealEstatePhoto(prData, pr.id);
            })
          );
        requests.push(req);
      });

      const residentialComplex: ResidentialComplexProject = {
        id: 0,
        location: location,
        name: this.postForm.value.name ?? '',
        photoUrls: [],
        apartments: resultAppartments,
        description: this.postForm.value.description ?? '',
        userId: this.currentUserId,
      };

      if (requests.length) {
        forkJoin(requests)
          .pipe(
            switchMap(() => {
              return this.residentialComplexService.add(residentialComplex);
            }),
            switchMap((rc) => {
              return this.fileService.addResedentialComplexPhoto(
                formData,
                rc.id
              );
            })
          )
          .subscribe(() => {
            this.OnComplexAdded.emit();
            this.messageInfoService.showSuccessMessage(
              'Residential complex offer successfully created!'
            );
            this.closeModal();
          });
      } else {
        this.residentialComplexService
          .add(residentialComplex)
          .pipe(
            switchMap((rc) => {
              return this.fileService.addResedentialComplexPhoto(
                formData,
                rc.id
              );
            })
          )
          .subscribe(() => {
            this.OnComplexAdded.emit();
            this.messageInfoService.showSuccessMessage(
              'Residential complex offer successfully created!'
            );
            this.closeModal();
          });
      }
    }
  }
}
