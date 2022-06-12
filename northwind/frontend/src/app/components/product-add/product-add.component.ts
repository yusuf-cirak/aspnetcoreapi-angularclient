import { Component, OnInit } from '@angular/core';
import {FormGroup,FormBuilder,FormControl,Validators} from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  productAddForm:FormGroup

  constructor(private formBuilder:FormBuilder,
    private productService:ProductService,
    private toastrService:ToastrService
   ) { }

  ngOnInit(): void {
    this.createProductAddForm();
  }

  createProductAddForm(){
    this.productAddForm=this.formBuilder.group({
      productName:["",Validators.required],
      unitPrice:["",Validators.required],
      unitsInStock:["",Validators.required],
      categoryId:["",Validators.required]
      // "" kısmı default halinde ne vermemiz gerektiğidir.

    })
  }


  add(){
    if(this.productAddForm.valid){
      let productModel = Object.assign({},this.productAddForm.value)
      // productmodel için boş bir obje oluşturuyor.productaddform'un içerisindeki alıp {} içerisine ekliyor.
      this.productService.add(productModel).subscribe(response=>{
        this.toastrService.success(response.message,"Başarılı")
      },responseError=>{
        if(responseError.error.Errors.length>0){
          for (let i = 0; i <responseError.error.Errors.length; i++) {
            this.toastrService.error(responseError.error.Errors[i].ErrorMessage
              ,"Doğrulama hatası")
          }       
        } 
      })
      // Bu productModel'i de productService'ye yani sql ve backend kısmına entegre ediyor.
    }else{
      this.toastrService.error("Formunuz eksik","Dikkat")
    }
    
  }
}
