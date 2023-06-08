import { Injectable, Type } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import Country from '../Models/country';
import Cities from '../Models/Cities';
import { environment } from 'src/environments/environment';
import ApplicationObjectType from '../Models/ApplicationObjectType';
import Login from '../Models/Login';
import User from '../Models/User';
import { json } from 'express';
import PropertyDetail from '../Models/PropertyDetails';


@Injectable({
  providedIn: 'root'
})
export class CrudserviceService {

  constructor(private httpClient: HttpClient) {}

  getAll(): Observable<Country[]> {
    return this.httpClient.get<Country[]>(`${environment.apiURL}/${environment.endpoints}`, environment.httpOptions);
  }
  getAllCities(): Observable<Cities[]> {
    return this.httpClient.get<Cities[]>(`${environment.apiURL}/${environment.CityendPoint}`, environment.httpOptions);
  }
  getAllAppObjTypes(): Observable<ApplicationObjectType[]> {
    return this.httpClient.get<ApplicationObjectType[]>(`${environment.apiURL}/${environment.AppobjType}`, environment.httpOptions);
  }

  PostUser(user: any){
    return this.httpClient.post<any>(`${environment.apiURL}/${environment.AddUser}`, JSON.stringify(user), environment.httpOptions);
  }
  Otpverify(user: any){
    return this.httpClient.post<any>(`${environment.apiURL}/${environment.otpVerify}`, JSON.stringify(user), environment.httpOptions);
  }
  Login(model: any){
    return this.httpClient.post<any>(`${environment.apiURL}/${environment.Login}`, model, environment.httpOptions);
  }

  GetUser(id:number):Observable<User>{
    return this.httpClient.get<User>(`${environment.apiURL}/${environment.AddUser}/${id}`,environment.httpOptions);
  }
  PostProperty(model:any){
    return this.httpClient.post<any>(`${environment.apiURL}/${environment.Property}`,model,environment.httpOptions);
  }
  GetProperties(){
    return this.httpClient.get(`${environment.apiURL}/${environment.Property}`,environment.httpOptions);
  }
  GetPropertiesDetails():Observable<any>{
    return this.httpClient.get<any>(`${environment.apiURL}/${environment.PropertyDetails}`,environment.httpOptions);
  }
 ContactOwner(model:any){
  return this.httpClient.post<any>(`${environment.apiURL}/${environment.ContactOwner}`,model,environment.httpOptions)
 }
}