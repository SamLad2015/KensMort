import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Candidate, Skill, Skills} from './candidate';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class SkillService {
  // Base url
  baseurl = 'https://localhost:5001/api/v1.0/skill';

  constructor(private http: HttpClient) { }

  // Http Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  // GET
  GetAllSkills(): Observable<Skill[]> {
    return this.http.get<Skill[]>(this.baseurl , this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  // POST
  AddSkills(id, data): Observable<any> {
    return this.http.post<Skills>(`${this.baseurl}/${id}/skills` , JSON.stringify(data), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  // PUT
  UpdateSkills(id, data): Observable<any> {
    return this.http.put<Skills>(`${this.baseurl}/${id}/skills`, JSON.stringify(data), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  // DELETE
  DeleteSkills(id): Observable<any> {
    return this.http.delete<any>(`${this.baseurl}/${id}`, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  // Error handling
  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
