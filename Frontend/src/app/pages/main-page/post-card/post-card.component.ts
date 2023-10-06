import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from 'src/app/models/post.model';
import { UserType } from 'src/app/models/user.model';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-post-card',
  templateUrl: './post-card.component.html',
  styleUrls: ['./post-card.component.scss'],
})
export class PostCardComponent implements OnInit {
  @Input({ required: true }) post!: Post;
  @Output() onLiked = new EventEmitter();

  currentImgIndex: number = 0;
  isLiked: boolean = false;

  constructor(
    private readonly userService: UserService,
    private readonly router: Router
  ) {}

  ngOnInit(): void {
    this.userService.getCurrentUser().subscribe((user) => {
      let post = this.post.postLikes.find((x) => x.userId === user?.id);
      this.isLiked = post ? true : false;
    });
  }

  get userType(): string {
    if (this.post.user) {
      return UserType[this.post.user.userType!].toUpperCase();
    } else {
      return '';
    }
  }

  get userImg(): string {
    if (this.post.user) {
      return this.post.user.photo?.url
        ? this.post.user.photo?.url
        : `../../../../assets/img/account-icon.svg`;
    } else {
      return '';
    }
  }

  get imgPostUrl(): string {
    return `url('${this.post.photos[this.currentImgIndex].url}')`;
  }

  prevImg() {
    if (this.currentImgIndex - 1 >= 0) {
      this.currentImgIndex = this.currentImgIndex - 1;
    } else {
      this.currentImgIndex = this.post.photos.length - 1;
    }
  }

  nextImg() {
    if (this.currentImgIndex + 1 <= this.post.photos.length - 1) {
      this.currentImgIndex = this.currentImgIndex + 1;
    } else {
      this.currentImgIndex = 0;
    }
  }

  likeAction() {
    this.isLiked = !this.isLiked;
    this.onLiked.emit();
  }

  async openUserProfile() {
    await this.router.navigate([`./user-profile/${this.post.userId}`]);
  }
}
