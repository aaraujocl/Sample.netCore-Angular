import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../../service/login.service';
import { StorageserviceService } from '../../service/storageservice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  formuser: FormGroup = new FormGroup({});
  loading = false;

  constructor(
    private router: Router,
    private formbuilder: FormBuilder,
    private storageService: StorageserviceService,
    private loginService: LoginService
  ) {
    this.buildForm();
  }

  ngOnInit(): void {}

  private buildForm() {
    this.formuser = this.formbuilder.group({
      username: [
        '',
        [Validators.required, Validators.pattern('^([^\\s]|\\s[^\\s])+$')],
      ],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(24),
        ],
      ],
    });
  }

  login() {
    const controls = this.formuser.controls;
    Object.keys(controls).forEach((controlName) => {
      controls[controlName].markAsTouched();
    });

    // stop here if form is invalid
    if (this.formuser.invalid) {
      return;
    }

    this.loading = true;
    const value = this.formuser.value;
    this.loginService.login(value.username, value.password).subscribe({
      next: (response) => {
        this.storageService.setCurrentSession(response);
        this.router.navigate(['main/dashboard']);
        this.loading = false;
      },
      error: (error) => {
        this.loading = false;
        if (error.status === 404) {
          alert('Usuario o Contraseña incorrectos ');
        }
      },
    });
  }

  get username() {
    return this.formuser.get('username');
  }

  get password() {
    return this.formuser.get('password');
  }
}
