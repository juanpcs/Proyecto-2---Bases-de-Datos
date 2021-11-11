import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NutritecService {

  user:string = "";
  userAux: BehaviorSubject<string> = new BehaviorSubject(this.user);
  
  constructor() { }

  setUser(user:string){
    this.user = user;
    this.userAux.next(this.user);
    console.log(this.user)
  }
}
