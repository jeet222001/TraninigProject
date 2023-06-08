import { Component, OnInit } from '@angular/core';
import { CrudserviceService } from '../../Services/crudservice.service';
import Cities from '../../Models/Cities';
import { Router } from '@angular/router';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent implements OnInit {

  constructor(
    private crud: CrudserviceService,
    private router:Router
    ) { }
  Cities!: Cities[];
  isLoggedIn:boolean=false;

  
  ngOnInit(): void {
    this.GetCities();
    this.Loggedin()
  }

Loggedin(){
  if(localStorage.getItem("id")!=null){
    this.isLoggedIn=!this.isLoggedIn;
  }
}
  private GetCities() {
    this.crud.getAllCities().subscribe(data => {
      this.Cities = data;
    });
  }
  Logout(){
    this.isLoggedIn=!this.isLoggedIn;
    this.router.navigate(['/home']);
    localStorage.removeItem("id");
    window.alert("You have logged out");
  }
}
