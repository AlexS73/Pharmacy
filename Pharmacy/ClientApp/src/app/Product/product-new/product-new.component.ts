import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ICharacteresticModel, ICharacteresticTypeModel } from 'src/app/Shared/Models/characteristictype.enum';
import { CharacteristicService } from 'src/app/Shared/Services/characteristic.service';
import { ProductService } from 'src/app/Shared/Services/product.service';

@Component({
  selector: 'app-product-new',
  templateUrl: './product-new.component.html',
  styleUrls: ['./product-new.component.scss']
})
export class ProductNewComponent implements OnInit {

  newProductForm: FormGroup;
  characteristicTypes: ICharacteresticTypeModel[];

  constructor(private productService: ProductService, 
    private characteristicService: CharacteristicService,
    private fb: FormBuilder, 
    public dialogRef: MatDialogRef<ProductNewComponent>) { }

  ngOnInit(): void {
    
    this.characteristicService.GetTypes().subscribe(res=>{
      this.characteristicTypes = res;
    });

    this.newProductForm = this.fb.group({
      Name: this.fb.control([''], [Validators.required]),
      Article: this.fb.control([''], [Validators.required]),
      Description: this.fb.control(['']),
      Characteristics: this.fb.array([])
    });
  }

  Submit($event: any) {
    $event.preventDefault();
    const result = this.productService.CreateProduct(this.newProductForm.value);
    result.subscribe(response => {
      this.dialogRef.close();
    })
  }

  initRow() {
    return this.fb.group({
      TypeId: ['', Validators.required],
      Value: ['', Validators.required]
    });
  }
  get formArr(){
    return this.newProductForm.get('Characteristics') as FormArray;
  }

  AddCharacteristic(){
    this.formArr.push(this.initRow())
  }

  isCharacteristicSelected(type: ICharacteresticTypeModel, rowIndex: number): boolean {
    return this.newProductForm.value.Characteristics
      .filter((item, index) => index !== rowIndex)
      .some(item => item.Type === type);
  }

  deleteRow(i: number) {
    this.formArr.removeAt(i);
  }

}
