import { Component } from '@angular/core';
import { TranslateService } from 'src/app/services/translate.service';
import { DropdownItemModel } from 'src/app/shared/components/dropdown/models/dropdown-item.model';
import { RealEstateService } from 'src/app/services/real-estate.service';
import { Project } from 'src/app/models/project.model';

@Component({
  selector: 'app-new-building-projects',
  templateUrl: './new-building-projects.component.html',
  styleUrls: ['./new-building-projects.component.scss']
})
export class NewBuildingProjectsComponent {
  servicesCatalog = "Services Catalog";
  newBuilding = "New Building";

  topBarProjects: Project[] = [];
  currentProjects: Project[] = [];

  sortOptions: DropdownItemModel[] = [
    {
      value: "popularity",
      valueForTranslate: "POPULARITY_SORT"
    },
    {
      value: "asc_new",
      valueForTranslate: "ASC_NEW"
    },
    {
      value: "asc_expensive",
      valueForTranslate: "ASC_EXPENSIVE"
    },
    {
      value: "asc_cheap",
      valueForTranslate: "ASC_CHEAP"
    }
  ]

    constructor(
      private readonly translateService: TranslateService,
      private readonly newBuildingProjectsService: RealEstateService
    ) {}

    ngOnInit(): void{
      this.newBuildingProjectsService.getAll(undefined, undefined, undefined , true)
        .subscribe(
          (data) =>{
            this.topBarProjects = data.slice(0,9);
            this.currentProjects = data.slice(9);
          }
        );
    }
}
