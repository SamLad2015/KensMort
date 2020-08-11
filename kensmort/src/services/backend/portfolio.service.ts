import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError, retry} from 'rxjs/operators';
import {Category} from './Category';
import {environment} from '../../environments/environment';
import {Portfolio} from './portfolio';

@Injectable({
  providedIn: 'root'
})
export class PortfolioService {

  baseurl = environment.api + 'portfolio';

  constructor(private http: HttpClient) { }

  // Http Headers
  httpOptions = {
    headers: new HttpHeaders({
       'Content-Type': 'application/json',
    })
  };

  // GET
  GetAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseurl + '/categories' , this.httpOptions )
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  // GET
  GetPortfolios(categoryId: number): Observable<Portfolio[]> {
    return this.http.get<Portfolio[]>(`${this.baseurl}/categories/${categoryId}/portfolios`  , this.httpOptions )
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
