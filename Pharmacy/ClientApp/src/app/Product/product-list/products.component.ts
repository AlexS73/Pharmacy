import { Component, OnInit } from '@angular/core';
import {ProductService} from "../../Shared/Services/product.service";
import {IProduct} from "../../Shared/Models/product.interface";
import { MatDialog } from '@angular/material/dialog';
import { ProductNewComponent } from '../product-new/product-new.component';
import { ProductEditComponent } from '../product-edit/product-edit.component';
import { AuthService } from 'src/app/Shared/Services/auth.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  products: IProduct[];
  loading: boolean;

  constructor(private productService: ProductService, public dialog: MatDialog, public authService: AuthService ) { }

  ngOnInit() {
    this.loading = true;
    this.productService.GetProducts().subscribe(response=>{
      this.products = response;
      this.loading = false;
    })
  }

  edit(product: IProduct) {
    console.log('edit product', product);
    const dialogEdit = this.dialog.open(ProductEditComponent, {
      width: '500px',
      data: product
    })

    dialogEdit.afterClosed().subscribe(result => {
      if (result) {
        const index = this.products.findIndex(d => d.Id === result.Id);
        this.products[index] = result;
      }
    })
  }

  newProduct(){
    const dialogNew = this.dialog.open(ProductNewComponent, {
      width: '500px'
    })

    dialogNew.afterClosed().subscribe(res=> {
      if(res){
        this.products.push(res);
      }
      
    })
  }
 
}
