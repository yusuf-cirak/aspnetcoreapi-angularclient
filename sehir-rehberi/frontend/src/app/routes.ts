import { Routes } from "@angular/router";
import { CityAddComponent } from "./city/city-add/city-add.component";
import { CityDetailComponent } from "./city/city-detail/city-detail.component";
import { CityComponent } from "./city/city.component";
import { ValueComponent } from "./value/value.component";

export const appRoutes: Routes=[          // const= sabit
{path:"city",component:CityComponent},
{path:"value",component:ValueComponent},
{path:"citydetail/:cityId",component:CityDetailComponent},
{path:"cityadd",component:CityAddComponent},
{path:"**",redirectTo:"city",pathMatch:"full"} // default açılan sayfa city
]      

