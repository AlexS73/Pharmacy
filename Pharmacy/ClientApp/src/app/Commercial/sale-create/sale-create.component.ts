import { Component, OnInit } from '@angular/core';
import {FormArray, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {ProductService} from "../../Shared/Services/product.service";
import {IProduct} from "../../Shared/Models/product.interface";
import {CommerceService} from "../../Shared/Services/commerce.service";
import {Router} from "@angular/router";
import { PriceService } from 'src/app/Shared/Services/price.service';
import { IProductPrice } from 'src/app/Shared/Models/price.interface';

@Component({
  selector: 'app-sale-create',
  templateUrl: './sale-create.component.html',
  styleUrls: ['./sale-create.component.scss']
})
export class SaleCreateComponent implements OnInit {
  newSaleForm: FormGroup;
  products: IProduct[];
  prices: IProductPrice[];

  constructor(private fb: FormBuilder, private productService: ProductService, private commerceService: CommerceService, private router: Router, private priceService: PriceService) { }

  ngOnInit(): void {
    this.productService.GetProducts().subscribe(response=> {
      this.products = response;
    })

    this.priceService.Get().subscribe(response => {
      this.prices = response;
    })

    this.newSaleForm = this.fb.group({
      Customer: this.fb.control(['']),
      SaleProducts: this.fb.array([this.initRow()])
    });
  }

  get formArr(){
    return this.newSaleForm.get('SaleProducts') as FormArray;
  }

  Submit($event: any) {
    $event.preventDefault();

    const result = this.commerceService.CreateSale(this.newSaleForm.value);

    result.subscribe(response => {
      this.router.navigate(['/sales']);
    });
  }

  AddProduct() {
    console.log(this.newSaleForm);
    this.formArr.push(this.initRow())
  }

  initRow() {
    var row = this.fb.group({
      ProductId: ['', Validators.required],
      Count: [1, [Validators.required, Validators.min(1)]],
      Price: [0, Validators.required],
      Sum: ['']
    })

    row.get('ProductId').valueChanges.subscribe(val=>{
      this.updateProductPrice(row)
    })

    row.get('Count').valueChanges.subscribe(val => {
      this.updateSum(row);
    })

    row.get('Price').valueChanges.subscribe(val => {
      this.updateSum(row);
    })

    return row;
  }

  updateProductPrice(row: any){
    const productId: number = row.get('ProductId').value;
    const priceObj = this.prices.find(p=> p.Product.Id === productId)
    const price = priceObj ? priceObj.Price : 0; // если объект цены найден, получаем его цену, иначе - 0
    row.get('Price').setValue(price); // устанавливаем цену продукта в соответствующее поле формы
  }

  updateSum(row: FormGroup){
    const count = row.get('Count').value;
    const price = row.get('Price').value;
    const sum = count * price;
  
    row.patchValue({
      Sum: sum
    });
  }

  // isProductSelected(product: IProduct, rowIndex: number): boolean {
  //   console.log('isProductSelected product',product);
  //   console.log('rowIndex', rowIndex);
  //   console.log('this.newSaleForm.value.SaleProducts',this.newSaleForm.value.SaleProducts);
  //   return this.newSaleForm.value.SaleProducts
  //     .filter((item, index) => index !== rowIndex)
  //     .some(item => item.Product === product);
  // }

  // productSelecting(product: IProduct, rowIndex: number){
  //   console.log('productSelecting');
  // }


  deleteRow(i: number) {
    this.formArr.removeAt(i);
  }
}
