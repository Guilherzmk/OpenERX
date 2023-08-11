import { Injectable, Input, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { enviroments } from 'src/environments/environments';
import { SignInComponent } from '../components/screens/sign-in/sign-in.component';
import { SignInParams } from '../models/SignInParams';

@Injectable({
  providedIn: 'root',
})
export class SignInService {
  private baseApiUrl = enviroments.baseApiUrl;
  private apiUrl = `${this.baseApiUrl}/sign-in`;

  constructor(private http: HttpClient) {}

  signIn(params: SignInParams): Observable<SignInParams> {
    return this.http.post<SignInParams>(
      'http://localhost:5045/v1/sign-in',
      params
    );
  }
}
