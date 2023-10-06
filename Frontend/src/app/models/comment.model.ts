import { User } from "./user.model";

export interface Comment {
    id: number;
    text: string;
    author: User;
//    parrentComment: Comment;
//    replyComments: Comment[];
}