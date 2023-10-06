import { NgModule } from "@angular/core";
import { AuthGuard } from "./auth.guard";
import { BrowserModule } from "@angular/platform-browser";
import { SharedModule } from "../shared/shared.module";
import { RouterModule } from "@angular/router";

@NgModule({
  imports: [BrowserModule, SharedModule, RouterModule],
  providers: [AuthGuard],
})
export class GuardsModule {}
