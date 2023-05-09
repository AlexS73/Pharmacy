import { Component, OnInit } from '@angular/core';
import {ProductService} from "../../Shared/Services/product.service";
import {IProduct} from "../../Shared/Models/product.interface";
import { MatDialog } from '@angular/material/dialog';
import { ProductNewComponent } from '../product-new/product-new.component';
import { ProductEditComponent } from '../product-edit/product-edit.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  products: IProduct[];
  loading: boolean;

  constructor(private productService: ProductService, public dialog: MatDialog) { }

  ngOnInit() {
    this.loading = true;
    this.productService.GetProducts().subscribe(response=>{
      this.products = response;
      this.loading = false;
    })
  }

  edit(product: IProduct) {
    const dialogEdit = this.dialog.open(ProductEditComponent, {
      width: '500px',
      data: product
    })
  }

  newProduct(){
    const dialogEdit = this.dialog.open(ProductNewComponent, {
      width: '500px'
    })
  }
 
}
