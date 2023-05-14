import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IUser } from 'src/app/Shared/Models/user.interface';
import { UserService } from 'src/app/Shared/Services/user.service';
import { UserEditComponent } from '../user-edit/user-edit.component';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {
  loading: boolean;
  users: IUser[]
  constructor(private userService: UserService, public matDialog: MatDialog) { }

  ngOnInit(): void {
    this.loading = true;
    this.userService.GetList().subscribe(res=>{
      this.users = res;
      this.loading = false;
    })
  }

  edit(user: IUser){
    const dialogEdit = this.matDialog.open(UserEditComponent, {
      width: '500px',
      data: user
    })

    dialogEdit.afterClosed().subscribe(result=>{
      if (result) {
        const index = this.users.findIndex(d => d.Id === result.Id);
        this.users[index] = result;
      }
    })
  }
}
