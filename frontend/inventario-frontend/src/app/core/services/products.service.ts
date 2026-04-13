import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private apiUrl = 'https://localhost:7025/productos';

  constructor(private http: HttpClient) {}

  getInventory(): Observable<any> {
    return this.http.get(`${this.apiUrl}/inventario`);
  }

  registerMovement(data: any) {
    return this.http.post(`${this.apiUrl}/movimiento`, data);
  }
}