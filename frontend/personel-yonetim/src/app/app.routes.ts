import { Routes } from '@angular/router';
import { LoginComponent } from './features/login/login.component';
import { PersonelComponent } from './features/personel/personel.component';
import { authGuard } from './core/auth.guard';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'personel', component: PersonelComponent, canActivate: [authGuard] },
  { path: '', redirectTo: 'personel', pathMatch: 'full' },
  { path: '**', redirectTo: 'login' }
];