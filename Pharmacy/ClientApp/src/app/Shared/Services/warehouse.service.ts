import {Injectable} from "@angular/core";
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from "rxjs";
import {IWarehouse} from "../Models/warehouse.inteface";

@Injectable()
export class WarehouseService{
  constructor(private httpClient: HttpClient) {
  }

  public Get(): Observable<IWarehouse[]>{
    return this.httpClient.get<IWarehouse[]>('/api/warehouse');
  }

  public Save(warehouse: IWarehouse): Observable<IWarehouse>{
    return this.httpClient.post<IWarehouse>('/api/warehouse', warehouse);
  }

  public GetLeftovers(): Observable<IWarehouse[]>{
    return this.httpClient.get<IWarehouse[]>('/api/warehouse');
  }

  public GetLeftoversForDepartment(department: string): Observable<IWarehouse[]>{
    const params = new HttpParams()
      .set('department', department);

    return this.httpClient.get<IWarehouse[]>('/api/warehouse', {params});
  }
}
