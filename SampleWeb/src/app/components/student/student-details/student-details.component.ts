import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from '../../service/student.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css'],
})
export class StudentDetailsComponent implements OnInit {
  registrationForm!: FormGroup;
  isNew: boolean = true;
  id = 0;
  typemessage: string = '';
  showmessage: boolean = false;
  patternombreydescripcion =
    /^[a-zA-Z\u00C0-\u00FF\s\-0-9\.\,\#\%\$\-\_\*\/\&\"\°\¡\!\(\)]*$/;

  constructor(
    private studentService: StudentService,
    private formbuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {
    if (this.route.snapshot.params['id']) {
      // Get the Category Id
      this.id = this.route.snapshot.params['id'];
      if (this.id > 0) this.isNew = false;
    }
  }

  ngOnInit(): void {
    this.initForm();
    this.detail();
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.registrationForm.controls;
  }

  initForm() {
    this.registrationForm = this.formbuilder.group({
      userName: [
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(20),
          Validators.pattern(this.patternombreydescripcion),
        ]),
      ],
      firstName: [
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(20),
          Validators.pattern(this.patternombreydescripcion),
        ]),
      ],
      lastName: [
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(20),
          Validators.pattern(this.patternombreydescripcion),
        ]),
      ],
      career: [
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(50),
          Validators.pattern(this.patternombreydescripcion),
        ]),
      ],
      age: ['', Validators.compose([Validators.required])],
    });
  }

  detail() {
    if (this.id > 0) {
      this.studentService.getById(this.id).subscribe({
        next: (entity: any) => {
          this.registrationForm.get('userName')?.setValue(entity.userName);
          this.registrationForm.get('firstName')?.setValue(entity.firstName);
          this.registrationForm.get('lastName')?.setValue(entity.lastName);
          this.registrationForm.get('career')?.setValue(entity.career);
          this.registrationForm.get('age')?.setValue(entity.age);
        },
        error: (e: any) => {
          console.log('Error', e);
        },
      });
    }
  }

  submit() {
    const controls = this.registrationForm.controls;
    Object.keys(controls).forEach((controlName) => {
      controls[controlName].markAsTouched();
    });

    // stop here if form is invalid
    if (this.registrationForm.invalid) {
      return;
    }

    const value = this.registrationForm.value;
    this.studentService.save(this.id, value, this.isNew).subscribe({
      next: () => {
        if (this.isNew) {
          this.typemessage = 'success';
          this.showmessage = true;
          this.registrationForm.reset();
        } else this.router.navigate(['/main/dashboard/component/student-list']);
      },
      error: (error: HttpErrorResponse) => {
        if (error.status === 404) {
        } else {
        }
      },
    });
  }

  back() {
    this.router.navigate(['/main/dashboard/component/student-list']);
  }
}
