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
import {AdminComponent} from './Admin/admin.component';
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
    AdminComponent,
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

    StocksListComponent
  ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        ReactiveFormsModule,
        NgbModule,
        FormsModule,
        BrowserAnimationsModule,
        MatDialogModule,
        MatSnackBarModule,
        MatCardModule
    ],
  entryComponents: [
    PriceEditComponent
  ],
  providers: [AuthService, DepartmentService, CommerceService, ProductService, WarehouseService, PriceService, CharacteristicService, JWT_INTERCEPTOR_PROVIDER, HTTPERROR_INTERCEPTOR_PROVIDER, INITIALIZER_PROVIDER, NotificationComponent, MatSnackBar, StockService],
  bootstrap: [AppComponent]
})
export class AppModule { }
