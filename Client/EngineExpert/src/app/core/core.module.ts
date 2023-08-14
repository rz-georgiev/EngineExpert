import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './components/login/login.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';



@NgModule({
  declarations: [
    RegisterComponent,
    LoginComponent,
    NavbarComponent,
    UserProfileComponent
  ],
  imports: [
    CommonModule
  ]
})
export class CoreModule { }
