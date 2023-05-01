import { Component, Input, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DepartmentService } from 'src/app/Shared/Services/department.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IDepartment } from 'src/app/Shared/Models/department.interface';


@Component({
  selector: 'app-department-edit',
  templateUrl: './department-edit.component.html',
  styleUrls: ['./department-edit.component.scss']
})
export class DepartmentEditComponent implements OnInit {

  editDepartmentForm: FormGroup;

  constructor(private departmentService: DepartmentService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<DepartmentEditComponent>,
    @Inject(MAT_DIALOG_DATA) public department: IDepartment) { }

  ngOnInit(): void {
    this.editDepartmentForm = this.fb.group({
      Id: this.fb.control(this.department.Id, Validators.required),
      Name: this.fb.control(this.department.Name,Validators.required),
      Address: this.fb.control(this.department.Address)
    })
  }

  Submit($event: any) {
    $event.preventDefault();

    const result = this.departmentService.Save(this.editDepartmentForm.value);
    
    result.subscribe(response => {
      this.dialogRef.close(response);
    });
  }

}
