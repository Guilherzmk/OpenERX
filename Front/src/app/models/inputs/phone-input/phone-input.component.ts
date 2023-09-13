import {
  Component,
  OnInit,
  EventEmitter,
  Output,
  ViewChild,
  ElementRef,
} from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { PhoneDialogComponent } from '../../dialogs/phone-dialog/phone-dialog.component';
import { PhoneParams } from '../../shared/PhoneParams';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-phone-input',
  templateUrl: './phone-input.component.html',
  styleUrls: ['./phone-input.component.css'],
})
export class PhoneInputComponent implements OnInit {
  @Output() receiveData = new EventEmitter<PhoneParams[]>();

  constructor(private matDialog: MatDialog) {}

  number = new FormControl('');
  ngOnInit(): void {}

  phoneInputs: PhoneParams[] = [
    {
      typeCode: +'',
      number: this.number.value!,
      note: '',
    },
  ];

  passData() {
    this.receiveData.emit(this.phoneInputs);
  }

  openDialog() {
    const dialogRef = this.matDialog.open(PhoneDialogComponent, {
      width: '400px',
      height: '400px',
    });

    dialogRef.afterClosed().subscribe((phoneData) => {
      if (phoneData) {
        this.phoneInputs.push(phoneData);
        this.receiveData.emit(this.phoneInputs);
      }
    });
  }
}
