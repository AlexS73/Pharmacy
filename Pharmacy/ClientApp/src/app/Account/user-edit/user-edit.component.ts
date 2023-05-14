import { Component, OnInit, Inject } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IRole } from 'src/app/Shared/Models/role.inteface';
import { IUser } from 'src/app/Shared/Models/user.interface';
import { AuthService } from 'src/app/Shared/Services/auth.service';
import { UserService } from 'src/app/Shared/Services/user.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.scss']
})
export class UserEditComponent implements OnInit {

  loading: boolean;
  editUserForm: FormGroup;
  roles: string[];

  constructor(public dialogRef: MatDialogRef<UserEditComponent>, 
    private userService: UserService,
    @Inject(MAT_DIALOG_DATA) public user: IUser,
    private fb: FormBuilder) { }

    ngOnInit(): void {
      this.loading = true;
      this.userService.GetRoles().subscribe(res => {
        this.roles = res;
        this.editUserForm = this.fb.group({
          Id: [this.user.Id, Validators.required],
          UserName: [this.user.UserName, Validators.required],
          Roles: [this.user.Roles, Validators.required]
        });
        this.loading = false;
      });
    }
    
    isChecked(role: string): boolean {
      return this.editUserForm.value.Roles.includes(role);
    }
  
    toggleRole(role: string): void {
      const roles = this.editUserForm.value.Roles;
      if (roles.includes(role)) {
        this.editUserForm.patchValue({
          Roles: roles.filter(r => r !== role)
        });
      } else {
        this.editUserForm.patchValue({
          Roles: [...roles, role]
        });
      }
    }
  

  Submit($event){
    $event.preventDefault();

    console.log(JSON.stringify(this.editUserForm.value));
    this.userService.Save(this.editUserForm.value).subscribe(res=>{
      this.dialogRef.close(res);
    })

  }

}
