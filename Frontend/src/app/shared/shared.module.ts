import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchInputComponent } from './components/search-input/search-input.component';
import { TranslatePipe } from './pipe/translate.pipe';
import { MainMenuDropdownComponent } from './components/main-menu-dropdown/main-menu-dropdown.component';
import { DropdownComponent } from './components/dropdown/dropdown.component';
import { ClickOutsideDirective } from './directives/click-outsied.directive';
import { AuthorizationModalComponent } from './components/authorization-modal/authorization-modal.component';
import { ModalWindowComponent } from './components/modal-window/modal-window.component';
import { DefaultInputComponent } from './components/default-input/default-input.component';
import { DefaultButtonComponent } from './components/default-button/default-button.component';
import { RegistrationModalComponent } from './components/registration-modal/registration-modal.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ProfileSelectModalComponent } from './components/profile-select-modal/profile-select-modal.component';
import { ProfileDropdownComponent } from './components/profile-select-modal/profile-dropdown/profile-dropdown.component';
import { LikeBtnComponent } from './components/like-btn/like-btn.component';
import { MessageInfoComponent } from './components/message-info/message-info.component';
import { LightDropdownComponent } from './components/light-dropdown/light-dropdown.component';

@NgModule({
  declarations: [
    SearchInputComponent,
    TranslatePipe,
    MainMenuDropdownComponent,
    DropdownComponent,
    ClickOutsideDirective,
    AuthorizationModalComponent,
    ModalWindowComponent,
    DefaultInputComponent,
    DefaultButtonComponent,
    RegistrationModalComponent,
    ProfileSelectModalComponent,
    ProfileDropdownComponent,
    LikeBtnComponent,
    MessageInfoComponent,
    LightDropdownComponent,
  ],
  imports: [CommonModule, ReactiveFormsModule, FormsModule, RouterModule],
  exports: [
    SearchInputComponent,
    TranslatePipe,
    MainMenuDropdownComponent,
    DropdownComponent,
    ClickOutsideDirective,
    AuthorizationModalComponent,
    ModalWindowComponent,
    DefaultInputComponent,
    RegistrationModalComponent,
    LikeBtnComponent,
    LightDropdownComponent
  ],
})
export class SharedModule {}
