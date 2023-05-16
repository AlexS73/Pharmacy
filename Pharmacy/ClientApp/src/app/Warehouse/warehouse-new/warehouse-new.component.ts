import { Component, OnInit } from '@angular/core';
import { WarehouseService } from 'src/app/Shared/Services/warehouse.service';
import { MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DepartmentService } from 'src/app/Shared/Services/department.service';
import { IDepartment } from 'src/app/Shared/Models/department.interface';

@Component({
  selector: 'app-warehouse-new',
  templateUrl: './warehouse-new.component.html',
  styleUrls: ['./warehouse-new.component.scss']
})
export class WarehouseNewComponent implements OnInit {

  newWarehouseForm: FormGroup;
  departments: IDepartment[];

  constructor(private warehouseService: WarehouseService,
    private departmentService: DepartmentService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<WarehouseNewComponent>) { }

  ngOnInit(): void {
    this.departmentService.Get().subscribe(res=> {
      this.departments = res;
    })
    this.newWarehouseForm = this.fb.group({
      
      Name: this.fb.control(['']),
      Address: this.fb.control([]),
      DepartmentId: this.fb.control([], Validators.required),
    })
  }

  Submit($event: any) {
    $event.preventDefault();

    const result = this.warehouseService.Save(this.newWarehouseForm.value);

    result.subscribe(response => {
      this.dialogRef.close(response);
    });
  }

}
