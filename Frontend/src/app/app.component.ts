import { AfterViewInit, Component, ElementRef, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { UserService } from './shared/services/user.service';
import { User } from './models/user.model';
import { TranslateService } from './services/translate.service';
import { Router } from '@angular/router';
import { MessageInfoService } from './shared/services/message-info.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit, AfterViewInit {
  title = 'In Home';
  chat = 'CHAT';
  map = 'MAP';
  signup = 'SIGNUP';
  signin = 'SIGNIN';
  logoutText = 'LOGOUT';
  socialMedia = 'SOCIAL_MEDIA';
  cfs = 'CFS';
  rightsReserved = 'RIGHTS_RESERVED';

  services = 'SERVICES';
  newBuildings = 'NEW_BUILDINGS';
  selling = 'SELLING';
  rent = 'RENT';
  design = 'DESIGN';
  aboutUs = 'ABOUT_US';

  currentUser: User | null = null;
  currentLanguage: string = 'en';

  profileOptionsOpened: boolean = false;

  @ViewChild('infoNotifications', {
    read: ViewContainerRef,
  })
  viewContainerRef!: ViewContainerRef;

  constructor(
    private readonly userService: UserService,
    private readonly translateService: TranslateService,
    private readonly router: Router,
    private readonly messageInfoService: MessageInfoService
  ) {}
  ngAfterViewInit(): void {
    this.messageInfoService.setRootViewContainerRef(this.viewContainerRef);
  }

  ngOnInit(): void {

    this.userService.loginFromLocalStorage();
    this.userService.getCurrentUser().subscribe((user) => {
      this.currentUser = user;
    });
    this.translateService.getCurrentLanguage().subscribe((language) => {
      this.currentLanguage = language;
    });
  }

  setLang(lang: string) {
    this.translateService.use(lang);
  }

  async logout() {
    this.userService.logOutUser();
    this.closeProfileOptions();
    await this.router.navigate(['./home']);
  }

  closeProfileOptions() {
    this.profileOptionsOpened = false;
  }

  openProfileOptions() {
    this.profileOptionsOpened = true;
  }
}
