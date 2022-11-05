import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ApiService } from './http.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private httpApi: ApiService) {
  }

  onClickSubmit(data: User) {
    
    this.httpApi.loginUser(data).subscribe({
      next: data => {
        alert(`Received user: ${data.lastName} ${data.firstName} ${data.email} ` );
      },
      error: error => {
        alert('Response an error!: ' + error.message)
      }
    });
  }

  title = 'FrontEnd';
}

interface User {
  lastName: string;
  firstName: string;
  email: string;
}
