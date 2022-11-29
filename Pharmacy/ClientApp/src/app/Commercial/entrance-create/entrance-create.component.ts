import { Component, OnInit } from '@angular/core';
import {FormArray, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {ProductService} from "../../Shared/Services/product.service";
import {IProduct} from "../../Shared/Models/product.interface";
import {CommerceService} from "../../Shared/Services/commerce.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-entrance-create',
  templateUrl: './entrance-create.component.html',
  styleUrls: ['./entrance-create.component.scss']
})
export class EntranceCreateComponent implements OnInit {
  newEntranceForm: FormGroup;
  products: IProduct[];

  constructor(private fb: FormBuilder, private productService: ProductService, private commerceService: CommerceService, private router: Router) { }

  ngOnInit(): void {
    this.productService.GetProducts().subscribe(response => {
      this.products = response;
    });

    this.newEntranceForm = this.fb.group({
      Supplier: this.fb.control(['']),
      EntranceProducts: this.fb.array([this.initRow()])
    });
  }

  get formArr(){
    return this.newEntranceForm.get('EntranceProducts') as FormArray;
  }

  Submit($event: any) {
    $event.preventDefault();
    console.log(this.newEntranceForm.value);
    const result = this.commerceService.CreateEntrance(this.newEntranceForm.value);

    result.subscribe(response => {
      this.router.navigate(['/entrances']);
    });
  }

  AddProduct() {
    this.formArr.push(this.initRow());
  }

  initRow() {
    return this.fb.group({
      Product: ['', Validators.required],
      Count: ['', Validators.required]
    });
  }

  deleteRow(i: number) {
    this.formArr.removeAt(i);
  }
}
