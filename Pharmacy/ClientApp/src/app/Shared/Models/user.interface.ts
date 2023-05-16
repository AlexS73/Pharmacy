import { IDepartment } from "./department.interface";

export interface IUser{
    Id: number;
    Name: string;
    Email: string
    Department: IDepartment;
    UserName: string;
    Roles: string[];
  }
  