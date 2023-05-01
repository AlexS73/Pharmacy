import {Injectable} from '@angular/core';
import {HttpClient, HttpResponse } from '@angular/common/http';
import {Observable} from 'rxjs';
import {IDepartment} from '../Models/department.interface';
import { map } from 'rxjs/operators';

@Injectable()
export class DepartmentService {

  constructor(private httpClient: HttpClient) {
  }

  Get(): Observable<IDepartment[]>{
    return this.httpClient.get<IDepartment[]>('/api/Department');
  }

  Save(department: IDepartment): Observable<IDepartment>{
    //return this.httpClient.post<IDepartment>('/api/Department', department);
    return this.httpClient.post<IDepartment>('/api/Department', department, { observe: 'response' })
    .pipe(map((response: HttpResponse<IDepartment>) => {
        console.log('Response status:', response.ok);
        return response.body;
    }));
  }
}
