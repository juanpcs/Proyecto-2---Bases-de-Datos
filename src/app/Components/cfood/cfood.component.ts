import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cfood',
  templateUrl: './cfood.component.html',
  styleUrls: ['./cfood.component.css']
})
export class CfoodComponent implements OnInit {

  products: boolean[] = [false,true,false];
  displayProducts: boolean = true;
  recipe: boolean = true;
  register: boolean = false;
  measures: boolean = false;
  report: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  setAction(x:number){
    if (x == 0){
      this.displayProducts = true;
      this.recipe = true;
      this.register = false;
      this.measures = false;
      this.report = false;
    }
    if (x == 1){
      this.displayProducts = true;
      this.recipe = false;
      this.register = true;
      this.measures = false;
      this.report = false;
    }
    if (x == 2){
      this.displayProducts = false;
      this.recipe = false;
      this.register = false;
      this.measures = true;
      this.report = false;
    }
    if (x == 3){
      this.displayProducts = false;
      this.recipe = false;
      this.register = false;
      this.measures = false;
      this.report = true;
    }
  }
  addProduct(){
    
  this.products= [true,false,true];
  }
}
