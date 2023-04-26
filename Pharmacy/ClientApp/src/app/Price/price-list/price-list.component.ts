import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPrice } from 'src/app/Shared/Models/price.interface';
import { PriceService } from 'src/app/Shared/Services/price.service';

@Component({
  selector: 'app-price-list',
  templateUrl: './price-list.component.html',
  styleUrls: ['./price-list.component.scss']
})
export class PriceListComponent implements OnInit {



  prices: IPrice[]

  constructor(private priceService: PriceService) { }

  ngOnInit(): void {
    this.priceService.Get().subscribe(result => {
      this.prices = result;
      console.log('prices',this.prices);
    })
  }

  remove(arg0: any) {
    console.log('remove');
  }
  edit(arg0: any) {
    console.log('edit');
  }

}
