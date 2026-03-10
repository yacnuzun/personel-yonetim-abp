import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

export interface CreateUpdatePersonelDto {
  name: string;
  surname: string;
  department: string;
  position: string;
  salary: number;
  hireDate: string;
  status: string;
}

@Injectable({ providedIn: 'root' })
export class PersonelService {
  constructor(private http: HttpClient) {}

  getList() {
    return this.http.get(`${environment.apiUrl}/api/app/personel`);
  }

  create(dto: CreateUpdatePersonelDto) {
    return this.http.post(`${environment.apiUrl}/api/app/personel`, dto);
  }

  update(id: string, dto: CreateUpdatePersonelDto) {
    return this.http.put(`${environment.apiUrl}/api/app/personel/${id}`, dto);
  }

  delete(id: string) {
    return this.http.delete(`${environment.apiUrl}/api/app/personel/${id}`);
  }
}