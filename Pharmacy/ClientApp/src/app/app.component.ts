import { Component } from '@angular/core';
import {AuthService} from './Shared/Services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(private authService: AuthService) {
  }

  title = 'ClientApp';

  isLoggedIn(){
    return this.authService.loggedIn;
  }
}
