import { Component, OnInit } from '@angular/core';
import { NutritecService } from 'src/app/nutritec.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  user: string = "";
  registerOn: boolean = true;
  route: string = ""

  constructor(private service:NutritecService) { }

  ngOnInit(): void {
    this.service.userAux.subscribe(u=>{this.user = u})
    if (this.user == "Nutritionist"){
      this.route = ""
    }
    if (this.user == "Client"){
      this.route = "/register"
    }
  }

  getMeasures(){
    this.registerOn = false;
    this.route = ""
  }


}
