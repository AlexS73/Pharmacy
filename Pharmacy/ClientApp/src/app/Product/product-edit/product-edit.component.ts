import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ICharacteresticModel, ICharacteresticTypeModel } from 'src/app/Shared/Models/characteristictype.interface';
import { IProduct } from 'src/app/Shared/Models/product.interface';
import { CharacteristicService } from 'src/app/Shared/Services/characteristic.service';
import { ProductService } from 'src/app/Shared/Services/product.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.scss']
})
export class ProductEditComponent implements OnInit {

  editProductForm: FormGroup;
  characteristicTypes: ICharacteresticTypeModel[];

  constructor(private productService: ProductService, 
    private characteristicService: CharacteristicService,
    private fb: FormBuilder, 
    public dialogRef: MatDialogRef<ProductEditComponent>,
    @Inject(MAT_DIALOG_DATA) public product: IProduct) { }

  ngOnInit(): void {
    
    this.characteristicService.GetTypes().subscribe(res=>{
      this.characteristicTypes = res;
    });

    this.editProductForm = this.fb.group({
      Id: this.fb.control(this.product.Id),
      Name: this.fb.control(this.product.Name, [Validators.required]),
      Article: this.fb.control(this.product.Article, [Validators.required]),
      Description: this.fb.control(this.product.Description),
      Characteristics: this.initRows(this.product.Characteristics)
    });
  }

  Submit($event: any) {
    $event.preventDefault();
    const result = this.productService.SaveProduct(this.editProductForm.value);
    result.subscribe(response => {
      this.dialogRef.close(response);
    })
  }

  initRows(characteristics: ICharacteresticModel[]):FormArray {
    const rows = [];
    for(const characteristic of characteristics){
      console.log('initrows', characteristic)
      const row = this.fb.group({
        TypeId: [characteristic.TypeId, Validators.required],
        Value: [characteristic.Value, Validators.required]
      });
      rows.push(row);
    }

    return this.fb.array(rows);
  }

  initRow() {
    return this.fb.group({
      TypeId: ['', Validators.required],
      Value: ['', Validators.required]
    });
  }
  get formArr(){
    return this.editProductForm.get('Characteristics') as FormArray;
  }

  AddCharacteristic(){
    this.formArr.push(this.initRow())
  }

  isCharacteristicSelected(type: ICharacteresticTypeModel, rowIndex: number): boolean {
    return this.editProductForm.value.Characteristics
      .filter((item, index) => index !== rowIndex)
      .some(item => item.Type === type);
  }

  deleteRow(i: number) {
    this.formArr.removeAt(i);
  }

}
