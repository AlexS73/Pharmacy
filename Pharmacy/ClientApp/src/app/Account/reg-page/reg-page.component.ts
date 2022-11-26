import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {AuthService} from "../../Shared/Services/auth.service";
import {DepartmentService} from '../../Shared/Services/department.service';
import {IDepartment} from '../../Shared/Models/department.interface';

@Component({
  selector: 'app-reg-page',
  templateUrl: './reg-page.component.html',
  styleUrls: ['./reg-page.component.scss']
})
export class RegPageComponent implements OnInit {

  regForm : FormGroup;
  private loading: boolean;
  public departments: IDepartment[];

  constructor(private authService: AuthService, private router: Router, private departmetnService: DepartmentService) { }

  ngOnInit(): void {

    this.departmetnService.GetDepartments()
      .subscribe(response => {
        this.departments = response;
      });

    this.regForm = new FormGroup({
      "Email" : new FormControl('',[
        Validators.email,
        Validators.required
      ]),
      'DepartmentId': new FormControl('', [
        Validators.required
      ]),
      "Password" : new FormControl('', [
        Validators.required,
        Validators.minLength(8)
      ]),
      "ConfirmPassword" : new FormControl('', [
      ])
    });
  }

  Submit(e) {
    e.preventDefault();
    const { Email, DepartmentId, Password, ConfirmPassword } = this.regForm.value;
    this.loading = true;

    const result = this.authService.Registration(Email, DepartmentId, Password, ConfirmPassword);

    result.subscribe((data) => {
      this.loading = false;
      this.router.navigate(['/']);
    }, (data) => {
      this.loading = false;
      // notify(data.error.message, 'error', 2000);
    });
  }

}
