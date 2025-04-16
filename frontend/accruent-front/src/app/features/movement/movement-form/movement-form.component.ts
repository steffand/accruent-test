import { Component } from '@angular/core';
import { Movement } from '../../../core/models/movement.model';
import { MovementService } from '../../../core/services/movement.service';

@Component({
  selector: 'app-movement-form',
  templateUrl: './movement-form.component.html',
  styleUrls: ['./movement-form.component.css'],
  standalone: false
})
export class MovementFormComponent {
  movement: Movement = {
    productCode: '',
    type: 'Inbound',
    quantity: 0
  };
  errorMessage: string = '';
  successMessage: string = '';
  isLoading: boolean = false;

  constructor(private movService: MovementService) {}

  onSubmit() {
    this.isLoading = true;
    this.movService.createMovement(this.movement).subscribe({
      next: () => {
        this.successMessage = 'Movimentação registrada com sucesso!';
        this.movement = { productCode: '', type: 'Inbound', quantity: 0 };
        this.errorMessage = '';
        this.isLoading = false;
      },
      error: (err) => {
        console.log(err);
        this.successMessage = '';
        this.errorMessage = err.error || 'Erro ao registrar movimentação';
        this.isLoading = false;
      }
    });
  }
}
