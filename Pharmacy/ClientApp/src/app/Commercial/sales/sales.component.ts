import { Component, OnInit } from '@angular/core';
import {ISale} from "../../Shared/Models/sale.interface";
import {CommerceService} from "../../Shared/Services/commerce.service";
import {Router} from "@angular/router";


@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.scss']
})
export class SalesComponent implements OnInit {
  sales: ISale[];

  constructor(private commerceService: CommerceService, private router: Router) { }

  ngOnInit() {
    this.GetSales();
  }

  GetSales(){
    this.commerceService.GetSales().subscribe(response=> {
      this.sales = response;
    })
  }

  GoToNewSale() {
    this.router.navigate(['/sale/new'])
  }
}
