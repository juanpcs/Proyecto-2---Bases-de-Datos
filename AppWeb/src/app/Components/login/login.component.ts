import { Component, OnInit } from '@angular/core';
import { NutritecService } from 'src/app/nutritec.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  route: string = "";
  user: string = "";

  constructor(private service:NutritecService) { }


  ngOnInit(): void {
  }
    
  setUser(type:number){
    if (type == 0){
      this.route = "/nutritionist";
      this.user = "Nutritionist"
      this.service.setUser(this.user)
    }
    if (type == 1){
      this.route = "/client";
      this.user = "Client"
      this.service.setUser(this.user)
    }
  };

}
