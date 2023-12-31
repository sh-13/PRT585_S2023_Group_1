import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../models/student.model';
import { AddStudentRequest } from '../models/add-student-request.model';
import { UpdateStudentRequest } from '../models/update-student-request.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient) { }

  addStudent(model: AddStudentRequest): Observable<AddStudentRequest> {
    return this.http.post<AddStudentRequest>('https://localhost:7246/api/Student', model, {withCredentials: true})
  }

  showStudents(): Observable<Student[]> {
    return this.http.get<Student[]>('https://localhost:7246/api/Student', {withCredentials: true})
  }

  getStudent(studentId: number): Observable<Student>{
    return this.http.get<Student>('https://localhost:7246/api/Student/' + studentId, {withCredentials: true})
  }

  removeStudent(studentId: number): Observable<void>{
    return this.http.delete<void>('https://localhost:7246/api/Student/' + studentId, {withCredentials: true})
  }

  updateStudent(model: UpdateStudentRequest): Observable<UpdateStudentRequest> {
    return this.http.put<UpdateStudentRequest>('https://localhost:7246/api/Student/update', model, {withCredentials: true})
  }
}
