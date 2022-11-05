import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http'
import { Injectable } from '@angular/core';
import { config, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) {
  }
  public loginUser(user: any): Observable<any> {
    const headers = { 'content-type': 'application/json' }
    let path = '/home';
    return this.http.post<any>(path, user);
  }
}
