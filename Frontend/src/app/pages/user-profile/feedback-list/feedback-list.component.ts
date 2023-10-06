import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { Feedback } from 'src/app/models/feedback.model';
import { FeedbackService } from 'src/app/services/feedback.service';

@Component({
  selector: 'app-feedback-list',
  templateUrl: './feedback-list.component.html',
  styleUrls: ['./feedback-list.component.scss'],
})
export class FeedbackListComponent implements OnInit {
  feedbacksText = 'FEEDBACKS_upper';
  feedbacks: Feedback[] = [];
  currentUserId?: number;

  constructor(
    private readonly feedbackService: FeedbackService,
    private readonly route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.currentUserId = Number(this.route.snapshot.paramMap.get('id'));
  }

  isOpenedModal: boolean = false;

  closeModal() {
    this.isOpenedModal = false;
  }

  openModal() {
    this.isOpenedModal = true;
    if (this.currentUserId) {
      this.feedbackService
        .getAll(this.currentUserId)
        .pipe(take(1))
        .subscribe((feedbacks) => {
          console.log(feedbacks);
          this.feedbacks = feedbacks;
        });
    }
  }
}
