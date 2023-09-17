import { AuthModel } from "./auth.model";

export interface User extends AuthModel {
  UserEmail: string;
  UserPassword: string;
  UserFirstName: string;
  UserLastName: string;
}
