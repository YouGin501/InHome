import { SharedModule } from "src/app/shared/shared.module";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { SellingProjectsComponent } from "./selling-projects.component";


@NgModule({
  declarations: [
    SellingProjectsComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    RouterModule
  ],
})
export class SellingProjectModule { }