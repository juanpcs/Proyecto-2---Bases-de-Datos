import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nfood',
  templateUrl: './nfood.component.html',
  styleUrls: ['./nfood.component.css']
})
export class NfoodComponent implements OnInit {

  products: boolean[] = [false,true,false];
  displayProducts: boolean = true;
  plan: boolean = true;
  clients: boolean = false;
  constructor() { }

  ngOnInit(): void {
  }

  setAction(x:number){
    if (x == 0){
      this.displayProducts = true;
      this.plan = true;
      this.clients = false;
    }
    if (x == 1){
      this.displayProducts = false;
      this.plan = false;
      this.clients = true;
    }
    if (x == 2){
      this.displayProducts = false;
      this.plan = false;
    }
 
  }
  addProduct(){
    
  this.products= [true,false,true];
  }
}
