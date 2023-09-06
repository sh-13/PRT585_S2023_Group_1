import { Component, OnInit } from '@angular/core';
import { Student } from '../models/student.model';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  students: Student[] = [];

  constructor(private studentService: StudentService) {}

  ngOnInit(): void {
    this.studentService.showStudents().subscribe((data) => {
      this.students = data;
    });
  }

  // removeStudent(number: studentId){
  //   this.studentService.removeStudent(studentId).subscribe({next:(response) => {
  //     alert(this.model.StudentName + " added successfully with id " + response.StudentId)
  //   }})
  // }
  removeStudent(studentId: number) {
    this.studentService.removeStudent(studentId).subscribe({
      next: () => {
        // Remove the deleted student from the local students array
        this.students = this.students.filter((student) => student.StudentId !== studentId);
        alert('Student removed successfully');
      },
      error: (error) => {
        alert('Error removing student. Please try again.');
      }
    });
  }
}
