import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {ISale} from "../Models/sale.interface";
import {Observable} from "rxjs";
import {IProduct} from "../Models/product.interface";

@Injectable()
export class ProductService{
  constructor(private httpClient: HttpClient) {
  }

  public GetProducts(): Observable<IProduct[]>{
    return this.httpClient.get<IProduct[]>('/api/product')
  }

  public CreateProduct(product: IProduct): Observable<IProduct>{
    
    return this.httpClient.post<IProduct>('/api/product', product);
  }
}
