import { IProduct } from "./product.interface";
import { IWarehouse } from "./warehouse.inteface";

export interface IProductPrice{
    Id: number;
    ProductId: number;
    Product: IProduct
    WarehouseId: number;
    Warehouse: IWarehouse;
    Price: number;
  }
  