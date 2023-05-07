import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DepartmentService } from 'src/app/Shared/Services/department.service';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-department-new',
  templateUrl: './department-new.component.html',
  styleUrls: ['./department-new.component.scss']
})
export class DepartmentNewComponent implements OnInit {

  newDepartmentForm: FormGroup;

  constructor(private departmentService: DepartmentService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<DepartmentNewComponent>) { }

  ngOnInit(): void {
    this.newDepartmentForm = this.fb.group({
      Name: this.fb.control(['']),
      Address: this.fb.control([])
    })
  }

  Submit($event: any) {
    $event.preventDefault();

    const result = this.departmentService.Save(this.newDepartmentForm.value);

    result.subscribe(response => {
      this.dialogRef.close(response);
    });
  }

}
