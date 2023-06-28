import { Injectable } from '@angular/core';
import { CanDeactivateFn } from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';
import { map, of } from 'rxjs';

export const preventUnsavedChangesGuard: CanDeactivateFn<MemberEditComponent> = (component, currentRoute, currentState, nextState) => {
  if (component.editForm?.dirty) {
    return component['confirmService'].confirm().pipe(
      map((result) => {
        if(result){
          return true; // Cho phép rời khỏi trang
        }else{
          return false; // Không cho phép rời khỏi trang
        }
      })
    )
  }
  return of(true); // Cho phép rời khỏi trang
}
