import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarListComponent } from './Car/Components/car-list/car-list.component';
import { UserLoginComponent } from './User/Components/user-login/user-login.component';
import { RegistrationComponent } from './registration/registration.component';

const routes: Routes = [
  {
    path: 'car',
    component: CarListComponent
  },
  { path: 'registration', 
    component: RegistrationComponent
  },
  {
    path: 'user/login',
    component: UserLoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
