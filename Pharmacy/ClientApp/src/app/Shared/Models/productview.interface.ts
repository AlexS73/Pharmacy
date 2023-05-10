import { IWarehouse } from "./warehouse.inteface";

export interface IProductView{
    Name: string;
    Article: string;
    Description: string;
    Category: string;
    Warehouse: IWarehouse;
    Price: number;
    Stock: number
}