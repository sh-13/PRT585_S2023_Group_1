import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../Models/user.model';

@Injectable({ providedIn: 'root' })
export class RegistrationService {

  constructor(private http: HttpClient) {  }

  addUser(model: User): Observable<User> {
    return this.http.post<User>('https://localhost:7246/api/User/register', model, {withCredentials: true})
  }

}
