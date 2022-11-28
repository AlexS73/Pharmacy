import {IProduct} from "./product.interface";

export interface IWarehouse{
  Id: number;
  Product: IProduct;
  Count: number;
}
