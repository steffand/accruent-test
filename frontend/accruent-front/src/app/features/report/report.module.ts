import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReportListComponent } from './report-list/report-list.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [ReportListComponent],
  imports: [CommonModule, FormsModule, RouterModule],
  exports: [ReportListComponent]
})
export class ReportModule {}
