import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IPrice } from "../Models/price.interface";

@Injectable()
export class PriceService{

    constructor(private httpClient: HttpClient) {       
    }

    public GetPrices(): Observable<IPrice[]>{
        return this.httpClient.get<IPrice[]>('/api/prices')
    }
}