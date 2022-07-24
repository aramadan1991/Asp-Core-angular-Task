import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Employees } from '../Models/Employees';
import configurl from '../../assets/config/config.json'

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  url = configurl.apiServer.url + '/api/Employees/';
  constructor(private http: HttpClient) { }
  getEmployeeList(): Observable<Employees[]> {
    return this.http.get<Employees[]>(this.url + 'GetEmployees').pipe(map((resp:any) => resp.data));
  }
  postEmployeeData(EmployeeData: Employees): Observable<Employees> {
    const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    return this.http.post<Employees>(this.url + 'CreateEmployee', EmployeeData, httpHeaders).pipe(map((resp:any) => resp.data));
  }
  updateEmployee(Employee: Employees): Observable<Employees> {
    const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    return this.http.post<Employees>(this.url + 'GetEmployee?id=' + Employee.id, Employee, httpHeaders).pipe(map((resp:any) => resp.data));
  }
  deleteEmployeeById(id: number): Observable<number> {
    return this.http.delete<number>(this.url + 'DeleteEmployee/' + id).pipe(map((resp:any) => resp.data));
  }
  getEmployeeDetailsById(id: string): Observable<Employees> {
    return this.http.get<Employees>(this.url + 'GetEmployee/' + id).pipe(map((resp:any) => resp.data));
  }
}
