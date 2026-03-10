import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { DxFormModule, DxButtonModule } from 'devextreme-angular';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, DxFormModule, DxButtonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loading = false;
  errorMessage = '';

  formData = {
    username: '',
    password: ''
  };

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  async onLogin() {
    this.loading = true;
    this.errorMessage = '';

    const success = await this.authService.login(
      this.formData.username,
      this.formData.password
    );

    this.loading = false;

    if (success) {
      this.router.navigate(['/personel']);
    } else {
      this.errorMessage = 'Kullanıcı adı veya şifre hatalı!';
    }
  }
}