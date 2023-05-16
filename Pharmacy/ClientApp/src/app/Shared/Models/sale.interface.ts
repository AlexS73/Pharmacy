import { IDepartment } from "./department.interface";
import {IProduct} from "./product.interface";

interface ISaleProduct {
  Id: number;
  Product: IProduct;
  Count: number;
  Price: number;
}

export interface ISale
{
  Id: number;
  CreatedOn: Date;
  CreatedBy: string;
  Customer: string;
  Sum: null;
  SaleProducts: ISaleProduct[];
  Department: IDepartment;
}
