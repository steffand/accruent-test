import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Movement } from '../models/movement.model';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class MovementService {
  private baseUrl = `${environment.apiUrl}/Movement`;

  constructor(private http: HttpClient) {}

  createMovement(mov: Movement) {
    return this.http.post(this.baseUrl, mov);
  }
}
