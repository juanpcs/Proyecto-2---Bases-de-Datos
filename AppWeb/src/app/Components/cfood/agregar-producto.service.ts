import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders }    from '@angular/common/http';  
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

export interface IProducto {
  Nombre: number;
  Codigo_barras: string;
  Estado: string;
  Descripcion: number;
  Porcion: number;
  Energia: number;
  Grasa: number;
  Sodio: string;
  Carbohidratos: Date;
  Proteina: number;
  Calcio: number;
  Hierro: number;
  Vitaminas: string;
  ACorreo_electronico: string;
}

@Injectable({
  providedIn: 'root'
})
export class AgregarProductoService {

  constructor(private http: HttpClient) { }  

  url : string = "https://localhost:5001/api/";

  // Metodo que invoca el metodo GET ALL
  getProducto(): Observable<IProducto[]> {
    return this.http.get<IProducto[]>(this.url + "Producto");
  }

  // Metodo para crear una cliente proveniente de la web
  createProducto(producto: IProducto): Observable<IProducto> {
    return this.http.post<IProducto>(this.url + "Producto", producto);
  }
    
    
} 