import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CrudserviceService } from 'src/app/Services/crudservice.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {

  constructor(private router:Router,private crud:CrudserviceService) { }
id=localStorage.getItem("id");
user!:any;
  ngOnInit(): void {
    if (this.id === null) this.router.navigate(['/login']);
    this.GetUser(Number(this.id));
  }

  private GetUser(id:number){
    this.crud.GetUser(id).subscribe(data=>{
      this.user=data;
      console.log(this.user);
      console.log(this.id);
    })
  }
}
