
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { map, Observable } from 'rxjs';
import { EmployeesService } from './employees.service';
import { Employees } from '../Models/Employees';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-Employee',
  templateUrl: './Employees.component.html',
  styleUrls: ['./Employees.component.css']
})
export class EmployeesComponent implements OnInit {

  EmployeeList?: Observable<Employees[]>;
  EmployeeList1?: Observable<Employees[]>;
  employeeForm: any
  massage = "";
  prodCategory = "";
  EmployeeId = 0;
  constructor(private formbulider: FormBuilder,
     private EmployeeService: EmployeesService,private router: Router,
     private jwtHelper : JwtHelperService,private toastr: ToastrService) { }

  ngOnInit() {
    this.prodCategory = "0";
    this.employeeForm = this.formbulider.group({
      FirstName: ['', [Validators.required]],
      LastName: ['', [Validators.required]],
      PhoneNumber: ['', [Validators.required]],
      Email: ['', [Validators.required]],
      DateOfBirth: [null, [Validators.required]]
    });
    this.getEmployeeList();
  }
  getEmployeeList() {
    this.EmployeeList1 = this.EmployeeService.getEmployeeList();
    this.EmployeeList = this.EmployeeList1;
  }
  PostEmployee(Employee: Employees) {
    const Employee_Master = this.employeeForm.value;
    Employee_Master.DateOfBirth=new Date( Employee_Master.DateOfBirth);

    this.EmployeeService.postEmployeeData(Employee_Master).subscribe(
      () => {
        this.getEmployeeList();
        this.employeeForm.reset();
        this.toastr.success('Data Saved Successfully');
      }
    );
  }
  EmployeeDetailsToEdit(id: string) {
    debugger
    this.EmployeeService.getEmployeeDetailsById(id).subscribe(EmployeeResult => {
      this.EmployeeId = EmployeeResult.id;
      this.employeeForm.controls['FirstName'].setValue(EmployeeResult.firstName);
      this.employeeForm.controls['LastName'].setValue(EmployeeResult.lastName);
      this.employeeForm.controls['PhoneNumber'].setValue(EmployeeResult.phoneNumber);
      this.employeeForm.controls['Email'].setValue(EmployeeResult.email);
      this.employeeForm.controls['DateOfBirth'].setValue((EmployeeResult.dateOfBirth));
    });
  }
  UpdateEmployee(Employee: Employees) {
    Employee.id= this.EmployeeId;
    const Employee_Master = this.employeeForm.value;
    Employee_Master.DateOfBirth=new Date( Employee_Master.dateOfBirth);
    this.EmployeeService.updateEmployee(Employee_Master).subscribe(() => {
      this.toastr.success('Data Updated Successfully');
      this.employeeForm.reset();
      this.getEmployeeList();
    });
  }

  DeleteEmployee(id: number) {
    if (confirm('Do you want to delete this Employee?')) {
      this.EmployeeService.deleteEmployeeById(id).subscribe(() => {
        this.toastr.success('Data Deleted Successfully');
        this.getEmployeeList();
      });
    }
  }

  Clear(Employee: Employees){
    this.employeeForm.reset();
  }

  public logOut = () => {
    localStorage.removeItem("jwt");
    this.router.navigate(["/"]);
  }

  isUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }

}
