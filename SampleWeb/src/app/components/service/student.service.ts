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
        //this.loadingService.setLoading(false);
        // Return the categoria
        return entity;
      }),
      switchMap((entity) => {
        if (!entity) {
          //this.loadingService.setLoading(false);
          //return throwError(() => new Error('Could not found categoria with id of ' + id + '!'));
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
    //this.loadingService.setLoading(true);
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
    //this.loadingService.setLoading(true);
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
    //this.loadingService.setLoading(true);
    const endpoint: any = this.uriapi + 'api/student/' + id;
    return this.httpClient
      .delete<boolean>(endpoint, { headers: httpHeaders })
      .pipe(
        map((isDeleted: boolean) => {
          //this.loadingService.setLoading(false);
          return isDeleted;
        }),
        catchError((error: HttpErrorResponse): Observable<any> => {
          //this.loadingService.setLoading(false);
          //this.toastService.showErrorToast('Error ', error.message);
          return of(null); // or any other stream like of('') etc.
        })
      );
  }
}
