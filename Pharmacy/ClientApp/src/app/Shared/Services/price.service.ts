import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IProductPrice } from "../Models/price.interface";

@Injectable()
export class PriceService{

    constructor(private httpClient: HttpClient) {       
    }

    public Get(): Observable<IProductPrice[]>{
        return this.httpClient.get<IProductPrice[]>('/api/price')
    }

    public Save(price: IProductPrice): Observable<IProductPrice> {
        return this.httpClient.post<IProductPrice>('/api/price', price)
      }
}