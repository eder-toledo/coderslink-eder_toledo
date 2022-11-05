import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ApiService } from './http.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  public forecasts?: WeatherForecast[];
  

  constructor(private http: HttpClient, private httpApi: ApiService) {
    http.get<WeatherForecast[]>('/weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  onClickSubmit(data: User) {
    
    this.httpApi.loginUser(data).subscribe({
      next: data => {
        alert('Response by API: ' + data.message);
      },
      error: error => {
        alert('Response an error!: ' + error.message)
      }
    });
  }

  title = 'FrontEnd';
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface User {
  lastName: string;
  firstName: string;
  email: string;
}
