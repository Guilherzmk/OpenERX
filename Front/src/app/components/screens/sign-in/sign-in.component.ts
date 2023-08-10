import { Component, OnInit, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SignInParams } from 'src/app/models/SignInParams';
import { SignInService } from 'src/app/services/sign-in.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
  providers: [SignInService],
})
export class SignInComponent implements OnInit {
  signInForm!: FormGroup;
  showMenu = new EventEmitter<boolean>();

  constructor(private singInService: SignInService, private router: Router) {}
  ngOnInit(): void {
    this.signInForm = new FormGroup({
      accessKey: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
    });
  }

  get accessKey() {
    return this.signInForm.get('accessKey');
  }

  get password() {
    return this.signInForm.get('password');
  }

  async submitLogin() {
    let params = this.signInForm.getRawValue() as SignInParams;

    this.singInService.signIn(params).subscribe({
      next: (result) => {
        console.log(result.token);
        localStorage.setItem('Token', result.token);

        this.showMenu.emit(true);

        this.router.navigate(['/']);
      },
    });
  }
}

// subscribe({
//       next: (result) => {
//         debugger;
//         console.log(result);
//       },
//       error: (error) => {
//         debugger;
//         console.log(error);
//       },
//     })
