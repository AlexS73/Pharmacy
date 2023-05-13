import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IUser } from 'src/app/Shared/Models/user.interface';
import { AuthService } from 'src/app/Shared/Services/auth.service';

@Component({
  selector: 'app-account-detail',
  templateUrl: './account-detail.component.html',
  styleUrls: ['./account-detail.component.scss']
})
export class AccountDetailComponent implements OnInit {

  user: IUser;

  constructor(public deailogRef: MatDialogRef<AccountDetailComponent>, private authService: AuthService) { }

  ngOnInit(): void {
    this.user = this.authService.GetUser;
  }

}
