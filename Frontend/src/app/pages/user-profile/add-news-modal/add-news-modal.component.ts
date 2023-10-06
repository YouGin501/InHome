import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PostService } from 'src/app/services/post.service';
import { UserService } from 'src/app/shared/services/user.service';
import { Location } from '../../../models/location.model';
import { switchMap } from 'rxjs';
import { FileService } from 'src/app/services/file.service';
import { MessageInfoService } from 'src/app/shared/services/message-info.service';

@Component({
  selector: 'app-add-news-modal',
  templateUrl: './add-news-modal.component.html',
  styleUrls: ['./add-news-modal.component.scss'],
})
export class AddNewsModalComponent implements OnInit {
  postForm = new FormGroup({
    title: new FormControl('', Validators.required),
    description: new FormControl(''),
    hashtags: new FormControl(''),
    location: new FormGroup({
      country: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      address: new FormControl('', Validators.required),
    }),
  });

  createPostModal = false;
  photoToUpload: File[] = [];
  currentUserId?: number;
  closeText = 'CLOSE';
  publishText = 'PUBLISH';
  addNewsText = 'ADD_NEWS';

  @Output() OnPostAdded = new EventEmitter();

  constructor(
    private readonly route: ActivatedRoute,
    private readonly postService: PostService,
    private readonly fileService: FileService,
    private readonly messageInfoService: MessageInfoService
  ) {}

  ngOnInit(): void {
    this.currentUserId = Number(this.route.snapshot.paramMap.get('id'));
  }

  openPostModal() {
    this.createPostModal = true;
  }

  closePostModal() {
    this.createPostModal = false;
    this.postForm.reset();
  }

  onPhotoInput(fileInput: any) {
    this.photoToUpload = <Array<File>>fileInput.target.files;
  }

  createPost() {
    const formData = new FormData();
    for (const photo of this.photoToUpload) {
      formData.append('photos', photo, photo.name);
    }

    if (this.postForm.valid && this.currentUserId) {
      const location: Location = {
        id: 0,
        address: this.postForm.value.location?.address ?? '',
        city: this.postForm.value.location?.city ?? '',
        country: this.postForm.value.location?.country ?? ''
      }
      const newPost = {
        id: 0,
        title: this.postForm.value.title ?? '',
        location: location,
        hashtags: [],
        description: this.postForm.value.description ?? '',
        photos: [],
        comments: [],
        postLikes: [],
        userId: this.currentUserId,
      };
      this.postService
        .createPost(newPost)
        .pipe(
          switchMap((post) => this.fileService.addPostPhoto(formData, post.id))
        )
        .subscribe((x) => {
          this.messageInfoService.showSuccessMessage("Post successfully created!");
          this.closePostModal();
          this.OnPostAdded.emit();
        });
    }
  }
}
