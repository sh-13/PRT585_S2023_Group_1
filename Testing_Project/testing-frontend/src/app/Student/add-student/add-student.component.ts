import { Component } from '@angular/core';
import { AddStudentRequest } from '../models/add-student-request.model';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent {
  model: AddStudentRequest;

  constructor(private studentService: StudentService){
    this.model = {
      studentId: 0,
      studentName: ''
    };
  }

  onFormSubmit(){
    this.studentService.addStudent(this.model)
    .subscribe({
      next:(response) =>{
        console.log("correct");
        alert("Student added successfully" + response)
      }
    })
  }
}
