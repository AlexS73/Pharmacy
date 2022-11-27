import {IProduct} from "./product.interface";

interface ISaleProduct {
  Id: number;
  Product: IProduct;
  Count: number;
}

export interface ISale
{
  Id: number;
  CreatedOn: Date;
  CreatedBy: string;
  SaleProducts: ISaleProduct[]
}
