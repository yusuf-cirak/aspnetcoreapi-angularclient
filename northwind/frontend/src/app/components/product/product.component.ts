import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Product } from 'src/app/models/product';
import { CartService } from 'src/app/services/cart.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products:Product[]=[];
  dataLoaded=false;
  filterText="";
  
  constructor(private productService:ProductService,
    private activatedRoute:ActivatedRoute,
    private toastrService:ToastrService,
    private cartService:CartService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["categoryId"]){
        this.getProductsByCategory(params["categoryId"])
      }else{
        this.getProducts();
      }
    })
  }

  getProducts(){
    console.log("API Request başladı")
    this.productService.getProducts().subscribe(response=>{
      this.products=response.data
      this.dataLoaded=true;
      console.log("API Request bitti")
    })
    console.log("Metod bitti")
  }

  getProductsByCategory(categoryId:number){
    console.log("API Request başladı")
    this.productService.getProductsByCategory(categoryId).subscribe(response=>{
      this.products=response.data
      this.dataLoaded=true;
      console.log("API Request bitti")
    })
    console.log("Metod bitti")
  }

  addToCart(product:Product){
    if(product.unitsInStock===0){
      this.toastrService.error("Stokta ürün olmadığı için sepete ekleme işlemi başarısız","Hata")
    }else{
      this.toastrService.success("Sepete eklendi",product.productName)
      this.cartService.addToCart(product);
    }

  }

}
