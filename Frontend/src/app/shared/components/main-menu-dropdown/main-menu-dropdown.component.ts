import { Component, OnInit } from '@angular/core';
import { TranslateService } from 'src/app/services/translate.service';
import { UserService } from '../../services/user.service';
import { User } from 'src/app/models/user.model';
import { AuthModalService } from '../../services/auth-modal.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-menu-dropdown',
  templateUrl: './main-menu-dropdown.component.html',
  styleUrls: ['./main-menu-dropdown.component.scss'],
})
export class MainMenuDropdownComponent implements OnInit {
  newBuildings = 'NEW_BUILDINGS';
  selling = 'SELLING';
  rent = 'RENT';
  design = 'DESIGN';
  map = 'MAP_LOW_CASE';
  profile = 'PROFILE';
  logOutText = 'LOGOUT2';
  signUpText = 'SIGNUP2'
  signInText = 'SIGNIN2';
  chat = 'CHAT_LOW_CASE';
  aboutUs = 'ABOUT_US';
  socialMedia = 'SOCIAL_MEDIA';

  currentLanguage: string = 'en';
  menuOpened: boolean = false;
  currentUser: User | null = null;

  constructor(
    private readonly translateService: TranslateService,
    private readonly userService: UserService,
    private readonly authModalService: AuthModalService,
    private readonly router: Router
  ) {}
  ngOnInit(): void {
    this.translateService.getCurrentLanguage().subscribe((language) => {
      this.currentLanguage = language;
    });

    this.userService.getCurrentUser().subscribe(user => this.currentUser = user)
  }

  setLang(lang: string) {
    this.translateService.use(lang);
  }

  closeMenu() {
    this.menuOpened = false;
  }

  openMenu() {
    this.menuOpened = true;
  }

  async logOut() {
    this.userService.logOutUser();
    await this.router.navigate(['./home']);
  }

  signIn(){
    this.authModalService.setModalState({
      modalType: 'signin',
      isOpened: true
    })
  }

  signUp(){
    this.authModalService.setModalState({
      modalType: 'signup',
      isOpened: true
    })
  }
}
