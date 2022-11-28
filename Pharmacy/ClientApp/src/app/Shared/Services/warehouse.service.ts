import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {IWarehouse} from "../Models/warehouse.inteface";

@Injectable()
export class WarehouseService{
  constructor(private httpClient: HttpClient) {
  }

  public GetLeftovers(): Observable<IWarehouse[]>{
    return this.httpClient.get<IWarehouse[]>('/api/warehouse')
  }
}
