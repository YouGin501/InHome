
import { RealEstateStatus } from "./real-estate-status.model";
import { Project } from "./project.model";

export interface RentProject extends Project {
    realEstateStatus: RealEstateStatus;
    livingSpace: number;
    minimalRentPeriod: number;
    numberOfRooms: number;
}