import { Component, Input, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IProductPrice } from 'src/app/Shared/Models/price.interface';
import { PriceService } from 'src/app/Shared/Services/price.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IProduct } from 'src/app/Shared/Models/product.interface';

@Component({
  selector: 'app-price-edit',
  templateUrl: './price-edit.component.html',
  styleUrls: ['./price-edit.component.scss']
})
export class PriceEditComponent implements OnInit {
  
  editPriceForm: FormGroup;
  
  constructor(private priceService: PriceService, private fb: FormBuilder, 
    public dialogRef: MatDialogRef<PriceEditComponent>,
    @Inject(MAT_DIALOG_DATA) public productPrice: IProductPrice) { }

  ngOnInit(): void {
    this.editPriceForm = this.fb.group({
      Price: this.fb.control([this.productPrice.Price])
    })
  }

  Submit($event: any) {
    $event.preventDefault();

    const result = this.priceService.Save(this.editPriceForm.value);

    result.subscribe(response => {
      console.log('responce', response);
      this.dialogRef.close();
    });
  }

}
