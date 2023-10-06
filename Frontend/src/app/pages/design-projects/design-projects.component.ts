import { Component } from '@angular/core';
import { TranslateService } from 'src/app/services/translate.service';
import { DropdownItemModel } from 'src/app/shared/components/dropdown/models/dropdown-item.model';
import { DesignService } from 'src/app/services/design.service';
import { Project } from 'src/app/models/project.model';

@Component({
  selector: 'app-design-projects',
  templateUrl: './design-projects.component.html',
  styleUrls: ['./design-projects.component.scss']
})
export class DesignProjectsComponent {
  servicesCatalog = "SERVICES_CATALOG";
  design = "DESIGN";
  orderDesign = "ORDER_DESIGN";

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
      private readonly designProjectsService: DesignService
    ) {}
    
    ngOnInit(): void{
      this.designProjectsService.getAll(undefined, undefined, 11, false)
        .subscribe(
          (data) =>{
            this.topBarProjects = data.slice(0,9);
            this.currentProjects = data.slice(9);
          }
        );
    }
}
