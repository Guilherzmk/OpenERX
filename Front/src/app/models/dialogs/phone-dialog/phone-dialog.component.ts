import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { provideNgxMask } from 'ngx-mask';
import { PhoneParams } from '../../shared/PhoneParams';

interface phoneType {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-phone-dialog',
  templateUrl: './phone-dialog.component.html',
  styleUrls: ['./phone-dialog.component.css'],
  providers: [provideNgxMask()],
})
export class PhoneDialogComponent implements OnInit {
  @Output() receiveData = new EventEmitter<PhoneParams>();
  phoneForm!: FormGroup;
  phone: PhoneParams = {};

  constructor(public phoneDialog: MatDialogRef<PhoneDialogComponent>) {}

  setPhoneType() {
    if (this.phone.typeCode == 1) {
      return this.phoneTypes[0].value;
    } else if (this.phone.typeCode == 2) {
      return this.phoneTypes[1].value;
    } else if (this.phone.typeCode == 3) {
      return this.phoneTypes[2].value;
    } else if (this.phone.typeCode == 4) {
      return this.phoneTypes[3].value;
    } else if (this.phone.typeCode == 5) {
      return this.phoneTypes[4].value;
    } else {
      return null;
    }
  }

  ngOnInit(): void {
    this.phoneForm = new FormGroup({
      phoneType: new FormControl(this.setPhoneType()),
      number: new FormControl(this.phone.number, [Validators.required]),
      note: new FormControl(this.phone.note),
    });
  }

  confirmPhone() {
    this.phone.typeCode = this.phoneType?.value;
    this.phone.number = this.number?.value;
    this.phone.note = this.note?.value;
    this.phoneDialog.close(this.phone);
  }

  get number() {
    return this.phoneForm.get('number');
  }

  get phoneType() {
    return this.phoneForm.get('phoneType');
  }

  get note() {
    return this.phoneForm.get('note');
  }

  phoneTypes: phoneType[] = [
    { value: '1', viewValue: 'Celular' },
    { value: '2', viewValue: 'Residencial' },
    { value: '3', viewValue: 'Comercial' },
    { value: '4', viewValue: 'Recados' },
    { value: '5', viewValue: 'Outros' },
  ];

  cancelClick() {
    this.phoneDialog.close();
  }
}
