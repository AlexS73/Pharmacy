import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntranceReportComponent } from './entrance-report.component';

describe('EntranceReportComponent', () => {
  let component: EntranceReportComponent;
  let fixture: ComponentFixture<EntranceReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EntranceReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EntranceReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
