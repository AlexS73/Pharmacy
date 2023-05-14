import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { IDepartment } from 'src/app/Shared/Models/department.interface';
import { IEntranceReport } from 'src/app/Shared/Models/entranceReport.interface';
import { ISaleReport } from 'src/app/Shared/Models/saleReport.interface';
import { DepartmentService } from 'src/app/Shared/Services/department.service';
import { ReportService } from 'src/app/Shared/Services/report.service';

@Component({
  selector: 'app-sale-report',
  templateUrl: './sale-report.component.html',
  styleUrls: ['./sale-report.component.scss']
})
export class SaleReportComponent implements OnInit {

  report: ISaleReport;
  displayedColumns: string[] = ['product', 'count', 'sum'];
  selectedDepartment: IDepartment | null = null;
  departments: IDepartment[] = [];

  constructor(private reportService: ReportService, private departmentService: DepartmentService) { }

  ngOnInit(): void {
    //this.reportService.GetEntranceReport().subscribe(report => this.report = report);
    this.departmentService.Get().subscribe(res=>{
      this.departments = res;
    })
  }

  fromDate: Date = null;
  toDate: Date = null;

  onFromDateChange(event: any) {
    this.fromDate = event.value;
    //this.loadReport();
  }

  onToDateChange(event: any) {
    this.toDate = event.value;
    //this.loadReport();
  }

  onDepartmentChange(event: any) {
    this.selectedDepartment = event.value;
  }

  loadReport() {
    this.reportService.GetSaleReport(this.fromDate, this.toDate, this.selectedDepartment?.Id )
    .subscribe(report => {
      this.report = report
    });
  }
}
