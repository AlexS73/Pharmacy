import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {switchMap} from "rxjs/operators";
import {CommerceService} from "../../Shared/Services/commerce.service";
import {IEntrance} from "../../Shared/Models/entrance.interface";

@Component({
  selector: 'app-entrance-detail',
  templateUrl: './entrance-detail.component.html',
  styleUrls: ['./entrance-detail.component.scss']
})
export class EntranceDetailComponent implements OnInit {

  id: number | undefined;
  entrance: IEntrance;

  constructor(private route: ActivatedRoute, private commerceService: CommerceService){}
  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    )
      .subscribe(data=> this.commerceService.GetEntrance(+data)
        .subscribe(response => this.entrance = response));
  }
}
