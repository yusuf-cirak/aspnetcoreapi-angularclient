import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'; //
import { Value } from '../models/value';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  values:Value[]=[];

  constructor(
    private httpClient:HttpClient,
  ) { }

  ngOnInit() {
    this.getValues().subscribe(data=>{
      this.values=data; // Backend'de dönen actionresult burası oluyor.
    })
  }

  getValues(){
    return this.httpClient.get<Value[]>("https://localhost:44349/api/values/getvalues")
  } // generic kısımda map işlemi yapılıyor.

}
