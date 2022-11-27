import { Component, OnInit } from '@angular/core';
import {ISale} from "../../Shared/Models/sale.interface";
import {SaleService} from "../../Shared/Services/sale.service";

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.scss']
})
export class SalesComponent implements OnInit {
  sales: ISale[];

  constructor(private saleService: SaleService) { }

  ngOnInit() {
    this.GetSales();
  }

  GetSales(){
    this.saleService.GetSales().subscribe(response=> {
      this.sales = response;
    })
  }
}
