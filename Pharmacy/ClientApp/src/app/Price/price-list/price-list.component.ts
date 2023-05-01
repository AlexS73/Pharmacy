import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProductPrice } from 'src/app/Shared/Models/price.interface';
import { PriceService } from 'src/app/Shared/Services/price.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { PriceEditComponent } from '../price-edit/price-edit.component';
import { PriceNewComponent } from '../price-new/price-new.component';

@Component({
  selector: 'app-price-list',
  templateUrl: './price-list.component.html',
  styleUrls: ['./price-list.component.scss']
})
export class PriceListComponent implements OnInit {



  prices: IProductPrice[]

  constructor(private priceService: PriceService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.priceService.Get().subscribe(result => {
      this.prices = result;
      console.log('prices',this.prices);
    })
  }

  remove(arg0: any) {
    console.log('remove');
  }
  edit(productPrice: IProductPrice) {
    const dialogEdit = this.dialog.open(PriceEditComponent, {
      width: '250px',
      data: productPrice
    })
  }

  newPrice(){
    const dialogEdit = this.dialog.open(PriceNewComponent, {
      width: '250px'
    })
  }

}
