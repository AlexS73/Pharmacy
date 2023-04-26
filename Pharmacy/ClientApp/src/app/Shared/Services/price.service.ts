import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IPrice } from "../Models/price.interface";

@Injectable()
export class PriceService{

    constructor(private httpClient: HttpClient) {       
    }

    public Get(): Observable<IPrice[]>{
        return this.httpClient.get<IPrice[]>('/api/price')
    }

    public Save(price: IPrice): Observable<IPrice> {
        return this.httpClient.post<IPrice>('/api/price', price)
      }
}