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
  EntranceProducts: IEntranceProduct[]
}
