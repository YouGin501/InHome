import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { TranslateService } from './services/translate.service';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MainPageModule } from './pages/main-page/main-page.module';
import { DesignProjectsComponent } from './pages/design-projects/design-projects.component';
import { ProfilePageModule } from './pages/profile-page/profile-page.module';
import { RentProjectModule } from './pages/rent-projects/rent-projects.module';
import { GuardsModule } from './guards/guard.module';
import { HttpErrorInterceptor } from './interceptors/http-error.interceptor';
import { UserProfileModule } from './pages/user-profile/user-profile.module';
import { SellingProjectModule } from './pages/selling-projects/selling-projects.module';
import { NewBuildingProjectsModule } from './pages/new-building-projects/new-building-projects.module';


export function setupTranslateServiceFactory(
  service: TranslateService): Function {
return () => service.use('en');
}

@NgModule({
  declarations: [AppComponent, DesignProjectsComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    HttpClientModule,
    MainPageModule,
    ProfilePageModule,
    RentProjectModule,
    SellingProjectModule,
    NewBuildingProjectsModule,
    GuardsModule,
    UserProfileModule,
  ],
  providers: [
    TranslateService,
    {
      provide: APP_INITIALIZER,
      useFactory: setupTranslateServiceFactory,
      deps: [TranslateService],
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
