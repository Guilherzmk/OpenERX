import { Component, EventEmitter, Output } from '@angular/core';
import { EmailParams } from '../../shared/EmailParams';
import { MatDialog } from '@angular/material/dialog';
import { FormControl, FormControlName } from '@angular/forms';
import { BuiltinTypeName } from '@angular/compiler';
import { EmailDialogComponent } from '../../dialogs/email-dialog/email-dialog.component';

@Component({
  selector: 'app-email-input',
  templateUrl: './email-input.component.html',
  styleUrls: ['./email-input.component.css'],
})
export class EmailInputComponent {
  @Output() receiveData = new EventEmitter<EmailParams[]>();

  constructor(private matDialog: MatDialog) {}
  email = new FormControl('');

  emailInputs: EmailParams[] = [
    {
      typeCode: +'',
      typeName: '',
      address: this.email.value!,
      note: '',
    },
  ];

  passData() {
    this.receiveData.emit(this.emailInputs);
  }

  openDialog() {
    const dialogRef = this.matDialog.open(EmailDialogComponent, {
      width: '400px',
      height: '400px',
    });

    dialogRef.afterClosed().subscribe((emailData) => {
      if (emailData) {
        this.emailInputs.push(emailData);
        this.receiveData.emit(this.emailInputs);
      }
    });
  }
}
