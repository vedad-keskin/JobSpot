import { AbstractControl, ValidatorFn, FormGroup } from '@angular/forms';

export function passwordsMatchValidator(): ValidatorFn {
  return (formGroup: AbstractControl): { [key: string]: boolean } | null => {
    const password = formGroup.get('password')?.value;
    const confirmPassword = formGroup.get('confirmPassword')?.value;

    return password === confirmPassword ? null : { passwordsMismatch: true };
  };
}
