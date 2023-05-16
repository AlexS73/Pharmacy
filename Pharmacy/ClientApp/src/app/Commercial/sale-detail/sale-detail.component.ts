import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {switchMap} from "rxjs/operators";
import {ISale} from "../../Shared/Models/sale.interface";
import {CommerceService} from "../../Shared/Services/commerce.service";

@Component({
  selector: 'app-sale-detail',
  templateUrl: './sale-detail.component.html',
  styleUrls: ['./sale-detail.component.scss']
})
export class SaleDetailComponent implements OnInit {

  id: number | undefined;
  sale: ISale

  constructor(private route: ActivatedRoute, private commerceService: CommerceService){}
  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    )
      .subscribe(data=> this.commerceService.GetSale(+data)
        .subscribe(response => this.sale = response));
  }

  getSaleProductsSum(): number {
    return this.sale.SaleProducts.reduce(function (acc, sp) { return acc + sp.Price; }, 0);
  }
}
