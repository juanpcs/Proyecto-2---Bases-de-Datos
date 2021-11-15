import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders }    from '@angular/common/http';  
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

export interface IMedidas {
  CCorreo_electronico: string;
  Fecha: Date;
  Cintura: number;
  Cuello: number;
  Caderas: number;
  Musculo: number;
  Grasa: number;
}

@Injectable({
  providedIn: 'root'
})
export class AgregarMedidasService {

  constructor(private http: HttpClient) { }  

  url : string = "https://localhost:5001/api/";

  // Metodo que invoca el metodo GET ALL
  getMedidas(): Observable<IMedidas[]> {
    return this.http.get<IMedidas[]>(this.url + "Medidas");
  }

  // Metodo para crear una cliente proveniente de la web
  createMedida(medidas: IMedidas): Observable<IMedidas> {
    return this.http.post<IMedidas>(this.url + "Medidas", medidas);
  }
    
    
} 