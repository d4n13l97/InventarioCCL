import { Routes } from '@angular/router';
import { LoginComponent } from './features/auth/login/login.component';
import { InventoryComponent } from './features/products/inventory/inventory.component';
import { MovementComponent } from './features/products/movement/movement.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'inventory', component: InventoryComponent },
  { path: 'movement', component: MovementComponent }
];