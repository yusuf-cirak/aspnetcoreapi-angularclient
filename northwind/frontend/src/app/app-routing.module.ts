import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductAddComponent } from './components/product-add/product-add.component';
import { ProductComponent } from './components/product/product.component';
import { LoginComponent } from './components/login/login.component';
import { LoginGuard } from './guards/login.guard';

const routes: Routes = [{
  path:"",pathMatch:"full",component:ProductComponent},
  {path:"products",component:ProductComponent}, // Sitede /products eklediğimizde çalışacak.
  {path:"products/category/:categoryId",component:ProductComponent},
  {path:"products/add",component:ProductAddComponent,canActivate:[LoginGuard]},
  
  {path:"login",component:LoginComponent},
]; // Burada yazdığımız şeyin karşılığı
// <router-outlet></router-outlet>'de çalışır.

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

