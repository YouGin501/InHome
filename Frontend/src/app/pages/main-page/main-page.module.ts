import { MainPageComponent } from "./main-page.component";
import { SharedModule } from "src/app/shared/shared.module";
import { NgModule } from "@angular/core";
import { ProjectsCarouselComponent } from "./projects-carousel/projects-carousel.component";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { PostCardComponent } from './post-card/post-card.component';
import { DropdownFilterComponent } from './dropdown-filter/dropdown-filter.component';


@NgModule({
  declarations: [
    MainPageComponent,
    ProjectsCarouselComponent,
    PostCardComponent,
    DropdownFilterComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    RouterModule
  ],
})
export class MainPageModule { }