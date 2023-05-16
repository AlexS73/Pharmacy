import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DepartmentService } from 'src/app/Shared/Services/department.service';
import { IDepartment } from 'src/app/Shared/Models/department.interface';
import { WarehouseService } from 'src/app/Shared/Services/warehouse.service';
import { IWarehouse } from 'src/app/Shared/Models/warehouse.inteface';

@Component({
  selector: 'app-warehouse-edit',
  templateUrl: './warehouse-edit.component.html',
  styleUrls: ['./warehouse-edit.component.scss']
})
export class WarehouseEditComponent implements OnInit {

  editWarehouseForm: FormGroup;
  departments: IDepartment[];

  constructor(private warehouseService: WarehouseService,
    private departmentService: DepartmentService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<WarehouseEditComponent>,
    @Inject(MAT_DIALOG_DATA) public warehouse: IWarehouse) { }

  ngOnInit(): void {
    this.departmentService.Get().subscribe(res=> {
      this.departments = res;
    })
    this.editWarehouseForm = this.fb.group({
      Id: this.fb.control(this.warehouse.Id, Validators.required),
      Name: this.fb.control(this.warehouse.Name),
      Address: this.fb.control(this.warehouse.Address),
      DepartmentId: this.fb.control(this.warehouse.DepartmentId, Validators.required),
    })
  }

  Submit($event: any) {
    $event.preventDefault();

    const result = this.warehouseService.Save(this.editWarehouseForm.value);

    result.subscribe(response => {
      this.dialogRef.close(response);
    });
  }
}
