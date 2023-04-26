import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { IPrice } from 'src/app/Shared/Models/price.interface';
import { PriceService } from 'src/app/Shared/Services/price.service';

@Component({
  selector: 'app-price-edit',
  templateUrl: './price-edit.component.html',
  styleUrls: ['./price-edit.component.scss']
})
export class PriceEditComponent implements OnInit {

  @Input()
  productPrice: IPrice;
  
  editPriceForm: FormGroup;
  
  constructor(private priceService: PriceService, private fb: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.editPriceForm = this.fb.group({
      Price: this.fb.control([this.productPrice.Price])
    })
  }

  Submit($event: any) {
    $event.preventDefault();

    const result = this.priceService.Save(this.editPriceForm.value);

    result.subscribe(response => {
      this.router.navigate(['/prices']);
    });
  }

}
