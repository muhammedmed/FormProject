import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

    serverUrl = "https://localhost:7082/api";

    registerUser(){
       return this.http.post(this.serverUrl + '/User', {},{responseType:'text',}
       );
    }
  
}
