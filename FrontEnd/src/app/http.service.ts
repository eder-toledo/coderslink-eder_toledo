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
    const headers = { 'Content-Type': 'application/json' }
    let path = '/home';
    return this.http.post(path, user, { headers });
  }

  public getEmailList(lastName: string, order: string): Observable<any> {
    let path = '/home/getemaillist';
    let parameters = [];
    lastName ? parameters.push('lastName=' + lastName) : null;
    order ? parameters.push('order=' + order) : null;
    path = parameters.length > 0 ? path + "?" + parameters.join("&") : path;
    return this.http.get(path);
  }
}
