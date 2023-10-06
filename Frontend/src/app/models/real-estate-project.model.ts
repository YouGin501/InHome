import { Project } from "./project.model";
import { ResidentialComplexProject } from "./residential-complex-project.model";

export interface RealEstateProject extends Project {
  livingSpace: number;
  numberOfRooms: number;
  residentialComplexId?: number;
  residentialComplex?: ResidentialComplexProject;
  residentialComplexAppartmentType?: string;
}