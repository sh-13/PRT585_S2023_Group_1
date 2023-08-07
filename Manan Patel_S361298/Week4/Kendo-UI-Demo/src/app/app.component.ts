import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public students: any[] = [
    { StudentID: 1, Name: 'Manan Amitkumar Patel', Grade: 'A', DateOfBirth: new Date(2000, 0, 1) },
    { StudentID: 2, Name: 'Nare Vella', Grade: 'B', DateOfBirth: new Date(2001, 1, 1) },
    { StudentID: 3, Name: 'Anand', Grade: 'A', DateOfBirth: new Date(2002, 2, 1) },
  ];

  public filteredStudents: any[] = this.students;

  public grades: Array<string> = ['HD', 'D', 'C', 'P', 'F'];

  public filter: string = '';

  public filterChange(e: any): void {
    this.filter = e.target.value;
    if (this.filter === 'All') {
      this.filteredStudents = this.students;
    } else {
      this.filteredStudents = this.students.filter(s => s.Grade === this.filter);
    }
  }
}
