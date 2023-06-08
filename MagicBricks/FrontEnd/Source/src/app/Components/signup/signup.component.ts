import { Component, OnInit } from '@angular/core';
import { CrudserviceService } from '../../Services/crudservice.service';
import Country from '../../Models/country';
import ApplicationObjectType from '../../Models/ApplicationObjectType';
import User from '../../Models/User';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  countries2!: Country[]
  pageOfItems!: Country[];
  route: any;
  submitted: boolean = false;
  constructor(
    private crud: CrudserviceService,
    private fb: FormBuilder,
    private router: Router
  ) { }
  agreeterms: boolean = false;
  UserTypes!: ApplicationObjectType[]
  countries!: Country[];
  ngOnInit(): void {
    this.countries2 = this.countries
    this.GetAllCountries();
    this.GetUserTypes();
  }
  SignupForm = this.fb.group({
    UserTypeId: [0, Validators.required],
    Name: ['', Validators.required],
    Email: ['', [Validators.required, Validators.email, Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')]],
    DateReg: [],
    PhoneNo: ['', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]],
    Otpno: [''],
    Password: ['', [Validators.required, Validators.minLength(6),
    Validators.pattern('(?=.*[A-Za-z])(?=.*[0-9])(?=.*[$@$!#^~%*?&,.<>"\'\\;:\{\\\}\\\[\\\]\\\|\\\+\\\-\\\=\\\_\\\)\\\(\\\)\\\`\\\/\\\\\\]])[A-Za-z0-9\d$@].{7,}')]],
    Property: []
  });
  get f() { return this.SignupForm.controls; }
  UserData!: User;
  ref: boolean = false;
  msg: boolean = false;
  private GetAllCountries() {
    this.crud.getAll().subscribe(data => {
    });
  }
  private GetUserTypes() {
    this.crud.getAllAppObjTypes().subscribe(data => {
      this.UserTypes = data.filter(x => x.appObjid == 7);
    });
  }

  PostUser() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.SignupForm.invalid) {
      return;
    }
    this.crud.PostUser(this.SignupForm.value).subscribe(data => {
      console.log(data);
    });
    this.ref = true;
  }
  sendotp() {
    this.crud.Otpverify({ email: this.SignupForm.value.Email, otp: this.SignupForm.value.Otpno }).subscribe(arg => {
      if(arg!=null||arg!=0){
        localStorage.setItem("id", arg);
        this.router.navigate(['/dashboard']);
        console.log(arg);
        this.msg = !this.msg;
      }
     
    })
    
  }
  onChangePage(pageOfItems: Array<any>) {
    // update current page of items
    this.pageOfItems = pageOfItems;
  }
}
