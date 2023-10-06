import { SharedModule } from "src/app/shared/shared.module";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { RentProjectsComponent } from "./rent-projects.component";


@NgModule({
  declarations: [
    RentProjectsComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    RouterModule
  ],
})
export class RentProjectModule { }