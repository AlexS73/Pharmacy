import { Component, OnInit } from '@angular/core';
import {AuthService} from "../Shared/Services/auth.service";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {

  isExpanded = false;
  email: string;

  constructor(private authService: AuthService){
  }

  ngOnInit() {
    console.log('GetUser', this.authService.GetUser);
    this.email = this.authService.GetUser.email;
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
}
