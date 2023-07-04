import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { NgbDatepickerModule, NgbDropdownModule, NgbPagination } from '@ng-bootstrap/ng-bootstrap';
import { MatTabsModule } from '@angular/material/tabs';
import { FileUploadModule } from 'ng2-file-upload';
import { MatNativeDateModule } from '@angular/material/core';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { TimeagoModule } from 'ngx-timeago';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NgbDropdownModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    MatTabsModule,
    FileUploadModule,
    NgxGalleryModule,
    BsDatepickerModule.forRoot(),
    PaginationModule.forRoot(),
    TimeagoModule.forRoot()
    
    
  ],
  exports: [
    NgbDropdownModule,
    ToastrModule,
    MatTabsModule,
    FileUploadModule,
    PaginationModule,
    BsDatepickerModule,
    NgxGalleryModule,
    TimeagoModule

  ]
})
export class SharedModule { }
