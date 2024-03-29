import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {map, tap} from "rxjs/operators";
import { IUser } from "../Models/user.interface";

const defaultPath = '/';

@Injectable()
export class AuthService {

  private user: IUser = null;
  private _lastAuthenticatedPath: string = defaultPath;
  private refreshTokenTimeout;

  constructor(private http: HttpClient, private router: Router) {
    this.setToken = this.setToken.bind(this);
  }

  LogIn(Email: string, Password: string){
    return this.http.post('/api/Account/authenticate', {'UserName': Email, Password})
      .pipe(
        tap(this.setToken)
      )
  }

  Registration(Email: string, DepartmentId: number, Password: string, ConfirmPassword: string){
    return this.http.post('/api/Account/registration', {Email, DepartmentId, Password, ConfirmPassword})
      .pipe(
        tap(this.setToken)
      )
  }

  LogOut(){
    this.http.post<any>(`/api/Account/revoke-token`, {}, { withCredentials: true }).subscribe(res=>{
      this.stopRefreshTokenTimer();
      this.setToken(null);
      this.router.navigate(['/login']);
    });
  }

  RefreshToken(){
    return this.http.post<any>(`/api/Account/refresh-token`, null)
      .pipe(map((response) => {
          this.setToken(response);
        })
      );
  }

  get loggedIn(): boolean {
    return !!this.token;
  }

  public get token(): string{
    const expDate = new Date(localStorage.getItem('token-exp'));
    if (new Date() > expDate){
      localStorage.clear();
      return null;
    }
    return localStorage.getItem('token');
  }

  set lastAuthenticatedPath(value: string) {
    this._lastAuthenticatedPath = value;
  }

  private setToken(response){
    if (response){
      const jwtToken = JSON.parse(atob(response.JwtToken.split('.')[1]));
      const expDate = new Date(jwtToken.exp * 1000);
      localStorage.setItem('token', response.JwtToken);
      localStorage.setItem('token-exp', expDate.toString());
      this.startRefreshTokenTimer();
      console.log('setToken responce', response);
      this.user = response.User;
    }
    else {
      this.user = null;
      localStorage.clear();
    }
  }

  public get GetUser(){
    return this.user;
  }

  public get IsAdmin(){
    return this.user.Roles.includes('administrator');
  }

  private startRefreshTokenTimer(){
    const jwtToken = JSON.parse(atob(this.token.split('.')[1]));

    // set a timeout to refresh the token a minute before it expires
    const expires = new Date(jwtToken.exp * 1000);
    const timeout = expires.getTime() - Date.now() - (60 * 1000);
    this.refreshTokenTimeout = setTimeout(() => this.RefreshToken().subscribe(), timeout);
  }

  private stopRefreshTokenTimer(): void {
    clearTimeout(this.refreshTokenTimeout);
  }

}
