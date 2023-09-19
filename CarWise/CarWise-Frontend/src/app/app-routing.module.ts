import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarListComponent } from './Car/Components/car-list/car-list.component';
import { UserLoginComponent } from './User/Components/user-login/user-login.component';
import { UserRegistrationComponent } from './User/Components/user-registration/user-registration.component';
import { CarDetailsComponent } from './Car/Components/car-details/car-details.component';
import { AppComponent } from './app.component';
import { HomeComponent } from './Core/Components/home/home.component';

const routes: Routes = [
  {
    path: 'cars',
    component: CarListComponent
  },
  {
    path: 'car/:id',
    component: CarDetailsComponent
  },
  {
    path: 'user/login',
    component: UserLoginComponent
  },
  {
    path: 'user/register',
    component: UserRegistrationComponent
  },
  {
    path: '',
    component: HomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
