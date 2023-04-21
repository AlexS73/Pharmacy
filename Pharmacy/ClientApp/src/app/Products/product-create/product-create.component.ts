import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ProductService} from "../../Shared/Services/product.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.scss']
})
export class ProductCreateComponent implements OnInit {

  newProductForm: FormGroup
  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit(): void {
    this.newProductForm = new FormGroup({
      'Name' : new FormControl('', [
        Validators.required
      ]),
      'Article': new FormControl('',[
        Validators.required
      ]),
      'Description': new FormControl('',[
      ]),
    })
  }

  Submit($event: any) {
    $event.preventDefault();

    const result = this.productService.CreateProduct(this.newProductForm.value);

    result.subscribe(response => {
      this.router.navigate(['/products']);
    })
  }
}
