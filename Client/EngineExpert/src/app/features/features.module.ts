import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CarsEditorComponent } from './components/cars-editor/cars-editor.component';
import { CarsComponent } from './cars/cars.component';
import { ClientsComponent } from './clients/clients.component';
import { RepairsComponent } from './repairs/repairs.component';
import { UsersComponent } from './components/users/users.component';



@NgModule({
  declarations: [
    DashboardComponent,
    CarsEditorComponent,
    CarsComponent,
    ClientsComponent,
    RepairsComponent,
    UsersComponent
  ],
  imports: [
    CommonModule
  ]
})
export class FeaturesModule { }
