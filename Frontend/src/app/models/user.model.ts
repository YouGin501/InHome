import { Subscription } from "rxjs";
import { Document } from "./document.model";
import { ImageUrl } from "./image-url.model";

export class User {
  id: number;
  name?: string;
  email?: string;
  role: number;
  roleName?: string;
  userType?: UserType;
  photo?: ImageUrl;
  information?: string;
  documents?: Document[];
  password?: string;
  surname?: string;
  subscriberSubscriptions?: Subscription[];
  receiverSubscriptions?: Subscription[];

  constructor(obj: IUserDto) {
    this.id = obj.id;
    this.name = obj.name;
    this.email = obj.email;
    this.role = obj.role;
    const roleKey: string = Object.keys(UserRole)[obj.role];
    this.roleName = roleKey;
  }
}

export enum UserRole {
  'Admin',
  'Customer',
  'Entrepreneur',
}

export interface IUserDto {
  id: number;
  name: string;
  email: string;
  role: number;
}

export enum UserType {
  'Individual' = 0,
  'Developer' = 1,
  'Agency' = 2,
  'DesignStudio' = 3,
  'Freelancer' = 4,
}