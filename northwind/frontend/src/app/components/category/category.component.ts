import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  categories:Category[]=[];
  currentCategory:Category; // Bir kategoriye tıkladığımızda set etmiş oluyoruz. Binding yapılabilir hale geliyor.
  dataLoaded=false;

  constructor(private categoryService:CategoryService) { }

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories(){
    console.log(" Category API Request başladı")
    this.categoryService.getCategories().subscribe(response=>{
      this.categories=response.data
      this.dataLoaded=true;
      console.log(" Category API Request bitti")
    })
    console.log("Category Metod bitti")
  }

  setCurrentCategory(category:Category){
    this.currentCategory=category;
  }

  getCurrentCategoryClass(category:Category){
    if(category==this.currentCategory){
      return "list-group-item active"
    }else{
      return "list-group-item"
    }
  }

  getAllCategoryClass(){
    if(!this.currentCategory){
      return "list-group-item active"
    }else{
      return "list-group-item"
    }
  }

}
