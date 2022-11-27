import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomePageComponent} from './Home/home-page/home-page.component';
import {RegPageComponent} from './Account/reg-page/reg-page.component';
import {LoginPageComponent} from './Account/login-page/login-page.component';
import {AuthGuardService} from './Shared/Services/auth.guard.service';
import {ProductsComponent} from './Products/products.component';
import {SalesComponent} from './Commercial/sales/sales.component';
import {EntrancesComponent} from './Commercial/entrances/entrances.component';
import {AdminComponent} from './Admin/admin.component';
import {WarehouseComponent} from './Warehouse/warehouse.component';
import {DepartmentsComponent} from './Departments/departments.component';
import {SaleDetailComponent} from "./Commercial/sale-detail/sale-detail.component";

const routes: Routes = [
  {path: '', component: HomePageComponent, canActivate: [ AuthGuardService ]},
  {path: 'registration', component: RegPageComponent, canActivate: [ AuthGuardService ]},
  {path: 'login', component: LoginPageComponent, canActivate: [ AuthGuardService ]},
  { path: 'products', component: ProductsComponent, canActivate: [ AuthGuardService ]},
  { path: 'sales', component: SalesComponent, canActivate: [ AuthGuardService ]},
  { path: 'sale/:id', component: SaleDetailComponent, canActivate: [AuthGuardService]},
  { path: 'entrances', component: EntrancesComponent, canActivate: [ AuthGuardService ]},
  { path: 'admin', component: AdminComponent, canActivate: [ AuthGuardService ]},
  { path: 'warehouse', component: WarehouseComponent, canActivate: [ AuthGuardService ]},
  { path: 'departments', component: DepartmentsComponent, canActivate: [ AuthGuardService ]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuardService]
})
export class AppRoutingModule { }
