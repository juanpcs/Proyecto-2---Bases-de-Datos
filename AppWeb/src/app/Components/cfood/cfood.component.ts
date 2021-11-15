import { Component, OnInit } from '@angular/core';
import { AgregarMedidasService, IMedidas } from "./agregar-medidas.service";
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AgregarProductoService, IProducto } from './agregar-producto.service';

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

  // Injectar el Form Builder, que permite construir el modelo que representa los campos del formulario
  constructor(private fb: FormBuilder,
    private agregarMedidasService : AgregarMedidasService,
    private agregarProductoService : AgregarProductoService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {}


  medidasId: string;
  public id: number = 2;
  // Modelo del formulario de Medidas
  medidasGroup = new FormGroup({
    CCorreo_electronico: new FormControl('MrMercedes@gmail.com'),
    Fecha: new FormControl('', [Validators.required]),
    Caderas: new FormControl('', [Validators.required]),
    Cintura: new FormControl('', [Validators.required]),
    Cuello: new FormControl('', [Validators.required]),
    Musculo: new FormControl('', [Validators.required]),
    Grasa: new FormControl('', [Validators.required])
  });

  get med(){

    return this.medidasGroup.controls;

  }

  // Modelo del formulario de Medidas
  productoGroup = new FormGroup({
    Nombre: new FormControl('', [Validators.required]),
    Codigo_barras: new FormControl('', [Validators.required]),
    Estado: new FormControl('En Espera'),
    Descripcion: new FormControl('', [Validators.required]),
    Porcion: new FormControl('', [Validators.required]),
    Energia: new FormControl('', [Validators.required]),
    Grasa: new FormControl('', [Validators.required]),
    Sodio: new FormControl('', [Validators.required]),
    Carbohidratos: new FormControl('', [Validators.required]),
    Proteina: new FormControl('', [Validators.required]),
    Calcio: new FormControl('', [Validators.required]),
    Hierro: new FormControl('', [Validators.required]),
    Vitaminas: new FormControl('', [Validators.required]),
    ACorreo_electronico: new FormControl('admin99@gmail.com')
  });

  get prod(){

    return this.productoGroup.controls;

  }
  
  ngOnInit() {

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }
    
    });

  }

  saveMedidas() {
    // Se crea un objeto de tipo IMedidas a partir del valor del formulario
    let medidas : IMedidas = Object.assign({}, this.medidasGroup.value);
    console.table(medidas);


    this.agregarMedidasService.createMedida(medidas)
      .subscribe(medidas => this.onSaveMedidas(),
              error => console.error(error));  
  }

  // Metodo que retorna al usuario a la ventana de visualizacion de medidass una vez se agrega un componente nuevo
  onSaveMedidas() {
    this.medidasGroup.reset();
  } 


  ////////////////

  saveProducto() {
    // Se crea un objeto de tipo IProducto a partir del valor del formulario
    let producto : IProducto = Object.assign({}, this.productoGroup.value);
    console.table(producto);


    this.agregarProductoService.createProducto(producto)
      .subscribe(producto => this.onSaveProducto(),
              error => console.error(error));  
  }

  // Metodo que retorna al usuario a la ventana de visualizacion de productos una vez se agrega un componente nuevo
  onSaveProducto() {
    this.productoGroup.reset();
  } 

  ////////////////

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
