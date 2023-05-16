import { IProduct } from "./product.interface";

export interface IEntranceReport {
    generatedOn: Date;
    from: Date;
    to: Date;
    rows: IEntranceReportRow[];
  }
  
  export interface IEntranceReportRow {
    product: IProduct;
    count: number;
  }