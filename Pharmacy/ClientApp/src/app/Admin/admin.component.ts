import { Component, OnInit } from '@angular/core';
import {IDepartment} from '../Shared/Models/department.interface';
import {DepartmentService} from '../Shared/Services/department.service';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {IWarehouse} from '../Shared/Models/warehouse.inteface';
import {WarehouseService} from '../Shared/Services/warehouse.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  companies: string[] = ['Main', 'Alpha'];
  selectedCompany: string;
  warehouseProducts: IWarehouse[];

  constructor(private warehouseService: WarehouseService) { }

  ngOnInit() {
  }

  GetLeftoversForDepartment(){
    this.warehouseService.GetLeftoversForDepartment(this.selectedCompany)
      .subscribe(response => this.warehouseProducts = response);
  }
}
