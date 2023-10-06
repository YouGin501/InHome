import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { Like } from 'src/app/models/like.model';
import { Post } from 'src/app/models/post.model';
import { Project } from 'src/app/models/project.model';
import { User, UserRole, UserType } from 'src/app/models/user.model';
import { LikeService } from 'src/app/services/likes.service';
import { PostService } from 'src/app/services/post.service';
import { ProjectService } from 'src/app/services/project.service';
import { TranslateService } from 'src/app/services/translate.service';
import { DropdownValue } from 'src/app/shared/models/dropdown-value';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss'],
})
export class MainPageComponent implements OnInit {
  newBuildings = 'NEW_BUILDINGS';
  selling = 'SELLING';
  rent = 'RENT';
  design = 'DESIGN';
  aboutUs = 'ABOUT_US';
  weInSocialMedia = 'SOCIAL_MEDIA';
  howItWorks = 'HOW_IT_WORKS';
  letsRegistrate = 'LETS_REGISTRATE';
  chooseService = 'CHOOSE_SERVICE';
  orderDesign = 'ORDER_INTERIOR_DESIGN';
  letsReview = 'LETS_REVIEW';
  registarte = 'REGISTRATE';
  canBeYourNews = 'CAN_BE_YOUR_NEWS';
  filter = 'FILTER';
  isRegisteredUser: boolean = false;
  newsPosts: Post[] = [];
  newProjects: Project[] = [];
  allLikes: Like[] = [];
  availableLocations: DropdownValue[] = [];
  currentSelectionLocation: DropdownValue = {
    title: 'All',
    value: 'All',
  };
  postTypes: DropdownValue[] = [
    {
      value: 0,
      title: 'All',
    },
    {
      value: UserType.Developer,
      title: 'Developer',
    },
    {
      value: UserType.Agency,
      title: 'Agency',
    },
    {
      value: UserType.DesignStudio,
      title: 'DesignStudio',
    },
  ];
  postType: DropdownValue = {
    value: 0,
    title: 'All',
  };
  isOpenedModal: boolean = false;
  currentUser?: User;

  constructor(
    private readonly postService: PostService,
    private readonly userService: UserService,
    private readonly projectService: ProjectService,
    private readonly likeService: LikeService
  ) {}

  ngOnInit(): void {
    this.userService.getCurrentUser().subscribe((user) => {
      if (user != null) {
        this.currentUser = user;
        this.loadPosts(
          user.id,
          this.currentSelectionLocation.value.toString(),
          +this.postType.value
        );

        this.projectService
          .getAllProjectsFromSubscriptions(6, user.id)
          .subscribe((pr) => {
            this.newProjects = pr;
          });
      }
      this.isRegisteredUser = user != null;
    });
  }

  handleLocationChanged(value: DropdownValue) {
    this.currentSelectionLocation = value;
    if (this.currentUser) {
      this.loadPosts(
        this.currentUser?.id,
        this.currentSelectionLocation.value.toString(),
        +this.postType.value
      );
    }
  }

  handlePostTypeChanged(value: DropdownValue) {
    this.postType = value;
    if (this.currentUser) {
      this.loadPosts(
        this.currentUser?.id,
        this.currentSelectionLocation.value.toString(),
        +this.postType.value
      );
    }
  }

  private loadPosts(userId: number, country: string, userType: UserType) {
    this.postService
      .getPostsForUser(userId, country, userType)
      .pipe(take(1))
      .subscribe((p) => {
        this.newsPosts = p;
        this.availableLocations = p.map((post: Post) => ({
          value: post.location.country,
          title: post.location.country,
        }));
        this.availableLocations.push({ value: 'All', title: 'All' });
        this.availableLocations = [
          ...new Set(this.availableLocations.map((item) => item.title)),
        ].map((x) => ({
          value: x,
          title: x,
        }));
      });
  }

  likeUpdate() {}

  closeModal() {
    this.isOpenedModal = false;
  }

  openModal() {
    this.isOpenedModal = true;
  }
}
