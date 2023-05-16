import { Component, OnInit } from '@angular/core';
import { IStock } from 'src/app/Shared/Models/stock.interface';
import { StockService } from 'src/app/Shared/Services/stock.service';

@Component({
  selector: 'app-stocks-list',
  templateUrl: './stocks-list.component.html',
  styleUrls: ['./stocks-list.component.scss']
})
export class StocksListComponent implements OnInit {

  stocks: IStock[]
  stocksLoading: boolean;
  constructor(private stockService: StockService) { }

  ngOnInit(): void {
    this.stocksLoading = true;
    this.stockService.Get().subscribe(res=> {
      this.stocks = res;
      this.stocksLoading = false;
    })
  }

}
