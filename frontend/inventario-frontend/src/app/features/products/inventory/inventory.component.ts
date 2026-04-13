import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsService } from '../../../core/services/products.service'
import { FormsModule } from '@angular/forms';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-inventory',
  standalone: true,
  imports: [CommonModule, FormsModule], // 👈 MUY IMPORTANTE
  templateUrl: './inventory.component.html'
})
export class InventoryComponent implements OnInit {

  selectedProductId: number = 0;
  quantity: number = 0;
  type: string = 'entrada';
  products: any[] = [];

  constructor(
    private productsService: ProductsService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    console.log('init inventory'); 
    this.loadInventory();
  }
  
  registerMovement() {
    const data = {
      productId: this.selectedProductId,
      quantity: this.quantity,
      type: this.type
    };

    this.productsService.registerMovement(data).subscribe({
      next: () => {
        alert('Movimiento registrado');
        this.loadInventory(); // recargar
      },
      error: (err: any) => {
        console.error(err);
      }
    });
  }

  loadInventory() {
    this.productsService.getInventory().subscribe({
      next: (res: any) => {
        console.log('inventario cargado', res);
        this.products = res;
        this.cdr.detectChanges(); // 💣 SOLUCIÓN
      },
      error: (err: any) => {
        console.error(err);
      }
    });
  }

}