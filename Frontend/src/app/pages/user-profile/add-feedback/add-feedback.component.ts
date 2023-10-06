import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Feedback } from 'src/app/models/feedback.model';
import { User } from 'src/app/models/user.model';
import { FeedbackService } from 'src/app/services/feedback.service';
import { MessageInfoService } from 'src/app/shared/services/message-info.service';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-add-feedback',
  templateUrl: './add-feedback.component.html',
  styleUrls: ['./add-feedback.component.scss'],
})
export class AddFeedbackComponent implements OnInit {
  writeFeedbackText = 'WRITE_FEEDBACK';
  sendText = 'SEND';
  closeText = 'CLOSE';

  isOpenedModal: boolean = false;
  appUser: User | null = null;
  currentUserId?: number;

  feedbackForm = new FormGroup({
    feedbackText: new FormControl('', Validators.required),
  });

  constructor(
    private readonly feedbackService: FeedbackService,
    private readonly userService: UserService,
    private readonly route: ActivatedRoute,
    private readonly messageInfoService: MessageInfoService
  ) {}
  ngOnInit(): void {
    this.currentUserId = Number(this.route.snapshot.paramMap.get('id'));
    this.userService
      .getCurrentUser()
      .subscribe((appUser) => (this.appUser = appUser));
  }

  closeModal() {
    this.isOpenedModal = false;
  }

  openModal() {
    this.isOpenedModal = true;
  }

  createFeedback() {
    if (
      this.appUser?.id &&
      this.currentUserId &&
      this.feedbackForm.value.feedbackText
    ) {
      const newFeedback: Feedback = {
        id: 0,
        writtenForUserId: this.currentUserId,
        authorId: this.appUser.id,
        text: this.feedbackForm.value.feedbackText,
      };
      this.feedbackService.add(newFeedback).subscribe(() => {
        this.feedbackForm.reset();
        this.closeModal();
        this.messageInfoService.showSuccessMessage('Your feedback added!');
      });
    }
  }
}
