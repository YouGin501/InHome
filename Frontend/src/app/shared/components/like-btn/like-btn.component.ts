import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LikeService } from 'src/app/services/likes.service';
import { UserService } from '../../services/user.service';
import { User } from 'src/app/models/user.model';
import { Like } from 'src/app/models/like.model';

@Component({
  selector: 'app-like-btn',
  templateUrl: './like-btn.component.html',
  styleUrls: ['./like-btn.component.scss'],
})
export class LikeBtnComponent implements OnInit {
  @Input({ required: true }) postType: string = '';
  @Input({ required: true }) postId?: number;
  @Input() alreadyLiked: boolean = false;
  currentUser: User | null = null;
  @Output() likeAction = new EventEmitter();

  constructor(
    private readonly likeService: LikeService,
    private readonly userService: UserService
  ) {}

  ngOnInit(): void {
    this.userService.getCurrentUser().subscribe((user) => {
      this.currentUser = user;
    });
  }

  like() {
    console.log('li')
    if (this.currentUser) {
      let like: Like;
      this.alreadyLiked = !this.alreadyLiked;

      if (this.postType === 'post') {
        like = {
          id: 0,
          postId: this.postId,
          userId: this.currentUser.id,
        };
        this.likeService.addLike(like).subscribe();
      } else if (this.postType === 'project') {
        like = {
          id: 0,
          projectId: this.postId,
          userId: this.currentUser.id,
        };
        this.likeService.addLike(like).subscribe();
      }
      this.likeAction.emit();
    }
  }

  disLike() {
    this.alreadyLiked = false;
  }
}
