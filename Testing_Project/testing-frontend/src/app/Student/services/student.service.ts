import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddStudentRequest } from '../models/add-student-request.model';
import { Observable } from 'rxjs';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient) { }

  addStudent(model: AddStudentRequest): Observable<void> {
    return this.http.post<void>('https://localhost:7246/api/Student', model)
  }

  showStudents(): Observable<Student[]> {
    var x = this.http.get<Student[]>('https://localhost:7246/api/Student')
    console.log(x)
    return x
    // return this.http.get<Student[]>('https://localhost:7246/api/Student')
  }
}
