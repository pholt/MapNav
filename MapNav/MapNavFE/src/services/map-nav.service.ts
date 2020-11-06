import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MapNavService {
  
  constructor(
    private httpClient: HttpClient
    ) { }
    
  public getMapNav(input:string):Observable<any> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');
    return this.httpClient.post("/api/MapNav", `{"data": "${input}"}`, {
      headers: headers
    });
  }
}
