import { Project } from "src/app/models/project.model";

export interface ProjectInfo extends Project {
    isTop: boolean;
}