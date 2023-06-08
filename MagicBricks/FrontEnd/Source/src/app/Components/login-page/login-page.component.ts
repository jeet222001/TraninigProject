import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import ApplicationObjectType from 'src/app/Models/ApplicationObjectType';
import Country from 'src/app/Models/country';
import Login from 'src/app/Models/Login';
import User from 'src/app/Models/User';
import { CrudserviceService } from 'src/app/Services/crudservice.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  constructor(
    private crud: CrudserviceService,
    private fb: FormBuilder,
    private router: Router
  ) { }
  login!: Login;
  agreeterms: boolean = false;
  UserTypes!: ApplicationObjectType[]
  countries!: Country[];
  ngOnInit(): void {

  }
  LoginForm = this.fb.group({
    EmailOrPhone: ['', [Validators.required]],
    pswd: ['', Validators.required],
  });

  Login() {
    if (this.LoginForm.controls.EmailOrPhone != null && this.LoginForm.controls.pswd != null) {
      console.log(this.LoginForm.value);
      this.crud.Login(this.LoginForm.value).subscribe(data => {
        localStorage.setItem("id", data);
        window.alert("you have logged in successfully");
        this.router.navigate(['/dashboard']).then(()=>{
          window.location.reload();
        });
      },
        error => {
          console.log(error);
        });
    }
  }
}

