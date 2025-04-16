import { Component } from '@angular/core';
import { ReportService } from '../../../core/services/report.service';

@Component({
  selector: 'app-report-list',
  templateUrl: './report-list.component.html',
  styleUrls:['./report-list.component.css'],
  standalone: false
})
export class ReportListComponent {
  filters = {
    movementDate: '',
    productCode: ''
  };

  reportData: Report[] = [];
  report = {
    movementDate: '',
    productCode: ''
  };
  errorMessage:string = '';
  warningMessage:string = '';
  isLoading: boolean = false;

  constructor(private relatorioService: ReportService) {}

  onSubmit(){
    if (!this.filters.movementDate) return;

    this.isLoading = true;
    this.relatorioService.getReport(this.filters.movementDate, this.filters.productCode).subscribe({
      next: (dados: any) => {
        this.reportData = dados;
        this.errorMessage = '';
        this.warningMessage = '';
        if(this.reportData.length == 0)
        {
          this.warningMessage = 'Nenhuma movimentação encontrada';
        }
        this.isLoading = false;
      },
      error: (err) => {
        this.errorMessage = err.error?.message || 'Erro ao buscar relatório';
        this.warningMessage = '';
        this.reportData = [];
        this.isLoading = false;
      }
    });
  }
}
