import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { take } from 'rxjs';
import { User } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';
import { TabInput } from 'src/app/pages/user-profile/tab-holder/tab-holder.component';
import { UserService } from 'src/app/shared/services/user.service';
import { PostService } from 'src/app/services/post.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from 'src/app/models/post.model';
import { RentService } from 'src/app/services/rent.service';
import { CardItem } from './models/card-item.model';
import { RealEstateService } from 'src/app/services/real-estate.service';
import { ResidentialComplexService } from 'src/app/services/residential-complex.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss'],
})
export class UserProfileComponent implements OnInit {
  feedbacksText = 'FEEDBACKS';
  addFeedbackText = 'ADD_FEEDBACK';
  readersText = 'READERS';
  followText = 'FOLLOW';
  companyInfoText = 'COMPANY_INFO';
  documents = 'DOCUMENTS';
  projectsOnMapText = 'PROJECTS_MAP';

  currentUser: User | null = null;
  appUser: User | null = null;
  cardItems: CardItem[] = [];

  tabsInfo: TabInput[] = [];

  pageRef: string = '';
  isCompanyInfoShown: boolean = false;

  constructor(
    private readonly authService: AuthService,
    private readonly sanitizer: DomSanitizer,
    private readonly postService: PostService,
    private readonly rentService: RentService,
    private readonly realEstateService: RealEstateService,
    private readonly residentialComplexService: ResidentialComplexService,
    private readonly userService: UserService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.pageRef = this.router.url;
    this.userService
      .getCurrentUser()
      .subscribe((appUser) => (this.appUser = appUser));
    this.authService
      .getUser(id)
      .pipe(take(1))
      .subscribe((userInfo) => {
        this.currentUser = userInfo;
        console.log(this.currentUser, 'user');
        this.currentUser.documents?.map(
          (doc) =>
            (doc.url = this.sanitizer.bypassSecurityTrustResourceUrl(
              `https://documentsinhome.blob.core.windows.net/documents/${doc.fileName}#toolbar=0&navpanes=0&scrollbar=0`
            ))
        );
        this.createTabs();
        if (this.tabsInfo.length) {
          this.loadDataForTab(this.tabsInfo[0].title);
        }
      });
  }

  showCompanyInfo() {
    this.isCompanyInfoShown = !this.isCompanyInfoShown;
  }

  createTabs() {
    this.tabsInfo = [
      {
        title: 'NEWS',
        active: false,
        items: [],
        isShown: this.currentUser?.userType !== 0,
      },
      {
        title: 'PROJECTS',
        active: false,
        items: [],
        isShown: this.currentUser?.userType === 1,
      },
      {
        title: 'SELLING',
        active: false,
        items: [],
        isShown:
          this.currentUser?.userType === 2 || this.currentUser?.userType === 0,
      },
      {
        title: 'RENT',
        active: false,
        items: [],
        isShown:
          this.currentUser?.userType === 2 || this.currentUser?.userType === 0,
      },
    ];

    this.tabsInfo = this.tabsInfo.filter((x) => x.isShown);
    if (this.tabsInfo.length) {
      this.tabsInfo[0].active = true;
    }
  }

  get userLogo() {
    return this.currentUser?.photo?.url
      ? `url('${this.currentUser?.photo?.url}')`
      : '';
  }

  tabSelectionChanged(e: any) {
    this.tabsInfo.forEach((x) => {
      x.active = false;
      if (x.title === e) {
        x.active = true;
      }
    });

    this.loadDataForTab(e);
  }

  loadDataForTab(tabTitle: string) {
    if (this.currentUser) {
      if (tabTitle === 'NEWS') {
        this.postService
          .getAllPosts(this.currentUser?.id)
          .pipe(take(1))
          .subscribe((x) => {
            this.cardItems = x.map((post) => {
              return {
                title: post.title,
                photos: post.photos,
                id: post.id,
              };
            });
          });
      } else if (tabTitle === 'SELLING') {
        this.reloadRealEstates();
      } else if (tabTitle === 'RENT') {
        this.reloadRents();
      } else if (tabTitle === 'PROJECTS') {
        this.reloadResedentialComplexes();
      }
    }
  }

  reloadRents() {
    this.rentService
      .getAll(undefined, undefined, undefined, undefined, this.currentUser?.id)
      .pipe(take(1))
      .subscribe((x) => {
        this.cardItems = x
          .map((rent) => {
            return {
              title: rent.title,
              photos: rent.photosUrls,
              id: rent.id,
            };
          })
          .reverse();
      });
  }

  reloadRealEstates() {
    this.realEstateService
      .getAll(
        undefined,
        undefined,
        undefined,
        undefined,
        undefined,
        this.currentUser?.id
      )
      .pipe(take(1))
      .subscribe((x) => {
        this.cardItems = x
          .map((realEstate) => {
            return {
              title: realEstate.title,
              photos: realEstate.photosUrls,
              id: realEstate.id,
            };
          })
          .reverse();
      });
  }

  reloadResedentialComplexes() {
    console.log('reload');
    this.residentialComplexService
      .getAll(this.currentUser?.id)
      .pipe(take(1))
      .subscribe((x) => {
        console.log(x, 'items');
        this.cardItems = x
          .map((complex) => {
            return {
              title: complex.name,
              photos: complex.photoUrls,
              id: complex.id,
            };
          })
          .reverse();
      });
  }
}
