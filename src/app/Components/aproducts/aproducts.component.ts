import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-aproducts',
  templateUrl: './aproducts.component.html',
  styleUrls: ['./aproducts.component.css']
})
export class AproductsComponent implements OnInit {
  
  products: boolean[] = [false,true,false,false,true,false,false,true,false,false,true,false,false,true,false,false,true,false];
  displayProducts: boolean = true;
  report: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  setAction(x:number){
    if (x == 0){
      this.displayProducts = true;
      this.report = false;
    }
    if (x == 1){
      this.displayProducts = false;
      this.report = true;
    }
  }

}
