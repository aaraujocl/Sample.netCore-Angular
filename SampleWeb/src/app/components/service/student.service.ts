import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, of, switchMap, take } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  uriapi: string = environment.urlAuthentication;

  constructor(private httpClient: HttpClient) {}

  getById(id: number) {
    const httpHeaders = new HttpHeaders().set(
      'Content-Type',
      'application/json'
    );

    const endpoint: any = this.uriapi + 'api/student/' + id;
    //this.loadingService.setLoading(true);
    return this.httpClient.get(endpoint, { headers: httpHeaders }).pipe(
      take(1),
      map((entity: any) => {
        return entity;
      }),
      switchMap((entity) => {
        if (!entity) {
        }

        return of(entity);
      })
    );
  }

  listView() {
    const httpHeaders = new HttpHeaders().set(
      'Content-Type',
      'application/json'
    );
    const endpoint: any = this.uriapi + 'api/student';
    return this.httpClient.get(endpoint, { headers: httpHeaders });
  }

  save(id: number, entity: any, isnew: boolean) {
    if (isnew) return this.add(id, entity);
    else return this.update(id, entity);
  }

  add(id: number = 0, entity: any) {
    const httpHeaders = new HttpHeaders().set(
      'Content-Type',
      'application/json'
    );
    entity.id = id;
    const endpoint: any = this.uriapi + 'api/student/';
    return this.httpClient
      .post(endpoint, JSON.stringify(entity), { headers: httpHeaders })
      .pipe(
        map((newentity) => {
          return newentity;
        }),
        catchError((error: HttpErrorResponse): Observable<any> => {
          return of(null);
        })
      );
  }

  update(id: number, entity: any) {
    const httpHeaders = new HttpHeaders().set(
      'Content-Type',
      'application/json'
    );
    entity.id = id;
    const endpoint: any = this.uriapi + 'api/student/' + id;
    return this.httpClient
      .put(endpoint, JSON.stringify(entity), { headers: httpHeaders })
      .pipe(
        map((newentity) => {
          return newentity;
        }),
        catchError((error: HttpErrorResponse): Observable<any> => {
          return of(null);
        })
      );
  }

  delete(id: number): Observable<boolean> {
    const httpHeaders = new HttpHeaders().set(
      'Content-Type',
      'application/json'
    );

    const endpoint: any = this.uriapi + 'api/student/' + id;
    return this.httpClient
      .delete<boolean>(endpoint, { headers: httpHeaders })
      .pipe(
        map((isDeleted: boolean) => {
          return isDeleted;
        }),
        catchError((error: HttpErrorResponse): Observable<any> => {
          return of(null); // or any other stream like of('') etc.
        })
      );
  }
}
