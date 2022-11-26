import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {IDepartment} from '../Models/department.interface';

@Injectable()
export class DepartmentService {

  constructor(private httpClient: HttpClient) {
  }

  GetDepartments(): Observable<IDepartment[]>{
    return this.httpClient.get<IDepartment[]>('/api/Department');
  }
}
