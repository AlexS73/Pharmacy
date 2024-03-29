import {APP_INITIALIZER, NgModule, Provider} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './Account/login-page/login-page.component';
import { RegPageComponent } from './Account/reg-page/reg-page.component';
import { HomePageComponent } from './Home/home-page/home-page.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {AuthService} from './Shared/Services/auth.service';
import {JwtInterceptor} from './Shared/Services/jwt.interceptor';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {appInitializer} from './Shared/Services/app.initializer';
import {NavMenuComponent} from './Nav-menu/nav-menu.component';

import {DepartmentsComponent} from './Department/department-list/departments.component';
import {SalesComponent} from './Commercial/sales/sales.component';
import {EntrancesComponent} from './Commercial/entrances/entrances.component';
import {WarehouseComponent} from './Warehouse/warehouse-list/warehouse.component';
import {DepartmentService} from './Shared/Services/department.service';
import { SaleDetailComponent } from './Commercial/sale-detail/sale-detail.component';
import {CommerceService} from "./Shared/Services/commerce.service";

import {ProductService} from "./Shared/Services/product.service";
import { SaleCreateComponent } from './Commercial/sale-create/sale-create.component';
import {EntranceCreateComponent} from "./Commercial/entrance-create/entrance-create.component";
import {EntranceDetailComponent} from "./Commercial/entrance-detail/entrance-detail.component";
import {WarehouseService} from "./Shared/Services/warehouse.service";
import { PriceService } from './Shared/Services/price.service';
import { PriceEditComponent } from './Price/price-edit/price-edit.component';
import { PriceNewComponent } from './Price/price-new/price-new.component';
import { PriceListComponent } from './Price/price-list/price-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { NotificationComponent } from './Notification/notification.component';
import { HttpErrorInterceptor } from './Shared/Services/http-error.interceptor';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { DepartmentNewComponent } from './Department/department-new/department-new.component';
import { DepartmentEditComponent } from './Department/department-edit/department-edit.component';
import { WarehouseNewComponent } from './Warehouse/warehouse-new/warehouse-new.component';
import { WarehouseEditComponent } from './Warehouse/warehouse-edit/warehouse-edit.component';

import { ProductsComponent } from './Product/product-list/products.component';
import { ProductEditComponent } from './Product/product-edit/product-edit.component';
import { ProductNewComponent } from './Product/product-new/product-new.component';
import { CharacteristicService } from './Shared/Services/characteristic.service';
import { CharacteristicTypeListComponent } from './Characteristic/characteristic-type-list/characteristic-type-list.component';
import { CharacteristicTypeNewComponent } from './Characteristic/characteristic-type-new/characteristic-type-new.component';
import { CharacteristicTypeEditComponent } from './Characteristic/characteristic-type-edit/characteristic-type-edit.component';
import { StocksListComponent } from './Stocks/stocks-list/stocks-list.component';
import { StockService } from './Shared/Services/stock.service';
import { MatCardModule } from '@angular/material/card';
import { UserEditComponent } from './Account/user-edit/user-edit.component';
import { UsersListComponent } from './Account/users-list/users-list.component';
import { UserService } from './Shared/Services/user.service';
import { UserDetailComponent } from './Account/user-detail/user-detail.component';
import { ReportService } from './Shared/Services/report.service';
import { EntranceReportComponent } from './Reports/entrance-report/entrance-report.component';
import { SaleReportComponent } from './Reports/sale-report/sale-report.component';

import { MatCommonModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatMenuModule } from '@angular/material/menu';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';


const JWT_INTERCEPTOR_PROVIDER: Provider = {
  provide: HTTP_INTERCEPTORS,
  useClass: JwtInterceptor,
  multi: true
};

const HTTPERROR_INTERCEPTOR_PROVIDER: Provider = {
  provide: HTTP_INTERCEPTORS,
  useClass: HttpErrorInterceptor,
  multi: true
};

const INITIALIZER_PROVIDER: Provider = {
  provide: APP_INITIALIZER,
  useFactory: appInitializer,
  multi: true,
  deps: [AuthService]
};

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    RegPageComponent,
    HomePageComponent,
    NavMenuComponent,

    SalesComponent,
    DepartmentsComponent,
    EntrancesComponent,
    WarehouseComponent,
    SaleDetailComponent,

    SaleCreateComponent,
    EntranceCreateComponent,
    EntranceDetailComponent,

    PriceEditComponent,
    PriceNewComponent,
    PriceListComponent,

    NotificationComponent,
    DepartmentNewComponent,
    DepartmentEditComponent,
    
    WarehouseNewComponent,
    WarehouseEditComponent,

    ProductsComponent,
    ProductEditComponent,
    ProductNewComponent,
    
    CharacteristicTypeListComponent,
    CharacteristicTypeNewComponent,
    CharacteristicTypeEditComponent,

    StocksListComponent,
    
    UserEditComponent,
    UsersListComponent,
    UserDetailComponent,

    EntranceReportComponent,
    SaleReportComponent
  ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        ReactiveFormsModule,
        NgbModule,
        FormsModule,
        BrowserAnimationsModule,

        MatCommonModule,
        MatDialogModule,
        MatSnackBarModule,
        MatCardModule,
        MatFormFieldModule,
        MatDatepickerModule,
        MatInputModule,
        MatNativeDateModule,
        MatTableModule,
        MatSortModule,
        MatPaginatorModule,
        MatButtonModule,
        MatSelectModule,
        MatMenuModule,
        MatToolbarModule,
        MatIconModule,
        MatListModule

    ],
  entryComponents: [
    PriceEditComponent
  ],
  providers: [
    AuthService, 
    DepartmentService, 
    CommerceService, 
    ProductService, 
    WarehouseService, 
    PriceService, 
    CharacteristicService,
    StockService,
    UserService,
    ReportService,
    JWT_INTERCEPTOR_PROVIDER, 
    HTTPERROR_INTERCEPTOR_PROVIDER, 
    INITIALIZER_PROVIDER, 
    NotificationComponent, 
    MatSnackBar, 
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
