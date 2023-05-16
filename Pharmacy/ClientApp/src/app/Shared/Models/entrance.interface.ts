import { IDepartment } from "./department.interface";
import {IProduct} from "./product.interface";

interface IEntranceProduct {
  Id: number;
  Product: IProduct;
  Count: number;
}

export interface IEntrance
{
  Id: number;
  CreatedOn: Date;
  CreatedBy: string;
  Supplier: string;
  EntranceProducts: IEntranceProduct[];
  Department: IDepartment;
}
