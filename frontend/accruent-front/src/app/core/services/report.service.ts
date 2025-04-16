import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class ReportService {
  private baseUrl = `${environment.apiUrl}/Report`;

  constructor(private http: HttpClient) {}

  getReport(movementDate: string, productCode?: string) {
    let params = new HttpParams().set('movementDate', movementDate);
    if (productCode) {
      params = params.set('productCode', productCode);
    }
    return this.http.get(this.baseUrl, { params });
  }
}
