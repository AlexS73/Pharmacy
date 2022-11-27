import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {ISale} from "../Models/sale.interface";
import {Observable} from "rxjs";
import {IEntrance} from "../Models/entrance.interface";

@Injectable()
export class CommerceService{
  constructor(private httpClient: HttpClient) {
  }

  public GetSales(): Observable<ISale[]>{
    return this.httpClient.get<ISale[]>('/api/commerce/sales');
  }

  public GetSale(id: number): Observable<ISale>{
    return this.httpClient.get<ISale>('/api/commerce/sale/' + id);
  }

  public GetEntrances(): Observable<IEntrance[]>{
    return this.httpClient.get<IEntrance[]>('/api/commerce/entrances');
  }

  public GetEntrance(id: number): Observable<IEntrance>{
    return this.httpClient.get<IEntrance>('/api/commerce/entrance/' + id);
  }

  public CreateSale(sale: ISale): Observable<ISale>{
    return this.httpClient.post<ISale>('/api/commerce/sale', sale);
  }

  public CreateEntrance(entrance: IEntrance): Observable<IEntrance>{
    return this.httpClient.post<IEntrance>('/api/commerce/entrance', entrance);
  }
}
