import { IProduct } from "./product.interface";
import { IWarehouse } from "./warehouse.inteface";

export interface IStock{
    Id: number;
    ProductId: number;
    Product: IProduct;
    WarehouseId: number;
    Warehouse: IWarehouse;
    Count: number;
}