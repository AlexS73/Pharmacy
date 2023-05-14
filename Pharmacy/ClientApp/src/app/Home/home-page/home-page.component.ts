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
  filteredProducts: IProductView[];
  categories: string[]
  isLoading: boolean;
  selectedCategory: string;

  constructor(private productService: ProductService) {
  }

  ngOnInit() {
    this.isLoading = true;
    this.productService.GetCategories().subscribe(res=>{
      this.categories = res;
    })
    this.productService.GetViewProducts().subscribe(res=>{
      this.products = res;
      this.filteredProducts = this.products;
      this.isLoading = false;
    })
  }

  
  // onSelectChange(value: string) {
  //   if(value === "Фильтр по категории"){
  //     this.filteredProducts = this.products;
  //   }else{
  //     this.filteredProducts = this.products.filter(_=>_.Category === value);
  //   }
 
    
  // }

  onSelectChange() {
    if(this.selectedCategory === "Все"){
           this.filteredProducts = this.products;
      }else{
        this.filteredProducts = this.products.filter(_=>_.Category === this.selectedCategory);
      }
    
  }

}
