import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { DesignProjectsComponent } from './pages/design-projects/design-projects.component';
import { ProfilePageComponent } from './pages/profile-page/profile-page.component';
import { RentProjectsComponent } from './pages/rent-projects/rent-projects.component';
import { SellingProjectsComponent } from './pages/selling-projects/selling-projects.component';
import { AuthGuard } from './guards/auth.guard';
import { UserProfileComponent } from './pages/user-profile/user-profile.component';
import { NewBuildingProjectsComponent } from './pages/new-building-projects/new-building-projects.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: MainPageComponent },
  { path: 'designs', component: DesignProjectsComponent },
  {
    path: 'profile-settings',
    component: ProfilePageComponent,
    canActivate: [AuthGuard],
  },
  { path: 'user-profile/:id', component: UserProfileComponent },
  { path: 'rents', component: RentProjectsComponent },
  { path: 'sellings', component: SellingProjectsComponent },
  { path: 'new-buildings', component: NewBuildingProjectsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

}
