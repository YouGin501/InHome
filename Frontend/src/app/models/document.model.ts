import { SafeResourceUrl } from "@angular/platform-browser";

export interface Document {
  id: number;
  fileName: string;
  url?: SafeResourceUrl;
}