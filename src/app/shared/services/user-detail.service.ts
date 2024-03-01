import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { UserDetails } from '../models/user-details.models';
import { ResolveEnd } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserDetailService {

  url:string = environment.baseApiURL + '/moni' ;
  userName :  string = 'Sign In';
  userData : string = '';
  value !: string;
  constructor(private http: HttpClient){}

  async VerifyIdentity(EmailOrId: string , value: string, password: string ) : Promise<string | null>{
    return new Promise<string | null>((resolve,reject) =>{
      this.http.get<string>(`${this.url}/${EmailOrId}/${value}/${password}`).subscribe(
        (data)=>{
          resolve(data);
        },
        (error)=>{
          reject(error);
        }
      )
    });
  }

  async VerifyNumber(EmailOrId: string , value: string): Promise<string>{
    return new Promise<string> ((resolve, reject) =>{
      this.http.get<string>(`${this.url}/${EmailOrId}/${value}`).subscribe(
        (data)=>{
          resolve(data);
        },
        (error) =>{
          reject(error);
        }
      )
    })
  }

  async changePass(userData: string , passwordData: string): Promise<any |null>{
    const body = [
      {
      operationType: 0,
      path: "/Password",
      op: "replace",
      value: passwordData
    }
  ];
    return new Promise<any | null>((resolve,reject) =>{
      this.http.patch<any>(`${this.url}/${userData}/${this.value}`,body).subscribe(
        (data) =>{
          resolve(data);
        },
        (error)=>{
          reject(error);
        }
      )
    })
  }
}
