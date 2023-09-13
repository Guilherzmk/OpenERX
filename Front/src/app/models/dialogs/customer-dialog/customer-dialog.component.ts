import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { CustomerParams } from '../../CustomerParams';
import * as moment from 'moment';

interface personType {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-customer-dialog',
  templateUrl: './customer-dialog.component.html',
  styleUrls: ['./customer-dialog.component.css'],
})
export class CustomerDialogComponent implements OnInit {
  customerForm!: FormGroup;
  customer!: CustomerParams;

  personTypes: personType[] = [
    { value: '1', viewValue: 'Pessoa Fisíca' },
    { value: '2', viewValue: 'Pessoa Jurídica' },
  ];

  setPersonType() {
    if (this.customer.personTypeCode == 1) {
      return this.personTypes[0].value;
    } else {
      return this.personTypes[1].value;
    }
  }

  constructor(private customerDialog: MatDialogRef<CustomerDialogComponent>) {}

  ngOnInit(): void {
    this.customerForm = new FormGroup({
      personType: new FormControl(this.setPersonType()),
      identity: new FormControl(this.customer.identity),
      name: new FormControl(this.customer.name),
      nickname: new FormControl(this.customer.nickname),
      birthDate: new FormControl(
        moment(this.customer.birthDate, 'DD/MM/YYYY').format('DD/MM/YYYY')
      ),
      note: new FormControl(this.customer.note),
    });
  }

  get personType() {
    return this.customerForm.get('persontType');
  }

  get identity() {
    return this.customerForm.get('identity');
  }

  get name() {
    return this.customerForm.get('name');
  }

  get nickname() {
    return this.customerForm.get('nickname');
  }

  get birthDate() {
    return this.customerForm.get('birthDate');
  }

  get note() {
    return this.customerForm.get('note');
  }

  confirmCustomer() {
    this.customer.personTypeCode = this.personType?.value;
    this.customer.identity = this.identity?.value;
    this.customer.name = this.name?.value;
    this.customer.nickname = this.nickname?.value;
    this.customer.birthDate = this.birthDate?.value;
    this.customer.note = this.note?.value;
    this.customerDialog.close(this.customer);
  }

  cancelClick() {
    this.customerDialog.close();
  }
}
