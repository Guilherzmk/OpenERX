import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import { EmailParams } from '../../shared/EmailParams';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

interface emailType {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-email-dialog',
  templateUrl: './email-dialog.component.html',
  styleUrls: ['./email-dialog.component.css'],
})
export class EmailDialogComponent {
  @Output() receiveData = new EventEmitter<EmailParams>();
  emailForm!: FormGroup;
  email: EmailParams = {};

  constructor(public emailDialog: MatDialogRef<EmailDialogComponent>) {}

  setEmailType() {
    if ((this.email.typeCode = 1)) {
      return this.emailTypes[0].value;
    } else if ((this.email.typeCode = 2)) {
      return this.emailTypes[1].value;
    } else {
      return null;
    }
  }

  ngOnInit(): void {
    this.emailForm = new FormGroup({
      address: new FormControl(this.email.address, [Validators.required]),
      type: new FormControl(this.setEmailType()),
      note: new FormControl(this.email.note),
    });
  }

  confirmEmail() {
    this.email.address = this.address?.value;
    this.email.typeCode = this.type?.value;
    this.email.note = this.note?.value;
    this.emailDialog.close(this.email);
  }

  get address() {
    return this.emailForm.get('address');
  }

  get type() {
    return this.emailForm.get('type');
  }

  get note() {
    return this.emailForm.get('note');
  }

  emailTypes: emailType[] = [
    { value: '1', viewValue: 'Pessoal' },
    { value: '2', viewValue: 'Comercial' },
  ];

  cancelClick() {
    this.emailDialog.close();
  }
}
