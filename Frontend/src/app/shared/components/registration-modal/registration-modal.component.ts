import { Component, Input, ViewChild } from '@angular/core';
import { AuthorizationModalComponent } from '../authorization-modal/authorization-modal.component';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ProfileSelectModalComponent } from '../profile-select-modal/profile-select-modal.component';

@Component({
  selector: 'app-registration-modal',
  templateUrl: './registration-modal.component.html',
  styleUrls: ['./registration-modal.component.scss'],
})
export class RegistrationModalComponent {
  isOpenedModal: boolean = false;
  @ViewChild('profileModal') profileModal: ProfileSelectModalComponent | undefined;
  signup = 'SIGNUP';
  regAction = 'REG_ACTION';
  password = 'PASSWORD';
  name = 'NAME';
  surname = 'SURNAME';
  haveAcc = 'ALREADY_HAVE_ACC';

  @Input() authModal!: AuthorizationModalComponent;

  regForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
    name: new FormControl('', [Validators.required]),
    surname: new FormControl('', [Validators.required]),
  });
  submitAttempt: boolean = false;

  show() {
    this.isOpenedModal = true;
  }

  close() {
    this.isOpenedModal = false;
  }

  goToAuth() {
    this.close();
    this.authModal.show('signin');
  }

  goToProfile() {
    this.close();
    this.profileModal?.show();
  }

  registrate() {
    this.submitAttempt = true;

    if (this.regForm.valid) {
      this.goToProfile();
    }
  }
}
