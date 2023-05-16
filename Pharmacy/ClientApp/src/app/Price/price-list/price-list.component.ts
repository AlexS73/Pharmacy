import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProductPrice } from 'src/app/Shared/Models/price.interface';
import { PriceService } from 'src/app/Shared/Services/price.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { PriceEditComponent } from '../price-edit/price-edit.component';
import { PriceNewComponent } from '../price-new/price-new.component';
import { AuthService } from 'src/app/Shared/Services/auth.service';

@Component({
  selector: 'app-price-list',
  templateUrl: './price-list.component.html',
  styleUrls: ['./price-list.component.scss']
})
export class PriceListComponent implements OnInit {

  prices: IProductPrice[];
  isAdmin: boolean;

  constructor(private priceService: PriceService, public dialog: MatDialog, private authService: AuthService) { }

  ngOnInit(): void {
    this.isAdmin = this.authService.IsAdmin;
    this.priceService.Get().subscribe(result => {
      this.prices = result;
    })
  }

  remove(priceId: number) {
    this.priceService.Remove(priceId).subscribe(res=>{
      console.log('res remove', res);
      this.prices = this.prices.filter(_=> _.Id != priceId);
    })

  }

  edit(productPrice: IProductPrice) {
    const dialogEdit = this.dialog.open(PriceEditComponent, {
      width: '250px',
      data: productPrice
    })

    dialogEdit.afterClosed().subscribe(result => {
      if (result) {
        const index = this.prices.findIndex(d => d.Id === result.Id);
        this.prices[index] = result;
      }
    })
  }

  newPrice(){
    const dialogNew = this.dialog.open(PriceNewComponent, {
      width: '250px'
    })

    dialogNew.afterClosed().subscribe(res => {
      if(res){
        this.prices.push(res);
      }
      
    })
  }

}
