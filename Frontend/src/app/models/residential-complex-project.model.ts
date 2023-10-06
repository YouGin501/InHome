import { RealEstateProject } from "./real-estate-project.model";
import { Location } from "./location.model";
import { ImageUrl } from "./image-url.model";
import { User } from "./user.model";

export interface ResidentialComplexProject {
    id: number;
    name: string;
    description?: string;
    photoUrls: ImageUrl[];
    locationId?: number;
    location: Location;
    apartments: RealEstateProject[];
    userId: number;
    user?: User;
}