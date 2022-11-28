import { Component, OnInit } from '@angular/core';
import {IWarehouse} from "../Shared/Models/warehouse.inteface";
import {WarehouseService} from "../Shared/Services/warehouse.service";

@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.scss']
})
export class WarehouseComponent implements OnInit {
  warehouseProducts: IWarehouse[];

  constructor(private readonly warehouseService: WarehouseService) { }

  ngOnInit() {
    this.warehouseService.GetLeftovers()
      .subscribe(response => this.warehouseProducts = response);
  }

}
