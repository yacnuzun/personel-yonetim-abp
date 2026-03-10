import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private tokenUrl = `${environment.apiUrl}/connect/token`;

  constructor(private http: HttpClient) {}

  async login(username: string, password: string): Promise<boolean> {
    const body = new URLSearchParams();
    body.set('grant_type', 'password');
    body.set('client_id', 'PersonelYonetim_App');
    body.set('client_secret', '1q2w3e*');
    body.set('username', username);
    body.set('password', password);
    body.set('scope', 'openid profile email PersonelYonetim');

    try {
      const response = await this.http.post<any>(
        this.tokenUrl,
        body.toString(),
        {
          headers: new HttpHeaders({
            'Content-Type': 'application/x-www-form-urlencoded'
          })
        }
      ).toPromise();

      localStorage.setItem('access_token', response.access_token);
      localStorage.setItem('refresh_token', response.refresh_token);
      return true;
    } catch {
      return false;
    }
  }

  logout(): void {
    localStorage.removeItem('access_token');
    localStorage.removeItem('refresh_token');
  }

  getToken(): string | null {
    return localStorage.getItem('access_token');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }
}