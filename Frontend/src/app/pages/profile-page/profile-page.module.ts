import { NgModule } from '@angular/core';
import { ProfilePageComponent } from './profile-page.component';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule } from 'src/app/shared/shared.module';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [ProfilePageComponent],
  imports: [BrowserModule, SharedModule, RouterModule, FormsModule],
})
export class ProfilePageModule {}
