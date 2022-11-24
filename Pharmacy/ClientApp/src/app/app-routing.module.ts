import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {ProductsComponent} from './products/products.component';
import {SalesComponent} from './commercial/sales/sales.component';
import {EntrancesComponent} from './commercial/entrances/entrances.component';
import {AdminComponent} from './admin/admin.component';
import {RegistrationComponent} from './user/registration/registration.component';
import {LoginComponent} from './user/login/login.component';
import {WarehouseComponent} from './warehouse/warehouse.component';
import {DepartmentsComponent} from './departments/departments.component';
import {AuthGuardService} from './shared/services/auth.guard.service';
import {NgModule} from '@angular/core';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [ AuthGuardService ] },
  { path: 'products', component: ProductsComponent, canActivate: [ AuthGuardService ]},
  { path: 'sales', component: SalesComponent, canActivate: [ AuthGuardService ]},
  { path: 'entrances', component: EntrancesComponent, canActivate: [ AuthGuardService ]},
  { path: 'admin', component: AdminComponent, canActivate: [ AuthGuardService ]},
  { path: 'registration', component: RegistrationComponent, canActivate: [ AuthGuardService ]},
  { path: 'login', component: LoginComponent, canActivate: [ AuthGuardService ]},
  { path: 'warehouse', component: WarehouseComponent, canActivate: [ AuthGuardService ]},
  { path: 'departments', component: DepartmentsComponent, canActivate: [ AuthGuardService ]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuardService]
})
export class AppRoutingModule { }
