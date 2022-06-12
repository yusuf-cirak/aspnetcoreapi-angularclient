import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'; //
import {RouterModule} from '@angular/router'; //
import {appRoutes} from './routes'; //
import {FormsModule,ReactiveFormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { NavComponent } from './nav/nav.component';
import { CityComponent } from './city/city.component';
import{CityDetailComponent} from './city/city-detail/city-detail.component';//
import {NgxGalleryModule} from 'ngx-gallery-9';
import {CityAddComponent} from './city/city-add/city-add.component';
import {AlertifyService} from './services/alertify.service';

@NgModule({
  declarations: [			// Listeleme
    AppComponent,
      ValueComponent,
      NavComponent,
      CityComponent,
      CityDetailComponent,
      CityAddComponent
   ],
  imports: [ // Hazır veya kendi yazdığımız modülleri kullandığımız yer.
    BrowserModule,
    AppRoutingModule,
    HttpClientModule, //
    RouterModule.forRoot(appRoutes), //
    NgxGalleryModule, //
    FormsModule, //
    ReactiveFormsModule, //
  ],
  providers: [AlertifyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
