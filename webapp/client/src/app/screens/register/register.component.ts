import { Component } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { AxiosService } from 'src/app/services/axios.service';
import { ApiResponse } from 'src/app/services/response.interface';
import { passwordsMatchValidator } from 'src/app/utils/compareValidator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  registerForm: FormGroup;
  error?: string;
  isLoading: boolean = false;

  constructor(
    private fb: FormBuilder,
    private axiosService: AxiosService,
    private router: Router
  ) {
    this.registerForm = this.fb.group(
      {
        firstName: ['', []],
        lastName: ['', []],
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(8)]],
        confirmPassword: ['', [Validators.required, Validators.minLength(8)]],
      },
      { validators: passwordsMatchValidator() }
    );
  }

  ngOnInit() {
    this.registerForm.valueChanges.subscribe(() => {
      this.error = undefined;
      this.registerForm.markAsUntouched();
    });
  }

  async onSubmit() {
    this.isLoading = true;
    if (this.registerForm.valid) {
      const { firstName, lastName, email, password, confirmPassword } =
        this.registerForm.value;
      const res: ApiResponse = await this.axiosService.post('/user/register', {
        firstName,
        lastName,
        email,
        password,
        confirmPassword,
      });
      if (res.success && res.token) {
        localStorage.setItem('token', res.token);
        this.router.navigate(['/']);
      } else {
        this.error = res.message;
      }
    } else {
      console.log(
        this.registerForm.get('email')?.errors,
        this.registerForm.get('password')?.errors
      );
    }
    this.isLoading = false;
  }
  isInvalid(field: 'email' | 'password' | 'confirmPassword', error: string) {
    return (
      this.registerForm.touched && this.registerForm.get(field)?.errors?.[error]
    );
  }
}
