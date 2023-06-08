import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import PropertyDetail from 'src/app/Models/PropertyDetails';
import { CrudserviceService } from 'src/app/Services/crudservice.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  Properties!: any;
  showShortDesciption = true
  constructor(private router: Router,
    private crud: CrudserviceService
  ) { }
  path=environment.path;
  id=localStorage.getItem("id");
  ngOnInit(): void {
    this.GetProperties();
if (this.id === null) this.router.navigate(['/login']);
  }

  alterDescriptionText() {
     this.showShortDesciption = !this.showShortDesciption
  }
  Logout() {
    localStorage.removeItem("id");
    this.router.navigate(['/home']);
    window.alert("You have logged out");
  }
  private GetProperties() {
    this.crud.GetPropertiesDetails().subscribe(data => {
      this.Properties = data.filter((x:any) => x.userId==Number(this.id))
      console.log(this.Properties);
    })
  }
}
