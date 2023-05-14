import { IProduct } from "./product.interface";

export interface ISaleReport {
    generatedOn: Date;
    from: Date;
    to: Date;
    rows: ISaleReportRow[];
  }
  
  export interface ISaleReportRow {
    product: IProduct;
    quantity: number;
  }