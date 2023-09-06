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
      StudentId: 0,
      StudentName: ''
    };
  }

  onAddStudentSubmit(){
    this.studentService.addStudent(this.model).subscribe({next:(response) => {
      alert(this.model.StudentName + " added successfully with id " + response.StudentId)
    }})
  }
}
