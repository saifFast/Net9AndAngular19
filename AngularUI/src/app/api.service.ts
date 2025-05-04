import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private apiUrl = 'https://localhost:7273/api/Person/1';

  constructor(private http: HttpClient) { }

  getData(): Observable<string[]> {
    return this.http.get<string[]>(this.apiUrl);
  }
}
