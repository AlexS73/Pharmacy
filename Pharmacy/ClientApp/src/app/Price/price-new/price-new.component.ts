import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { IProduct } from 'src/app/Shared/Models/product.interface';
import { IWarehouse } from 'src/app/Shared/Models/warehouse.inteface';
import { PriceService } from 'src/app/Shared/Services/price.service';
import { ProductService } from 'src/app/Shared/Services/product.service';
import { WarehouseService } from 'src/app/Shared/Services/warehouse.service';

@Component({
  selector: 'app-price-new',
  templateUrl: './price-new.component.html',
  styleUrls: ['./price-new.component.scss']
})
export class PriceNewComponent implements OnInit {

  newPriceForm: FormGroup;
  products: IProduct[];
  warehouses: IWarehouse[];
  
  constructor(private priceService: PriceService, 
    private productService: ProductService, 
    private warehouseServices: WarehouseService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<PriceNewComponent>) { }

  ngOnInit(): void {
    this.productService.GetProducts().subscribe(res=> {
      this.products = res;
    });

    this.newPriceForm = this.fb.group({
      Product: this.fb.control(['']),
      Price: this.fb.control([])
    })

    this.warehouseServices.Get().subscribe(res=> {
      this.warehouses = res;
    })
  }

  Submit($event: any) {
    $event.preventDefault();

    const result = this.priceService.Save(this.newPriceForm.value);

    result.subscribe(response => {
      console.log('responce', response);
      this.dialogRef.close();
    });
    
  }

}
