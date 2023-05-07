import { Component, OnInit } from '@angular/core';
import {IWarehouse} from "../../Shared/Models/warehouse.inteface";
import {WarehouseService} from "../../Shared/Services/warehouse.service";
import { WarehouseNewComponent } from '../warehouse-new/warehouse-new.component';
import { MatDialog } from '@angular/material/dialog';
import { WarehouseEditComponent } from '../warehouse-edit/warehouse-edit.component';
import { IDepartment } from 'src/app/Shared/Models/department.interface';
import { DepartmentService } from 'src/app/Shared/Services/department.service';

@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.scss']
})
export class WarehouseComponent implements OnInit {
  warehouses: IWarehouse[];
  departments: IDepartment[];

  constructor(private readonly warehouseService: WarehouseService, private departmentService: DepartmentService, public dialog: MatDialog) { }

  ngOnInit() {

    this.departmentService.Get().subscribe(res => {
      this.departments = res;
    })

    this.warehouseService.Get().subscribe(res=>{
      this.warehouses = res;
    })
  }

  newWarehouse(){
    const dialogNew = this.dialog.open(WarehouseNewComponent, {
      width: '250px'
    })

    dialogNew.afterClosed().subscribe(result => {
      if (result) {
        this.warehouses.push(result);
      }
    })
  }

  edit(warehouse: IWarehouse) {
    const dialogEdit = this.dialog.open(WarehouseEditComponent, {
      width: '250px',
      data: warehouse
    })

    dialogEdit.afterClosed().subscribe(result => {
      if (result) {
        const index = this.warehouses.findIndex(d => d.Id === result.Id);
        this.warehouses[index] = result;
      }
    })
  }

  getDepartmentNameById(id: number): string{
    return this.departments.find(_=> _.Id === id).Name;
  }
  

}
