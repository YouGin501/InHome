import { SharedModule } from "src/app/shared/shared.module";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { DesignProjectsComponent } from "./design-projects.component";


@NgModule({
  declarations: [
    DesignProjectsComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    RouterModule
  ],
})
export class DesignProjectModule { }