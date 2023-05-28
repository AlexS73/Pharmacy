import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../../Shared/Services/department.service';
import { IDepartment } from '../../Shared/Models/department.interface';
import { DepartmentNewComponent } from '../department-new/department-new.component';
import { MatDialog } from '@angular/material/dialog';
import { DepartmentEditComponent } from '../department-edit/department-edit.component';

@Component({
  selector: 'app-departmetns',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.scss']
})
export class DepartmentsComponent implements OnInit {

  departments: IDepartment[]

  constructor(private departmentService: DepartmentService, public dialog: MatDialog) { }

  ngOnInit() {
    this.departmentService.Get().subscribe(res=> {
      this.departments = res;
      console.log('departments', res);
    });
  }

  newDepartment(){
    const dialogNew = this.dialog.open(DepartmentNewComponent, {
      width: '250px'
    })

    dialogNew.afterClosed().subscribe(result => {
      if (result) {
        this.departments.push(result);
      }
    })
  }

  edit(department: IDepartment) {
    const dialogEdit = this.dialog.open(DepartmentEditComponent, {
      width: '250px',
      data: department
    })

    dialogEdit.afterClosed().subscribe(result => {
      if (result) {
        const index = this.departments.findIndex(d => d.Id === result.Id);
        this.departments[index] = result;
      }
    })
  }
}
