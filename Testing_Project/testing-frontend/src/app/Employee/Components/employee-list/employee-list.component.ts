import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee.model';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];

  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {
    this.employeeService.showEmployees().subscribe((data) => {
      this.employees = data;
    });
  }

  removeEmployee(employeeId: number) {
    this.employeeService.removeEmployee(employeeId).subscribe({
      next: () => {
        // Remove the deleted employee from the local employees array
        this.employees = this.employees.filter((employee) => employee.EmployeeId !== employeeId);
        alert('Employee removed successfully');
      },
      error: (error) => {
        alert('Error removing employee. Please try again.');
      }
    });
  }
}
