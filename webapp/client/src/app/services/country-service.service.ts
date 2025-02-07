import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Config} from "../utils/config";

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  private apiUrl = `${Config.baseUrl}/Country`; // Update with your backend URL

  constructor(private http: HttpClient) {}

  GetAll(): Observable<any> {
    return this.http.get(`${this.apiUrl}/GetAll`);
  }

  GetById(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/GetById/${id}`);
  }
}
