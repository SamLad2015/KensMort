import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Candidate} from './candidate';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class CandidateService {

  // Base url
  baseurl = 'https://localhost:5001/api/v1.0/candidatelisting';

  constructor(private http: HttpClient) { }

  // Http Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  // GET
  GetAllCandidates(): Observable<Candidate[]> {
    return this.http.get<Candidate[]>(this.baseurl , this.httpOptions )
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  // POST
  CreateCandidate(data): Observable<any> {
    return this.http.post<Candidate>(this.baseurl , JSON.stringify(data), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  // PUT
  UpdateCandidate(data): Observable<any> {
    return this.http.put<Candidate>(this.baseurl + '/' + data.id, JSON.stringify(data), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  // DELETE
  DeleteCandidate(id): Observable<any> {
    return this.http.delete<Candidate>(this.baseurl + '/' + id, this.httpOptions)
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
