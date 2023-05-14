import { Component, OnInit } from '@angular/core';
import {AuthService} from "../Shared/Services/auth.service";
import { MatDialog } from '@angular/material/dialog';
import { UserEditComponent } from '../Account/user-edit/user-edit.component';
import { UserDetailComponent } from '../Account/user-detail/user-detail.component';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {

  isExpanded = false;
  email: string;

  constructor(public authService: AuthService, public matDialog: MatDialog){
  }

  ngOnInit() {
    console.log('GetUser', this.authService.GetUser);

    this.email = this.authService.GetUser.Email;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout(){
    console.log('logout');
    this.authService.LogOut();
  }

  accountDetail(){
    this.matDialog.open(UserDetailComponent, {
      width: '500px'
    })
  }
}
