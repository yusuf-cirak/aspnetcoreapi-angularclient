import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { City } from '../models/city';
import { Photo } from '../models/photo';
import { AlertifyService } from './alertify.service';

@Injectable({
 providedIn: 'root'
})
export class CityService {

  path="https://localhost:44377/api/"

constructor(
  private httpClient:HttpClient,
  private router:Router,
  private alertifyService:AlertifyService
) { }

getCities():Observable<City[]>{
  return this.httpClient.get<City[]>(this.path+"cities/getcities")
}


getCityById(cityId:number):Observable<City>{
  return this.httpClient.get<City>(this.path+"cities/getcitybyid/"+cityId)
}

getPhotosByCityId(cityId:number):Observable<Photo[]>{
  return this.httpClient.get<Photo[]>(this.path+"cities/getphotosbycityid/"+cityId)
}

  add(city:City){
  this.httpClient.post(this.path+'cities/add',city).subscribe((data:any)=>{
    this.alertifyService.success("Şehir sisteme eklendi, detay sayfasına yönlendirildiniz") // İstersen bunu componente de yazabilirsin.
  // this.router.navigateByUrl(`/citydetail/${data["id"]}`);
  this.router.navigateByUrl("/citydetail/"+data['id']);
  })}
}