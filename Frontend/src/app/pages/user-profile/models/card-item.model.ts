import { ImageUrl } from "src/app/models/image-url.model";

export interface CardItem {
    title?: string;
    photos?: ImageUrl[],
    id: number
}