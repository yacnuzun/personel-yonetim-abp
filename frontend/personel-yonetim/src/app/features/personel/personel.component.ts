import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DxDataGridModule, DxFormModule, DxChartModule, DxButtonModule, DxPopupModule } from 'devextreme-angular';
import { PersonelService, CreateUpdatePersonelDto } from '../../core/services/personel.service';
import { Router } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';

export interface Personel {
  id: string;
  name: string;
  surname: string;
  department: string;
  position: string;
  salary: number;
  hireDate: string;
  status: string;
}

@Component({
  selector: 'app-personel',
  standalone: true,
  imports: [
    CommonModule,
    DxDataGridModule,
    DxFormModule,
    DxChartModule,
    DxButtonModule,
    DxPopupModule
  ],
  templateUrl: './personel.component.html',
  styleUrl: './personel.component.css'
})
export class PersonelComponent implements OnInit {
  popupVisible = false;
  secilenPersonel: Partial<CreateUpdatePersonelDto> = {};
  secilenId: string = '';
  yeniKayitMi = false;
  personelListesi: Personel[] = [];

  constructor(private personelService: PersonelService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadPersoneller();
  }

  loadPersoneller() {
    this.personelService.getList().subscribe({
      next: (res: any) => {
        this.personelListesi = res.items;
      },
      error: (err) => console.error(err)
    });
  }

  get departmanVerisi() {
    const sayac: { [key: string]: number } = {};
    this.personelListesi.forEach(p => {
      sayac[p.department] = (sayac[p.department] || 0) + 1;
    });
    return Object.entries(sayac).map(([departman, sayi]) => ({ departman, sayi }));
  }

  get toplamPersonel() { return this.personelListesi.length; }
  get aktifPersonel() { return this.personelListesi.filter(p => p.status === 'Active').length; }
  get ortalamaMailas() {
    if (!this.personelListesi.length) return '0';
    const ort = this.personelListesi.reduce((t, p) => t + p.salary, 0) / this.personelListesi.length;
    return Math.round(ort).toLocaleString('tr-TR');
  }

  yeniPersonelEkle() {
    this.yeniKayitMi = true;
    this.secilenPersonel = { status: 'Active', hireDate: new Date().toISOString().split('T')[0] };
    this.popupVisible = true;
  }

  personelDuzenle(e: any) {
    this.yeniKayitMi = false;
    this.secilenId = e.data.id;
    this.secilenPersonel = {
      name: e.data.name,
      surname: e.data.surname,
      department: e.data.department,
      position: e.data.position,
      salary: e.data.salary,
      hireDate: e.data.hireDate,
      status: e.data.status
    };
    this.popupVisible = true;
  }

  kaydet() {
    if (this.yeniKayitMi) {
      this.personelService.create(this.secilenPersonel as CreateUpdatePersonelDto).subscribe({
        next: () => {
          this.loadPersoneller();
          this.popupVisible = false;
        },
        error: (err) => console.error(err)
      });
    } else {
      this.personelService.update(this.secilenId, this.secilenPersonel as CreateUpdatePersonelDto).subscribe({
        next: () => {
          this.loadPersoneller();
          this.popupVisible = false;
        },
        error: (err) => console.error(err)
      });
    }
  }

  personelSil(e: any) {
    this.personelService.delete(e.data.id).subscribe({
      next: () => this.loadPersoneller(),
      error: (err) => console.error(err)
    });
  }

  iptal() {
    this.popupVisible = false;
  }
  logout() {
  this.authService.logout();
  this.router.navigate(['/login']);
}
  departmanlar = ['Yazilim', 'IK', 'Muhasebe', 'Pazarlama', 'Operasyon'];
  durumlar = ['Active', 'OnLeave', 'Passive'];
}