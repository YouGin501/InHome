import { SharedModule } from "src/app/shared/shared.module";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { NewBuildingProjectsComponent } from "./new-building-projects.component";


@NgModule({
  declarations: [
    NewBuildingProjectsComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    RouterModule
  ],
})
export class NewBuildingProjectsModule { }