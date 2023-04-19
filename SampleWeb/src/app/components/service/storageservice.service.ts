import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Session } from '../model/Session.model';

@Injectable({
  providedIn: 'root',
})
export class StorageserviceService {
  private localStorageService;
  private currentSession: Session;

  constructor(private router: Router) {
    this.localStorageService = localStorage;
    this.currentSession = this.loadSessionData();
  }

  setCurrentSession(session: any): void {
    this.currentSession = session;
    this.localStorageService.setItem('currentUser', JSON.stringify(session));
  }

  loadSessionData(): any {
    var sessionStr = this.localStorageService.getItem('currentUser');
    return sessionStr!;
  }

  getCurrentSession(): any {
    return this.currentSession;
  }

  removeCurrentSession(): void {
    this.localStorageService.removeItem('currentUser');
    this.currentSession!;
  }

  getCurrentUser(): any {
    var session: any = this.getCurrentSession();
    return session;
  }

  isAuthenticated(): boolean {
    return this.getCurrentToken() != null ? true : false;
  }

  getCurrentToken(): string {
    var session = this.getCurrentSession();
    return session && session.token ? session.token : '';
  }

  logout(): void {
    this.removeCurrentSession();
    this.router.navigate(['/login']);
  }
}
