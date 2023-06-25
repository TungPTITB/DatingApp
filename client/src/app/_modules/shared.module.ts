import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { MatTabsModule } from '@angular/material/tabs';
import { NgxGalleryModule } from 'ngx-gallery';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NgbDropdownModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    MatTabsModule,
    
  ],
  exports: [
    NgbDropdownModule,
    ToastrModule,
    MatTabsModule
  ]
})
export class SharedModule { }
