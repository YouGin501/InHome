import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { RegistrationModalComponent } from '../registration-modal/registration-modal.component';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { AuthService } from 'src/app/services/auth.service';
import { AuthModalService } from '../../services/auth-modal.service';

@Component({
  selector: 'app-authorization-modal',
  templateUrl: './authorization-modal.component.html',
  styleUrls: ['./authorization-modal.component.scss'],
})
export class AuthorizationModalComponent implements OnInit{
  isOpenedAuthModal: boolean = false;
  @ViewChild('regModal') regModal: RegistrationModalComponent | undefined;

  loginText = 'LOGIN';
  loginBtn = 'LOGIN2';
  reg = 'REG_ACTION';
  password = 'PASSWORD';
  facebook = 'FACEBOOK';
  google = 'GOOGLE';
  forgotPass = 'FORGOT_PASSWORD';
  haveAcc = 'ALREADY_HAVE_ACC';
  passRequired = 'PASSWORD_REQUIRED';
  emailRequired = 'EMAIL_REQUIRED';

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });
  submitAttempt: boolean = false;

  constructor(
    private readonly authService: AuthService,
    private readonly userService: UserService,
    private readonly authModalService: AuthModalService
  ) {}

  ngOnInit(): void {
    this.authModalService.getCurrentModalState().subscribe(state => {
      if(state?.isOpened){
        this.show(state.modalType);
      } else {
        this.close();
      }
    });
  }

  show(authAction: string) {
    if (authAction === 'signin') {
      this.isOpenedAuthModal = true;
    } else {
      this.regModal?.show();
    }
  }

  close() {
    this.isOpenedAuthModal = false;
    this.regModal?.close();
  }

  goToRegistration() {
    this.isOpenedAuthModal = false;
    this.regModal?.show();
  }

  login() {
    this.submitAttempt = true;

    let emailValue = this.loginForm.controls['email'].value;
    let password = this.loginForm.controls['password'].value;

    if (this.loginForm.valid) {
      this.authService
        .login(emailValue ? emailValue : '', password ? password : '')
        .subscribe(
          (response: any) => {
            localStorage.setItem('email', response?.email);
            localStorage.setItem('roleId', response?.role);
            localStorage.setItem('userId', response?.id);
            this.userService.setCurrentUser(response);
            this.close();
          },
          (error) => {
            console.log(error);
            console.error(`Backend issue: ${error.error}`);
          }
        );
    }
  }
}
