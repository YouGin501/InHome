import { User } from './user.model';

export interface Feedback {
  id: number;
  text: string;
  writtenForUserId: number;
  writtenForUser?: User;
  authorId: number;
  author?: User;
}
