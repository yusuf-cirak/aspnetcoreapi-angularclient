import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html', // ./ aynı klasör demek
  styleUrls: ['./app.component.css'] // [] array demek
})
export class AppComponent {
  title: string = 'northwind';
  user: string = "Yusuf Çırak";
}

// Html'in datasını yönettiğimiz yer.
// Süslü parantez {} obje demek.