import { Component, OnInit } from '@angular/core';
import {FormArray, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {ProductService} from "../../Shared/Services/product.service";
import {IProduct} from "../../Shared/Models/product.interface";
import {CommerceService} from "../../Shared/Services/commerce.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-sale-create',
  templateUrl: './sale-create.component.html',
  styleUrls: ['./sale-create.component.scss']
})
export class SaleCreateComponent implements OnInit {
  newSaleForm: FormGroup;
  products: IProduct[];

  constructor(private fb: FormBuilder, private productService: ProductService, private commerceService: CommerceService, private router: Router) { }

  ngOnInit(): void {
    this.productService.GetProducts().subscribe(response=> {
      this.products = response;
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
    return this.fb.group({
      Product: ['', Validators.required],
      Count: ['', Validators.required]
    })
  }

  deleteRow(i: number) {
    this.formArr.removeAt(i);
  }
}
