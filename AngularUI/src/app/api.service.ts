import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private apiUrl = 'http://localhost:5175/api/1';

  constructor(private http: HttpClient) { }

  getValues(): Observable<string[]> {
    return this.http.get<string[]>(this.apiUrl);
  }
}
