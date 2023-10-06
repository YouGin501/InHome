import { NgModule } from '@angular/core';
import { UserProfileComponent } from './user-profile.component';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule } from 'src/app/shared/shared.module';
import { RouterModule } from '@angular/router';
import { TabHolderComponent } from './tab-holder/tab-holder.component';
import { TabComponent } from './tab-holder/tab/tab.component';
import { PostCardComponent } from './post-card/post-card.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DocumentsModalComponent } from './documents-modal/documents-modal.component';
import { AddFeedbackComponent } from './add-feedback/add-feedback.component';
import { FeedbackListComponent } from './feedback-list/feedback-list.component';
import { AddNewsModalComponent } from './add-news-modal/add-news-modal.component';
import { AddSellRentModalComponent } from './add-sell-rent-modal/add-sell-rent-modal.component';
import { TileComponent } from './tile/tile.component';
import { AddResidentialComplexModalComponent } from './add-residential-complex-modal/add-residential-complex-modal.component';
import { ExpandComponentComponent } from './add-residential-complex-modal/expand-component/expand-component.component';
import { AddApartmentComponent } from './add-residential-complex-modal/add-apartment/add-apartment.component';
import { ViewSellRentModalComponent } from './view-sell-rent-modal/view-sell-rent-modal.component';

@NgModule({
  declarations: [
    UserProfileComponent,
    TabComponent,
    TabHolderComponent,
    PostCardComponent,
    DocumentsModalComponent,
    AddFeedbackComponent,
    FeedbackListComponent,
    AddNewsModalComponent,
    AddSellRentModalComponent,
    TileComponent,
    AddResidentialComplexModalComponent,
    ExpandComponentComponent,
    AddApartmentComponent,
    ViewSellRentModalComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
  ],
})
export class UserProfileModule {}
