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

  emailList = [];
  login = false;

  onClickSubmit(data: User) {
    
    this.httpApi.loginUser(data).subscribe({
      next: data => {
        alert(`Received user: ${data.lastName} ${data.firstName} ${data.email} `);
        this.login = true;
      },
      error: error => {
        alert('Response an error!: ' + error.message)
      }
    });
  }

  onClickGetData(data: any) {
    this.httpApi.getEmailList(data.lastName, data.order).subscribe({
      next: data => {
        this.emailList = data;
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
