import { Component, OnInit } from '@angular/core';
import {ProductService} from "../Shared/Services/product.service";
import {IProduct} from "../Shared/Models/product.interface";
import {Router} from "@angular/router";

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  products: IProduct[];
  loading: boolean;

  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit() {
    this.loading = true;
    this.productService.GetProducts().subscribe(response=>{
      this.products = response;
      console.log(this.products);
      this.loading = false;
    })
  }

  GoToNewProduct() {
    this.router.navigate(['/product/new'])
  }
}
