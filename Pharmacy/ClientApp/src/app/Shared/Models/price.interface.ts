import { IProduct } from "./product.interface";

export interface IPrice{
    Id: number;
    ProductId: number;
    Product: IProduct
    Price: number;
  }
  