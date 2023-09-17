import { Injectable, inject } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivateFn,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { catchError, finalize, map, switchMap } from 'rxjs/operators';
import { User } from '../Models/user.model';
import { environment } from 'src/environments/environment';
import { AuthModel } from '../Models/auth.model';

const API_URL = `${environment.apiUrl}`;
// const API_USERS_URL = `${API_URL}/User`;
const API_USERS_URL = `${API_URL}/v1/auth`;

export type UserModel = User | null;

@Injectable({ providedIn: 'root' })
export class LoginService {
  private authLocalStorageToken = `${environment.appVersion}-${environment.USERDATA_KEY}`;

  currentUser$: Observable<UserModel>;
  currentUserSubject: BehaviorSubject<UserModel>;

  isLoading$: Observable<boolean>;
  isLoadingSubject: BehaviorSubject<boolean>;

  get currentUserValue(): UserModel {
    return this.currentUserSubject.value;
  }

  set currentUserValue(user: UserModel) {
    this.currentUserSubject.next(user);
  }

  constructor(private router: Router, private http: HttpClient) {
    this.isLoadingSubject = new BehaviorSubject<boolean>(false);
    this.currentUserSubject = new BehaviorSubject<UserModel>(null);
    this.currentUser$ = this.currentUserSubject.asObservable();
    this.isLoading$ = this.isLoadingSubject.asObservable();

    const authUser = this.getAuthFromLocalStorage();
    // this.userSubject = new BehaviorSubject(authUser);
    this.currentUserSubject.next(authUser);
  }

  // public methods
  login(UserEmail: string, UserPassword: string) {
    this.isLoadingSubject.next(true);

    return this.http
      .post<User>(
        `${API_USERS_URL}/login`,
        { emailAddress: UserEmail, password: UserPassword }
        // { UserEmail, UserPassword },
        // { withCredentials: true }
      )
      .pipe(
        map((response: any) => {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          const auth: User = response.data;

          // login successful if there's a jwt token in the response
          if (auth && auth.accessToken) {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            const result = this.setAuthFromLocalStorage(auth);
            this.currentUserSubject.next(response);
          }
          // return result;
          return auth;
        }),
        catchError((err) => {
          console.error('err', err);
          return of(undefined);
        }),
        finalize(() => this.isLoadingSubject.next(false))
      );
  }

  logout() {
    // remove user from local storage and set current user to null
    localStorage.removeItem(this.authLocalStorageToken);
    this.currentUserSubject.next(null);
    this.router.navigate(['login']);
  }

  // private methods
  private setAuthFromLocalStorage(user: User): boolean {
    // store auth accessToken/refreshToken/epiresIn in local storage to keep user logged in between page refreshes
    if (user && user.accessToken) {
      localStorage.setItem(this.authLocalStorageToken, JSON.stringify(user));
      return true;
    }
    return false;
  }

  private getAuthFromLocalStorage(): User | null {
    try {
      const lsValue = localStorage.getItem(this.authLocalStorageToken);
      if (!lsValue) {
        return null;
      }

      const authData = JSON.parse(lsValue);
      return authData;
    } catch (error) {
      console.error(error);
      return null;
    }
  }
}

/* SAMPLE API RESPONSE for LOGIN. 
/* 
  {
    "status": true,
    "message": "Login successfully",
    "data": {
        "fullName": {
            "firstName": "Durvesh",
            "lastName": "Parmar"
        },
        
        "_id": "62a335b8954f733a2c972312",
        "username": "durveshparmar",
        "countryCode": "+91",
        "mobileNumber": "9409406924",
        "language": "en",
        "website": "https://durveshparmar.com",
        "emailAddress": "durvesh@gmail.com",
        "role": "devAdmin",
        "coverImageName": null,
        "profileImageName": null,
        "status": "active",
        "updatedAt": "2023-05-24T05:38:37.293Z",
        "createdAt": "2023-02-10T06:27:27.153Z",
        "accessToken": "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJmdWxsTmFtZSI6eyJmaXJzdE5hbWUiOiJEdXJ2ZXNoIiwibGFzdE5hbWUiOiJQYXJtYXIifSwiZGVsZXRlZCI6ZmFsc2UsIl9pZCI6IjYyYTMzNWI4OTU0ZjczM2EyYzk3MjMxMiIsInVzZXJuYW1lIjoiZHVydmVzaHBhcm1hciIsIm9jY3VwYXRpb24iOiJDRU8iLCJjb21wYW55TmFtZSI6IktlZW50aGVtZXMiLCJjb3VudHJ5Q29kZSI6Iis5MSIsIm1vYmlsZU51bWJlciI6Ijk0MDk0MDY5MjQiLCJsYW5ndWFnZSI6ImVuIiwidGltZVpvbmUiOiJJbnRlcm5hdGlvbmFsIERhdGUgTGluZSBXZXN0Iiwid2Vic2l0ZSI6Imh0dHBzOi8vZHVydmVzaHBhcm1hci5jb20iLCJlbWFpbFNldHRpbmdzIjp7ImVtYWlsTm90aWZpY2F0aW9uIjp0cnVlfSwiY29tbXVuaWNhdGlvbiI6eyJlbWFpbCI6dHJ1ZSwic21zIjp0cnVlLCJwaG9uZSI6ZmFsc2V9LCJhZGRyZXNzIjp7ImFkZHJlc3NMaW5lIjoiTC0xMi0yMCBWZXJ0ZXgsIEN5YmVyc3F1YXJlIiwiY2l0eSI6IlNhbiBGcmFuY2lzY28iLCJzdGF0ZSI6IkNhbGlmb3JuaWEiLCJwb3N0Q29kZSI6IjQ1MDAwIn0sInNvY2lhbE5ldHdvcmtzIjp7ImxpbmtlZEluIjoiaHR0cHM6Ly9saW5rZWRpbi5jb20vYWRtaW4iLCJmYWNlYm9vayI6Imh0dHBzOi8vZmFjZWJvb2suY29tL2FkbWluIiwidHdpdHRlciI6Imh0dHBzOi8vdHdpdHRlci5jb20vYWRtaW4iLCJpbnN0YWdyYW0iOiJodHRwczovL2luc3RhZ3JhbS5jb20vYWRtaW4ifSwiZW1haWxBZGRyZXNzIjoiZHVydmVzaEBkcm9wb24uZGVsaXZlcnkiLCJyb2xlIjoiZGV2QWRtaW4iLCJjb3ZlckltYWdlTmFtZSI6bnVsbCwicHJvZmlsZUltYWdlTmFtZSI6bnVsbCwic3RhdHVzIjoiYWN0aXZlIiwidXBkYXRlZEF0IjoiMjAyMy0wNS0yNFQwNTozODozNy4yOTNaIiwicmVzZXRQYXNzd29yZFRva2VucyI6W3sidG9rZW4iOiJLUU9PTlYiLCJzdGF0dXMiOiJ1dGlsaXNlZCIsImV4cGlyZXNBdCI6IjIwMjMtMDItMjFUMTI6MjM6NTEuMjk1WiIsIl9pZCI6IjYzZjRhOWM3OWMwYzVkNmQ3YTI2ZGE3ZiIsImNyZWF0ZWRBdCI6IjIwMjMtMDItMjFUMTE6MjM6NTEuMzczWiIsInVwZGF0ZWRBdCI6IjIwMjMtMDItMjFUMTE6MjQ6MjcuNTQ1WiIsInV0aWxpc2VkQXQiOiIyMDIzLTAyLTIxVDExOjI0OjI3LjU0NVoifSx7InRva2VuIjoiSFNXVlZTIiwic3RhdHVzIjoidXRpbGlzZWQiLCJleHBpcmVzQXQiOiIyMDIzLTAyLTIxVDEyOjM4OjAwLjMwNFoiLCJfaWQiOiI2M2Y0YWQxOGFhOGQ2OWRkOTkzZmMwNzMiLCJjcmVhdGVkQXQiOiIyMDIzLTAyLTIxVDExOjM4OjAwLjM5NloiLCJ1cGRhdGVkQXQiOiIyMDIzLTAyLTIxVDEyOjA3OjEzLjA4NloiLCJ1dGlsaXNlZEF0IjoiMjAyMy0wMi0yMVQxMjowNzoxMy4wODVaIn0seyJ0b2tlbiI6IklWTklUTyIsInN0YXR1cyI6InV0aWxpc2VkIiwiZXhwaXJlc0F0IjoiMjAyMy0wMi0yMVQxMzozMDozNS41NzJaIiwiX2lkIjoiNjNmNGI5NmJhYThkNjlkZDk5M2ZjMGQxIiwiY3JlYXRlZEF0IjoiMjAyMy0wMi0yMVQxMjozMDozNS43OTBaIiwidXBkYXRlZEF0IjoiMjAyMy0wMi0yMVQxMjo0MzowNi43OTZaIiwidXRpbGlzZWRBdCI6IjIwMjMtMDItMjFUMTI6NDM6MDYuNzk1WiJ9LHsidG9rZW4iOiJNRFlIVVEiLCJzdGF0dXMiOiJ1dGlsaXNlZCIsImV4cGlyZXNBdCI6IjIwMjMtMDItMjFUMTM6NDY6MTEuMDk0WiIsIl9pZCI6IjYzZjRiZDEzMDc0OTE2Mzk2YWFjMTVmMiIsImNyZWF0ZWRBdCI6IjIwMjMtMDItMjFUMTI6NDY6MTEuMTMwWiIsInVwZGF0ZWRBdCI6IjIwMjMtMDItMjFUMTI6NDY6MzUuMzg2WiIsInV0aWxpc2VkQXQiOiIyMDIzLTAyLTIxVDEyOjQ2OjM1LjM4NloifSx7InRva2VuIjoiQUhFUUtEIiwic3RhdHVzIjoidXRpbGlzZWQiLCJleHBpcmVzQXQiOiIyMDIzLTAyLTIyVDA3OjI3OjAzLjYwNFoiLCJfaWQiOiI2M2Y1YjViNzA2MDUxN2I5ZWFjZDIxNjciLCJjcmVhdGVkQXQiOiIyMDIzLTAyLTIyVDA2OjI3OjAzLjY1MVoiLCJ1cGRhdGVkQXQiOiIyMDIzLTAyLTIyVDA2OjI3OjI3LjE1M1oiLCJ1dGlsaXNlZEF0IjoiMjAyMy0wMi0yMlQwNjoyNzoyNy4xNTJaIn0seyJ0b2tlbiI6IlFZSVFDUCIsInN0YXR1cyI6InV0aWxpc2VkIiwiZXhwaXJlc0F0IjoiMjAyMy0wNS0yNFQwNjoyNjoxNS4yODVaIiwiX2lkIjoiNjQ2ZDlmZjc5YmJlOWU5YmFkY2Y0MjQ1IiwiY3JlYXRlZEF0IjoiMjAyMy0wNS0yNFQwNToyNjoxNS4zNTdaIiwidXBkYXRlZEF0IjoiMjAyMy0wNS0yNFQwNTozODozNy4yOTNaIiwidXRpbGlzZWRBdCI6IjIwMjMtMDUtMjRUMDU6Mzg6MzcuMjkyWiJ9XSwiY3JlYXRlZEF0IjoiMjAyMy0wMi0xMFQwNjoyNzoyNy4xNTNaIiwic2Vzc2lvbiI6IjY1MDZlNTM0M2Q0OGJkNDg5MjZiODA0ZSIsImlhdCI6MTY5NDk1MDcwOCwiZXhwIjoxNjk1MDM3MTA4fQ.lLSJg5E9jDO-ykOTVZfMYUFdh7gmz-wdvlAV_rnaAxU1oGDM13FoYAL1C6MS5aQ4PjrM1wf-Kf-Yl81_sS-p1BNqfYwivUITIPW6JEws8iGYqNGMBXxORwvcsXImCBwmVGqlnhJtJEXKydpZcgEmKunaNZzgQyCk8S7XGnfdQFge6xAtErh8S0Tyf0gI8FArXwLu-zw_ArcCzR-DMTkXt2cLkcSIBhJJgf0Edt_e2vJI5Ne1lifXUVlUum-vhnwL7afoCLugDWAfx_mW-zau5Q4uksEQL3jLkbFpO40wyvOfJ3LgXLd4jwGN3GX0ev-SA107KX6TeOWA1sFWvCVCYw",
        "refreshToken": "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJmdWxsTmFtZSI6eyJmaXJzdE5hbWUiOiJEdXJ2ZXNoIiwibGFzdE5hbWUiOiJQYXJtYXIifSwiZGVsZXRlZCI6ZmFsc2UsIl9pZCI6IjYyYTMzNWI4OTU0ZjczM2EyYzk3MjMxMiIsInVzZXJuYW1lIjoiZHVydmVzaHBhcm1hciIsIm9jY3VwYXRpb24iOiJDRU8iLCJjb21wYW55TmFtZSI6IktlZW50aGVtZXMiLCJjb3VudHJ5Q29kZSI6Iis5MSIsIm1vYmlsZU51bWJlciI6Ijk0MDk0MDY5MjQiLCJsYW5ndWFnZSI6ImVuIiwidGltZVpvbmUiOiJJbnRlcm5hdGlvbmFsIERhdGUgTGluZSBXZXN0Iiwid2Vic2l0ZSI6Imh0dHBzOi8vZHVydmVzaHBhcm1hci5jb20iLCJlbWFpbFNldHRpbmdzIjp7ImVtYWlsTm90aWZpY2F0aW9uIjp0cnVlfSwiY29tbXVuaWNhdGlvbiI6eyJlbWFpbCI6dHJ1ZSwic21zIjp0cnVlLCJwaG9uZSI6ZmFsc2V9LCJhZGRyZXNzIjp7ImFkZHJlc3NMaW5lIjoiTC0xMi0yMCBWZXJ0ZXgsIEN5YmVyc3F1YXJlIiwiY2l0eSI6IlNhbiBGcmFuY2lzY28iLCJzdGF0ZSI6IkNhbGlmb3JuaWEiLCJwb3N0Q29kZSI6IjQ1MDAwIn0sInNvY2lhbE5ldHdvcmtzIjp7ImxpbmtlZEluIjoiaHR0cHM6Ly9saW5rZWRpbi5jb20vYWRtaW4iLCJmYWNlYm9vayI6Imh0dHBzOi8vZmFjZWJvb2suY29tL2FkbWluIiwidHdpdHRlciI6Imh0dHBzOi8vdHdpdHRlci5jb20vYWRtaW4iLCJpbnN0YWdyYW0iOiJodHRwczovL2luc3RhZ3JhbS5jb20vYWRtaW4ifSwiZW1haWxBZGRyZXNzIjoiZHVydmVzaEBkcm9wb24uZGVsaXZlcnkiLCJyb2xlIjoiZGV2QWRtaW4iLCJjb3ZlckltYWdlTmFtZSI6bnVsbCwicHJvZmlsZUltYWdlTmFtZSI6bnVsbCwic3RhdHVzIjoiYWN0aXZlIiwidXBkYXRlZEF0IjoiMjAyMy0wNS0yNFQwNTozODozNy4yOTNaIiwicmVzZXRQYXNzd29yZFRva2VucyI6W3sidG9rZW4iOiJLUU9PTlYiLCJzdGF0dXMiOiJ1dGlsaXNlZCIsImV4cGlyZXNBdCI6IjIwMjMtMDItMjFUMTI6MjM6NTEuMjk1WiIsIl9pZCI6IjYzZjRhOWM3OWMwYzVkNmQ3YTI2ZGE3ZiIsImNyZWF0ZWRBdCI6IjIwMjMtMDItMjFUMTE6MjM6NTEuMzczWiIsInVwZGF0ZWRBdCI6IjIwMjMtMDItMjFUMTE6MjQ6MjcuNTQ1WiIsInV0aWxpc2VkQXQiOiIyMDIzLTAyLTIxVDExOjI0OjI3LjU0NVoifSx7InRva2VuIjoiSFNXVlZTIiwic3RhdHVzIjoidXRpbGlzZWQiLCJleHBpcmVzQXQiOiIyMDIzLTAyLTIxVDEyOjM4OjAwLjMwNFoiLCJfaWQiOiI2M2Y0YWQxOGFhOGQ2OWRkOTkzZmMwNzMiLCJjcmVhdGVkQXQiOiIyMDIzLTAyLTIxVDExOjM4OjAwLjM5NloiLCJ1cGRhdGVkQXQiOiIyMDIzLTAyLTIxVDEyOjA3OjEzLjA4NloiLCJ1dGlsaXNlZEF0IjoiMjAyMy0wMi0yMVQxMjowNzoxMy4wODVaIn0seyJ0b2tlbiI6IklWTklUTyIsInN0YXR1cyI6InV0aWxpc2VkIiwiZXhwaXJlc0F0IjoiMjAyMy0wMi0yMVQxMzozMDozNS41NzJaIiwiX2lkIjoiNjNmNGI5NmJhYThkNjlkZDk5M2ZjMGQxIiwiY3JlYXRlZEF0IjoiMjAyMy0wMi0yMVQxMjozMDozNS43OTBaIiwidXBkYXRlZEF0IjoiMjAyMy0wMi0yMVQxMjo0MzowNi43OTZaIiwidXRpbGlzZWRBdCI6IjIwMjMtMDItMjFUMTI6NDM6MDYuNzk1WiJ9LHsidG9rZW4iOiJNRFlIVVEiLCJzdGF0dXMiOiJ1dGlsaXNlZCIsImV4cGlyZXNBdCI6IjIwMjMtMDItMjFUMTM6NDY6MTEuMDk0WiIsIl9pZCI6IjYzZjRiZDEzMDc0OTE2Mzk2YWFjMTVmMiIsImNyZWF0ZWRBdCI6IjIwMjMtMDItMjFUMTI6NDY6MTEuMTMwWiIsInVwZGF0ZWRBdCI6IjIwMjMtMDItMjFUMTI6NDY6MzUuMzg2WiIsInV0aWxpc2VkQXQiOiIyMDIzLTAyLTIxVDEyOjQ2OjM1LjM4NloifSx7InRva2VuIjoiQUhFUUtEIiwic3RhdHVzIjoidXRpbGlzZWQiLCJleHBpcmVzQXQiOiIyMDIzLTAyLTIyVDA3OjI3OjAzLjYwNFoiLCJfaWQiOiI2M2Y1YjViNzA2MDUxN2I5ZWFjZDIxNjciLCJjcmVhdGVkQXQiOiIyMDIzLTAyLTIyVDA2OjI3OjAzLjY1MVoiLCJ1cGRhdGVkQXQiOiIyMDIzLTAyLTIyVDA2OjI3OjI3LjE1M1oiLCJ1dGlsaXNlZEF0IjoiMjAyMy0wMi0yMlQwNjoyNzoyNy4xNTJaIn0seyJ0b2tlbiI6IlFZSVFDUCIsInN0YXR1cyI6InV0aWxpc2VkIiwiZXhwaXJlc0F0IjoiMjAyMy0wNS0yNFQwNjoyNjoxNS4yODVaIiwiX2lkIjoiNjQ2ZDlmZjc5YmJlOWU5YmFkY2Y0MjQ1IiwiY3JlYXRlZEF0IjoiMjAyMy0wNS0yNFQwNToyNjoxNS4zNTdaIiwidXBkYXRlZEF0IjoiMjAyMy0wNS0yNFQwNTozODozNy4yOTNaIiwidXRpbGlzZWRBdCI6IjIwMjMtMDUtMjRUMDU6Mzg6MzcuMjkyWiJ9XSwiY3JlYXRlZEF0IjoiMjAyMy0wMi0xMFQwNjoyNzoyNy4xNTNaIiwic2Vzc2lvbiI6IjY1MDZlNTM0M2Q0OGJkNDg5MjZiODA0ZSIsImlhdCI6MTY5NDk1MDcwOCwiZXhwIjoxNzI2NTA4MzA4fQ.JwfoJXmxwaIoHdIIauCjG3WcuRdmbSSmkr8yIMYqkt-XqqO-mJ20mU3cS6JsP6qN9YHyLJxs3rHyGVVqbl-iGX_3D4_3ZZSKqcqjU7IDEQBecKfjJDzOgeGYFrb9dUF2fP_BYDoD0x1iEuIRX-P_V-LTpK5WcEUy4Q2dmKH8dV4IR2VnJBWQ0w8e0xJyt41dlJLlee3x6HmG44CmdUXN0ljejHIDtwyTHF6mGrreePSsWHXL95JSPNJymaH7S_-kvaFpmc3KSEtei8vY5lYV0qZt-qIRKw6OfT83AJnLaBpWs04K1XPbGfxA6zogA5WcIU8y2fVzCT80f4Z17JDJXA"
    }
}
*/
