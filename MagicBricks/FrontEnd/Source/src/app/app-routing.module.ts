import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { HomeComponent } from './Components/home/home.component';
import { LoginPageComponent } from './Components/login-page/login-page.component';
import { MyProfileComponent } from './Components/my-profile/my-profile.component';
import { PostPropertyComponent } from './Components/post-property/post-property.component';
import { PropertyDetailsComponent } from './Components/property-details/property-details.component';
import { PropertyListComponent } from './Components/property-list/property-list.component';
import { SignupComponent } from './Components/signup/signup.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'postproperty', component: PostPropertyComponent },
  {path:'login',component:LoginPageComponent},
  {path:'dashboard',component:DashboardComponent},
  {path:'propertyDetails',component:PropertyListComponent},
  {path:'propertylist/:id',component:PropertyListComponent},
  {path:'myprofile',component:MyProfileComponent},
  {path:'propertydetails/:id',component:PropertyDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
