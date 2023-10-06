import { Component, Input, OnInit } from '@angular/core';
import { RegistrationModalComponent } from '../registration-modal/registration-modal.component';
import { UserType } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from '../../services/user.service';
import { DropdownValue } from '../../models/dropdown-value';

@Component({
  selector: 'app-profile-select-modal',
  templateUrl: './profile-select-modal.component.html',
  styleUrls: ['./profile-select-modal.component.scss'],
})
export class ProfileSelectModalComponent implements OnInit {
  isOpenedModal: boolean = false;
  @Input() regModal!: RegistrationModalComponent;
  @Input() login!: string | null;
  @Input() name!: string | null;
  @Input() password!: string | null;
  @Input() surname!: string | null;

  profile = 'PROFILE';
  user = 'USER';
  next = 'NEXT';
  back = 'BACK';
  userTypeOptions: DropdownValue[] = [
    {
      title: 'INDIVIDUAL_small',
      value: UserType.Individual,
    },
    {
      title: 'DEVELOPER_small',
      value: UserType.Developer,
    },
    {
      title: 'AGENCY_small',
      value: UserType.Agency,
    },
    {
      title: 'DESIGN_STUDIO_small',
      value: UserType.DesignStudio,
    },
    {
      title: 'FREELANCER_small',
      value: UserType.Freelancer,
    },
  ];
  currentSelection!: DropdownValue;

  constructor(
    private readonly authService: AuthService,
    private readonly userService: UserService
  ) {}

  ngOnInit(): void {
    this.currentSelection = this.userTypeOptions[0];
  }

  selectType($event: DropdownValue) {
    console.log($event, 'event');
    this.currentSelection = $event;
  }

  show() {
    this.isOpenedModal = true;
  }

  close() {
    this.isOpenedModal = false;
  }

  goToAuth() {
    this.close();
    this.regModal.show();
  }

  registrate() {
    if (this.login && this.password && this.name && this.surname) {
      this.authService
        .registrate(
          this.login,
          this.password,
          this.name,
          this.surname,
          +this.currentSelection.value
        )
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
            console.error(`Backend issue: ${error.message}`);
          }
        );
    }
  }
}
