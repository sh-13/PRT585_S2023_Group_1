import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.model';
import { AddEmployeeRequest } from '../models/add-employee-request.model';
import { UpdateEmployeeRequest } from '../models/update-employee-request.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  addEmployee(model: AddEmployeeRequest): Observable<AddEmployeeRequest> {
    return this.http.post<AddEmployeeRequest>('https://localhost:7246/api/Employee', model, {withCredentials: true})
  }

  showEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>('https://localhost:7246/api/Employee', {withCredentials: true})
  }

  getEmployee(employeeId: number): Observable<Employee>{
    return this.http.get<Employee>('https://localhost:7246/api/Employee/' + employeeId, {withCredentials: true})
  }

  removeEmployee(employeeId: number): Observable<void>{
    return this.http.delete<void>('https://localhost:7246/api/Employee/' + employeeId, {withCredentials: true})
  }

  updateEmployee(model: UpdateEmployeeRequest): Observable<UpdateEmployeeRequest> {
    return this.http.put<UpdateEmployeeRequest>('https://localhost:7246/api/Employee/update', model, {withCredentials: true})
  }
}
