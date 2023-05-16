import { IDepartment } from "./department.interface";
import {IProduct} from "./product.interface";

export interface IWarehouse{
  Id: number;
  Name: string;
  Address: string;
  DepartmentId: number;
}
