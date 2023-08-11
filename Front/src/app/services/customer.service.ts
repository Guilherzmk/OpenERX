import { Injectable, Input, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { enviroments } from 'src/environments/environments';
import { SignInComponent } from '../components/screens/sign-in/sign-in.component';
import { SignInParams } from '../models/SignInParams';
import { CustomerParams } from '../models/CustomerParams';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  private baseApiUrl = enviroments.baseApiUrl;
  private apiUrl = `${this.baseApiUrl}customers`;
  private token = localStorage.getItem('Token');

  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    Authorization: `Bearer ${this.token}`,
  });

  constructor(private http: HttpClient) {}

  getCustomers(): Observable<CustomerParams[]> {
    return this.http.get<CustomerParams[]>(this.apiUrl, {
      headers: this.headers,
    });
  }
}
