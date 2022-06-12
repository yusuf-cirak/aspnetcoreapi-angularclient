import { Component, OnInit } from '@angular/core';
import { City } from '../models/city';
import { CityService } from '../services/city.service';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css'],
  providers:[CityService] // Dependency injection
})
export class CityComponent implements OnInit {
  cities:City[]

  constructor(
    private cityService:CityService,

  ) { }

  ngOnInit() {
    this.cityService.getCities().subscribe(data=>{
      this.cities=data
      console.log(data)
    })
  }

}
