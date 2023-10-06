import { Project } from "./project.model";
import { ResidentialComplexProject } from "./residential-complex-project.model";
import { User } from "./user.model";

export interface ImageUrl {
    id: number;
    url: string;
    fileName?: string;
    postId?: number;
    projectId?: number;
    project?: Project;
    userId?: number;
    user?: User;
    residentialComplexId?: number;
    residentialComplex?: ResidentialComplexProject;
}