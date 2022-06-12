import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Router } from '@angular/router';
import { AlertifyService } from './alertify.service';
import { JwtHelper, tokenNotExpired } from 'angular2-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  path="https://localhost:44377/api/"
  userToken:any;
  decodedToken:any; // Çözümlenmiş token
  jwtHelper:JwtHelper= new JwtHelper(); // ctor olarak tanımlarsan newlemene gerek yok.
  TOKEN_KEY="token"

constructor(
  private httpClient:HttpClient,
  private alertifyService:AlertifyService,
  private router:Router
) { }

login(user:User){
  let headers= new HttpHeaders();
  headers=headers.append("Content-Type","application-json")
  this.httpClient.post(this.path+"auth/login",user,{headers:headers}).subscribe((data:any)=>{
    this.saveToken(data)
    this.userToken=data;
    this.decodedToken=this.jwtHelper.decodeToken(data.toString())
    this.alertifyService.success("Başarıyla giriş yaptınız")
    this.router.navigateByUrl("/city")
  })
}


register(user:User){
  let headers= new HttpHeaders();
  headers=headers.append("Content-Type","application-json")
  this.httpClient.post(this.path+"auth/register",user,{headers:headers})
  .subscribe(data=>{


  })

}

saveToken(token:string){
  localStorage.setItem(this.TOKEN_KEY,token)
}

logOut(){
  localStorage.removeItem(this.TOKEN_KEY)
  this.alertifyService.warning("Sistemden çıkış yaptınız")
}

loggedIn(){
  return tokenNotExpired(this.TOKEN_KEY)
}

get token(){
  return localStorage.getItem(this.TOKEN_KEY)
}

getCurrentUserId(){
  return this.jwtHelper.decodeToken
  (this.token).nameid
}

}
