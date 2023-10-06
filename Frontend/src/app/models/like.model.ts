import { User } from "./user.model";

export interface Like {
    id?: number;
    user?: User;
    userId: number;
    postId?: number;
    projectId?: number;
}