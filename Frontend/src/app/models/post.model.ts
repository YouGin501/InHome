import { Location } from "../models/location.model";
import { Comment } from "../models/comment.model";
import { Like } from "./like.model";
import { User } from "./user.model";
import { ImageUrl } from "./image-url.model";

export interface Post {
  id: number;
  title: string;
  hashtags: string[];
  description: string;
  photos: ImageUrl[];
  comments: Comment[];
  location: Location;
  postLikes: Like[];
  user?: User;
  userId: number;
}