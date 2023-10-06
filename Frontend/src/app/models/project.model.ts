import { ProjectType } from './project-type.model';
import { Location } from './location.model';
import { ImageUrl } from './image-url.model';
import { Like } from './like.model';
import { User } from './user.model';
import { Hashtag } from './hashtag.model';
import { RealEstateStatus } from './real-estate-status.model';
import { BuildingType } from './building-type.model';

export interface Project {
  id: number;
  title: string;
  description: string;
  advertisingLabel?: string;
  price: number;
  userId: number;
  user?: User;
  locationId?: number;
  location?: Location;
  photosUrls: ImageUrl[];
  photos?: File[],
  likes: Like[];
  hashtags?: Hashtag[];
  comments?: Comment[];
  projectType?: ProjectType;
  realEstateStatus?: RealEstateStatus;
  buildingType?: BuildingType;
}
