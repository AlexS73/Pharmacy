import { Injectable } from "@angular/core";
import {HttpClient, HttpResponse } from '@angular/common/http';
import {Observable} from 'rxjs';
import { IStock } from "../Models/stock.interface";

@Injectable()
export class StockService{
    constructor(private httpClient: HttpClient) {
    }
  
    Get(): Observable<IStock[]>{
      return this.httpClient.get<IStock[]>('/api/stock');
    }
}