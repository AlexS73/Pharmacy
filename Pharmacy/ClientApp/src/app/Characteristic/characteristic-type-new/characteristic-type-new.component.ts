import { Component, OnInit } from '@angular/core';
import { CharacteristicService } from 'src/app/Shared/Services/characteristic.service';
import { MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-characteristic-type-new',
  templateUrl: './characteristic-type-new.component.html',
  styleUrls: ['./characteristic-type-new.component.scss']
})
export class CharacteristicTypeNewComponent implements OnInit {

  newCharacteristicTypeForm: FormGroup;

  constructor(private characteristecService: CharacteristicService, 
    public dialogRef: MatDialogRef<CharacteristicTypeNewComponent>,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.newCharacteristicTypeForm = this.fb.group({
      Name: this.fb.control([''], Validators.required)
    })
  }

  Submit($event: any) {
    $event.preventDefault();

    const result = this.characteristecService.SaveType(this.newCharacteristicTypeForm.value);

    result.subscribe(response => {
      this.dialogRef.close(response);
    });
  }

}
