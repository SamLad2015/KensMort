import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError, retry} from 'rxjs/operators';
import {Category} from './Category';
import {environment} from '../../environments/environment';
import {Loan, LoanRequest} from './loan';

@Injectable({
  providedIn: 'root'
})
export class LoanService {
  baseurl = environment.api + 'loan';

  constructor(private http: HttpClient) { }

  // Http Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  // GET
  GetAllLoans(request: LoanRequest): Observable<Loan[]> {
    return this.http.get<Loan[]>(`${this.baseurl}?${this.jsonToQueryString(request)}` , this.httpOptions)
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

  jsonToQueryString = (params) => {
    return Object.keys(params).map((key) => {
      return encodeURIComponent(key) + '=' + encodeURIComponent(params[key]);
    }).join('&');
  }
}
