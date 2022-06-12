import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  user:any={} // ilk etapta boş nesne olacak

  constructor(
    private authService:AuthService
  ) { }

  ngOnInit() {
  }

  login(){
    this.authService.login(this.user);
  }

  logOut(){
    this.authService.logOut()
  }

  get isAuthenticated(){
   return this.authService.loggedIn()
  }
  }
