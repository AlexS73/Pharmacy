import { IWarehouse } from "./warehouse.inteface";

export interface IDepartment{
  Id: number;
  Name: string;
  Address: string;
  Warehouse: IWarehouse
}
