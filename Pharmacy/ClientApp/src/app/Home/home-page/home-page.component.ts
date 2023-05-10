import { Component, OnInit } from '@angular/core';
import { IProductView } from 'src/app/Shared/Models/productview.interface';
import { ProductService } from 'src/app/Shared/Services/product.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

  products: IProductView[];
  isLoading: boolean;

  constructor(private productService: ProductService) {
  }

  ngOnInit() {
    this.isLoading = true;
    this.productService.GetViewProducts().subscribe(res=>{
      this.products = res;
      this.isLoading = false;
    })
  }

}
