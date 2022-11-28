import { Component, OnInit } from '@angular/core';
import {IEntrance} from "../../Shared/Models/entrance.interface";
import {CommerceService} from "../../Shared/Services/commerce.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-entrances',
  templateUrl: './entrances.component.html',
  styleUrls: ['./entrances.component.scss']
})
export class EntrancesComponent implements OnInit {
  entrances: IEntrance[];

  constructor(private commerceService: CommerceService, private router: Router) { }

  ngOnInit() {
    this.GetEntrances();
  }

  GetEntrances(){
    this.commerceService.GetEntrances().subscribe(response=> {
      this.entrances = response;
    })
  }

  GoToNewEntrance() {
    this.router.navigate(['/entrance/new'])
  }
}
