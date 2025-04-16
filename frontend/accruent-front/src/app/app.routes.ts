import { Routes } from '@angular/router';
import { MovementFormComponent } from './features/movement/movement-form/movement-form.component';
import { ReportListComponent } from './features/report/report-list/report-list.component';

export const routes: Routes = [
  { path: 'movements', component: MovementFormComponent },
  { path: 'report', component: ReportListComponent },
  { path: '', redirectTo: '/movements', pathMatch: 'full' },
  { path: '**', redirectTo: '/movements' }
];