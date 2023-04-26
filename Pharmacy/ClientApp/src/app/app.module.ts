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
import {ProductsComponent} from './Products/products.component';
import {DepartmentsComponent} from './Departments/departments.component';
import {SalesComponent} from './Commercial/sales/sales.component';
import {ProductDetailComponent} from './Product-detail/product-detail.component';
import {AdminComponent} from './Admin/admin.component';
import {EntrancesComponent} from './Commercial/entrances/entrances.component';
import {WarehouseComponent} from './Warehouse/warehouse.component';
import {DepartmentService} from './Shared/Services/department.service';
import { SaleDetailComponent } from './Commercial/sale-detail/sale-detail.component';
import {CommerceService} from "./Shared/Services/commerce.service";
import { ProductCreateComponent } from './Products/product-create/product-create.component';
import {ProductService} from "./Shared/Services/product.service";
import { SaleCreateComponent } from './Commercial/sale-create/sale-create.component';
import {EntranceCreateComponent} from "./Commercial/entrance-create/entrance-create.component";
import {EntranceDetailComponent} from "./Commercial/entrance-detail/entrance-detail.component";
import {WarehouseService} from "./Shared/Services/warehouse.service";
import { PriceService } from './Shared/Services/price.service';
import { PriceEditComponent } from './Price/price-edit/price-edit.component';
import { PriceNewComponent } from './Price/price-new/price-new.component';
import { PriceListComponent } from './Price/price-list/price-list.component';

const INTERCEPTOR_PROVIDER: Provider = {
  provide: HTTP_INTERCEPTORS,
  useClass: JwtInterceptor,
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
    ProductsComponent,
    ProductDetailComponent,
    SalesComponent,
    DepartmentsComponent,
    AdminComponent,
    EntrancesComponent,
    WarehouseComponent,
    SaleDetailComponent,
    ProductCreateComponent,
    SaleCreateComponent,

    EntranceCreateComponent,
    EntranceDetailComponent,
    PriceEditComponent,
    PriceNewComponent,
    PriceListComponent
  ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        ReactiveFormsModule,
        NgbModule,
        FormsModule,
    ],
  providers: [AuthService, DepartmentService, CommerceService, ProductService, WarehouseService, PriceService, INTERCEPTOR_PROVIDER, INITIALIZER_PROVIDER],
  bootstrap: [AppComponent]
})
export class AppModule { }
