import { Component, OnInit } from '@angular/core';
import { DesignService } from 'src/app/services/design.service';
import { CarouselPageInfoModel } from './models/carousel-page-info.model';
import { take } from 'rxjs';
import { Project } from 'src/app/models/project.model';
import { RentService } from 'src/app/services/rent.service';
import { RealEstateService } from 'src/app/services/real-estate.service';

@Component({
  selector: 'app-projects-carousel',
  templateUrl: './projects-carousel.component.html',
  styleUrls: ['./projects-carousel.component.scss']
})
export class ProjectsCarouselComponent implements OnInit{
  currentPage = 1;
  newBuildingsOfMonth = "NEW_BUILDINGS_OF_MONTH";
  sellingOfMonth = "SELLINGS_OF_MONTH";
  rentOfMonth = "RENT_OF_MONTH";
  designOfMonth = "DESIGN_OF_MONTH";

  newBuildings = "NEW_BUILDINGS";
  selling = "SELLING";
  rent = "RENT";
  design = "DESIGN";
  top="TOP";
  from="FROM";

  currentPageInfo!: CarouselPageInfoModel;
  allPagesInfo: CarouselPageInfoModel[] = [];

  currentProjects: Project[] = [];
  topProjects: Project[] = [];
  notTopProjects: Project[] = [];
  
  constructor(
    private readonly designProjectsService: DesignService,
    private readonly rentProjectsService: RentService,
    //private readonly residentialComplexProjectsService: ResidentialComplexService,
    private readonly realEstateProjectsService: RealEstateService
  ){}
  
  ngOnInit(): void {
    this.createAllPagesInfo()
    this.switchPage(this.newBuildings);
    this.currentPageInfo = this.allPagesInfo[0];
  }

  get allSortedProjects() {
    return this.currentProjects.sort((a, b) => {
      return b.likes.length - a.likes.length;
    })
  }

  private createAllPagesInfo (): void {
    this.allPagesInfo = [
      {
        pageName: this.newBuildings,
        leftArrowLabel: this.design,
        rightArrowLabel: this.selling,
        monthFavorities: this.newBuildingsOfMonth
      },
      {
        pageName: this.selling,
        leftArrowLabel: this.newBuildings,
        rightArrowLabel: this.rent,
        monthFavorities: this.sellingOfMonth
      },
      {
        pageName: this.rent,
        leftArrowLabel: this.selling,
        rightArrowLabel: this.design,
        monthFavorities: this.rentOfMonth
      },
      {
        pageName: this.design,
        leftArrowLabel: this.rent,
        rightArrowLabel: this.newBuildings,
        monthFavorities: this.designOfMonth
      },
    ]
  }

  private prepareTopProjects(){
    let sortedProjects = this.allSortedProjects;
    console.log(sortedProjects, 'sorted')
    this.topProjects = sortedProjects.slice(0,3);
    this.notTopProjects = [...sortedProjects.slice(3, sortedProjects.length)]
  }

  switchPage(newPageLabel: string) {
    const newPageInfo = this.allPagesInfo.find(x => x.pageName === newPageLabel);
    if(newPageInfo){
      this.currentPageInfo = newPageInfo;
      this.getDataForPage(this.currentPageInfo.pageName);
    }
  }

  private getDataForPage(pageCategoryName: string){
    let startDate = new Date();
    startDate.setMonth(startDate.getMonth() - 1);
    let endDate = new Date();

    switch (pageCategoryName) {
      case this.design:
        this.designProjectsService.getAll(undefined, undefined, 8, false)
        .pipe(take(1))
        .subscribe(x => {
          this.currentProjects = [...x];
          this.prepareTopProjects();
        });
        break;
      case this.selling:
        this.realEstateProjectsService.getAll(undefined, undefined, 8, false, true )
          .pipe(take(1))
          .subscribe(x => {
            this.currentProjects = [...x];
            this.prepareTopProjects();
          });
          break;
      case this.rent:
        this.rentProjectsService.getAll(undefined, undefined, 8, false)
        .pipe(take(1))
        .subscribe(x => {
          this.currentProjects = [...x];
          this.prepareTopProjects();
        });
        break;
      default:
        this.realEstateProjectsService.getAll(undefined, undefined, 8, true)
          .pipe(take(1))
          .subscribe(x => {
            this.currentProjects = [...x];
            this.prepareTopProjects();
          });
          break;
    }

  }

}
