import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { RouterModule } from '@angular/router';
import { MovementFormComponent } from './movement-form/movement-form.component';


@NgModule({
  declarations: [MovementFormComponent],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  exports: [MovementFormComponent]
})
export class MovementModule {}