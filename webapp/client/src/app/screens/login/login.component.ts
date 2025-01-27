import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AxiosService } from 'src/app/services/axios.service';
import { ApiResponse } from 'src/app/services/response.interface';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  loginForm: FormGroup;
  error?: string;
  showErrors: boolean = false;
  isLoading: boolean = false;
  constructor(
    private fb: FormBuilder,
    private axiosService: AxiosService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
    });
  }

  ngOnInit() {
    this.loginForm.valueChanges.subscribe(() => {
      this.error = undefined;
      this.loginForm.markAsUntouched();
      this.showErrors = false;
    });
  }
  async onSubmit() {
    this.isLoading = true;
    this.showErrors = true;
    if (this.loginForm.valid) {
      const { email, password } = this.loginForm.value;
      const res: ApiResponse = await this.axiosService.post('/user/login', {
        email,
        password,
      });
      if (res.success && res.token) {
        localStorage.setItem('token', res.token);
        this.router.navigate(['/']);
      } else {
        this.error = res.message;
      }
    } else {
      console.log(
        this.loginForm.get('email')?.errors,
        this.loginForm.get('password')?.errors
      );
    }
    this.isLoading = false;
  }
  isInvalid(field: 'email' | 'password', error: string) {
    return this.loginForm.touched && this.loginForm.get(field)?.errors?.[error];
  }
}
