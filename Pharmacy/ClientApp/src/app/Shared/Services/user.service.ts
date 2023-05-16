import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IUser } from "../Models/user.interface";
import {Observable} from 'rxjs';
import { IRole } from "../Models/role.inteface";

@Injectable()
export class UserService{
    constructor(private httpClient: HttpClient) {
    }
  
    GetList(): Observable<IUser[]>{
      return this.httpClient.get<IUser[]>('/api/user/all');
    }

    // GetRoles(): Observable<IRole[]>{
    //   return this.httpClient.get<IRole[]>('/api/user/roles-all');
    // }

    GetRoles(): Observable<string[]>{
      return this.httpClient.get<string[]>('/api/user/roles-all');
    }

    Save(user: IUser): Observable<IUser>{
      return this.httpClient.post<IUser>('/api/user/save', user);
    }
}