import { BrowserModule } from '@angular/platform-browser';
import {APP_INITIALIZER, NgModule, Provider} from '@angular/core';
import { FormsModule } from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { ProductsComponent } from './products/products.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { SalesComponent } from './commercial/sales/sales.component';
import { DepartmentsComponent } from './departments/departments.component';
import { AdminComponent } from './admin/admin.component';
import { EntrancesComponent } from './commercial/entrances/entrances.component';
import { WarehouseComponent } from './warehouse/warehouse.component';
import {JwtInterceptor} from './shared/services/jwt.interceptor';
import { initializeApp} from './shared/services/app.initializer';
import {UserService} from './shared/services/user.service';
import {AppRoutingModule} from './app-routing.module';

const INTERCEPTOR_PROVIDER: Provider = {
  provide: HTTP_INTERCEPTORS,
  useClass: JwtInterceptor,
  multi: true
};

const INITIALIZER_PROVIDER: Provider = {
  provide: APP_INITIALIZER,
  useFactory: ()=> initializeApp,
  multi: true,
  deps: [UserService]
};

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    RegistrationComponent,
    LoginComponent,
    ProductsComponent,
    ProductDetailComponent,
    SalesComponent,
    DepartmentsComponent,
    AdminComponent,
    EntrancesComponent,
    WarehouseComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [ INTERCEPTOR_PROVIDER, INITIALIZER_PROVIDER],
  bootstrap: [AppComponent]
})
export class AppModule { }
