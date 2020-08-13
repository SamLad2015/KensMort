import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError, retry} from 'rxjs/operators';
import {environment} from '../../environments/environment';
import {Loan, LoanRequest} from './loan';
import {Scenario} from "./scenario";

@Injectable({
  providedIn: 'root'
})
export class ScenarioService {
  baseurl = environment.api + 'scenario';

  constructor(private http: HttpClient) { }

  // Http Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  // POST
  Upload(file: any): Observable<Scenario[]> {
    const formData = new FormData();
    formData.append('formFile', file, file.name);
    return this.http.post<Scenario[]>(`${this.baseurl}/upload` , formData)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  // Error handling
  errorHandler(error): Observable<never> {
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
