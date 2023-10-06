import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { of, switchMap, take } from 'rxjs';
import { User } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';
import { FileService } from 'src/app/services/file.service';
import { UserService } from 'src/app/shared/services/user.service';
import { Document } from 'src/app/models/document.model';
import { MessageInfoService } from 'src/app/shared/services/message-info.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.scss'],
})
export class ProfilePageComponent implements OnInit {
  newBuildings = 'NEW_BUILDINGS';
  selling = 'SELLING';
  rent = 'RENT';
  design = 'DESIGN';
  aboutUs = 'ABOUT_US';
  weInSocialMedia = 'SOCIAL_MEDIA';
  registarte = 'REGISTRATE';
  canBeYourNews = 'CAN_BE_YOUR_NEWS';
  userInfo = 'USER_INFO';
  passwordText = 'PASSWORD_big';
  changePassword = 'CHANGE_PASSWORD';
  documentsText = 'DOCUMENTS';
  backText = 'BACK';
  allDocumentsText = 'ALL_DOCUMENTS';
  currentUser?: User;
  isRegisteredUser: boolean = false;

  name: string | undefined;
  isNameDisabled: boolean = true;
  information: string | undefined;
  isInfoDisabled: boolean = true;
  email: string | undefined;
  isEmailDisabled: boolean = true;

  deletedDocuments: Document[] = [];

  filesToUpload: Array<File> = [];
  photoToUpload: Array<File> = [];

  isOpenedModal: boolean = false;

  backUrl: string = '';

  constructor(
    private readonly userService: UserService,
    private readonly authService: AuthService,
    private readonly fileService: FileService,
    private readonly sanitizer: DomSanitizer,
    private readonly messageInfoService: MessageInfoService,
    private readonly route: ActivatedRoute,
    private readonly router: Router
  ) {}

  ngOnInit(): void {
    this.deletedDocuments = [];
    this.userService.getCurrentUser().subscribe((user) => {
      if (user != null) {
        this.loadUserInfo(user.id);
      }
      this.isRegisteredUser = user != null;
    });
    this.route.queryParams.subscribe((params) => {
      this.backUrl = params['backLink'] || '';
    });
  }

  enableName() {
    this.isNameDisabled = !this.isNameDisabled;
  }

  enableInfo() {
    this.isInfoDisabled = !this.isInfoDisabled;
  }

  enableEmail() {
    this.isEmailDisabled = !this.isEmailDisabled;
  }

  updateUserInfo() {}

  onFileInput(fileInput: any) {
    this.filesToUpload = <Array<File>>fileInput.target.files;
  }

  onPhotoInput(fileInput: any) {
    this.photoToUpload = <Array<File>>fileInput.target.files;
  }

  deleteDocument(document: Document) {
    this.deletedDocuments.push(document);
    if (this.currentUser?.documents) {
      this.currentUser!.documents = this.currentUser?.documents?.filter(
        (x) => x.id != document.id
      );
    }
  }

  get userLogo() {
    return this.currentUser?.photo?.url
      ? `url('${this.currentUser?.photo?.url}')`
      : '';
  }

  sendUpdate() {
    if (this.currentUser) {
      const filesData = new FormData();
      const photoData = new FormData();
      const files: Array<File> = this.filesToUpload;
      let photo: File | null = null;
      if (this.photoToUpload.length) {
        photo = this.photoToUpload[0];
        photoData.append('photo', photo, photo.name);
      }

      for (const file of files) {
        filesData.append('files', file, file.name);
      }

      const user: User = Object.assign({}, this.currentUser, {
        name: this.name,
        email: this.email,
        information: this.information,
        password: this.currentUser!.password,
      });

      this.fileService
        .uploadFiles(filesData, this.currentUser?.id)
        .pipe(
          switchMap(() =>
            this.deletedDocuments.length
              ? this.fileService.deleteFiles(
                  this.deletedDocuments,
                  this.currentUser!.id
                )
              : of(null)
          ),
          switchMap(() =>
            photo != null
              ? this.fileService.updateUserPhoto(photoData, user.id)
              : of(null)
          ),
          switchMap(() => this.authService.updateUser(user, user.id))
        )
        .subscribe(() => {
          this.messageInfoService.showSuccessMessage(
            'User was successfully updated!'
          );
          this.loadUserInfo(this.currentUser?.id as number);
        });
    }
  }

  loadUserInfo(userId: number) {
    this.authService
      .getUser(userId)
      .pipe(take(1))
      .subscribe((userInfo) => {
        this.currentUser = userInfo;
        this.name = this.currentUser.name;
        this.information = this.currentUser.information;
        this.email = this.currentUser.email;
        this.currentUser.documents?.map(
          (doc) =>
            (doc.url = this.sanitizer.bypassSecurityTrustResourceUrl(
              `https://documentsinhome.blob.core.windows.net/documents/${doc.fileName}#toolbar=0&navpanes=0&scrollbar=0`
            ))
        );
      });
    this.deletedDocuments = [];
    this.photoToUpload = [];
    this.filesToUpload = [];
  }

  closeModal() {
    this.isOpenedModal = false;
  }

  openModal() {
    this.isOpenedModal = true;
  }


  goBack(){
     this.backUrl != '' ? this.router.navigateByUrl(this.backUrl) : this.router.navigate(['/home']);
  }
}
