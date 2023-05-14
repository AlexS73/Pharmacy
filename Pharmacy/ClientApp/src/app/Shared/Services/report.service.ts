import { HttpClient, HttpParams } from "@angular/common/http";
import { IEntranceReport } from "../Models/entranceReport.interface";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import { ISaleReport } from "../Models/saleReport.interface";

@Injectable()
export class ReportService{
  constructor(private httpClient: HttpClient) {
  }

  public GetEntranceReport(from: Date | null, to: Date | null, departmentId: number | null): Observable<IEntranceReport> {
    console.log('GetEntranceReport',from,to);
    let params = new HttpParams();
    if (from) {
      params = params.append('from', from.toISOString());
    }
    if (to) {
      params = params.append('to', to.toISOString());
    }
    if (departmentId) {
      params = params.append('departmentId', departmentId.toString());
    }
    return this.httpClient.get<IEntranceReport>('/api/report/entrance', { params });
  }

  public GetSaleReport(from: Date | null, to: Date | null,  departmentId: number | null): Observable<ISaleReport> {
    let params = new HttpParams();
    if (from) {
      params = params.append('from', from.toISOString());
    }
    if (to) {
      params = params.append('to', to.toISOString());
    }
    if (departmentId) {
      params = params.append('departmentId', departmentId.toString());
    }
    return this.httpClient.get<ISaleReport>('/api/report/sale', { params });
  }
}