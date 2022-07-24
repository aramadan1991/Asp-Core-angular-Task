import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeesComponent } from './employees.component';
import { AuthGuard } from '../guards/auth-guard.service';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

const routes: Routes = [

  
    { path: '', component: EmployeesComponent ,
    canActivate: [AuthGuard] 
  },
  
];

@NgModule({
  declarations: [EmployeesComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    
    FormsModule,
    ReactiveFormsModule
  ]
})
export class EmployeesModule { }
