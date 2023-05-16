import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ICharacteresticModel, ICharacteresticTypeModel } from 'src/app/Shared/Models/characteristictype.interface';
import { CharacteristicService } from 'src/app/Shared/Services/characteristic.service';
import { CharacteristicTypeNewComponent } from '../characteristic-type-new/characteristic-type-new.component';

@Component({
  selector: 'app-characteristic-type-list',
  templateUrl: './characteristic-type-list.component.html',
  styleUrls: ['./characteristic-type-list.component.scss']
})
export class CharacteristicTypeListComponent implements OnInit {

  characteristicTypes: ICharacteresticTypeModel[]
  constructor(private characteristicService: CharacteristicService, public matDialog: MatDialog) { }

  ngOnInit(): void {
    this.characteristicService.GetTypes().subscribe(res => {
      this.characteristicTypes = res;
    })
  }

  newCharacteristicType(){
    const diologNew = this.matDialog.open(CharacteristicTypeNewComponent, {
      width: '250px'
    });

    diologNew.afterClosed().subscribe(result=>{
      if(result){
        this.characteristicTypes.push(result);
      }
    })
  }

}
