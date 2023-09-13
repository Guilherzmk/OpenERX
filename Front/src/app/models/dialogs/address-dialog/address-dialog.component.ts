import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormControlName,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { provideNgxMask } from 'ngx-mask';
import { AddressParams } from '../../shared/AddressParams';

interface addressType {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-address-dialog',
  templateUrl: './address-dialog.component.html',
  styleUrls: ['./address-dialog.component.css'],
  providers: [provideNgxMask()],
})
export class AddressDialogComponent implements OnInit {
  addressForm!: FormGroup;
  address: AddressParams = {};

  constructor(private addressDialog: MatDialogRef<AddressDialogComponent>) {}

  setAddressType() {
    if ((this.address.typeCode = 1)) {
      return this.addressTypes[0].value;
    } else if ((this.address.typeCode = 2)) {
      return this.addressTypes[1].value;
    } else {
      return null;
    }
  }

  ngOnInit(): void {
    this.addressForm = new FormGroup({
      zipCode: new FormControl(this.address.zipCode),
      address: new FormControl(this.address.street),
      number: new FormControl(this.address.number),
      complement: new FormControl(this.address.complement),
      district: new FormControl(this.address.district),
      city: new FormControl(this.address.city),
      state: new FormControl(this.address.state),
      type: new FormControl(this.setAddressType()),
      note: new FormControl(this.address.note),
    });
  }

  addressTypes: addressType[] = [
    { value: '1', viewValue: 'Pessoal' },
    { value: '2', viewValue: 'Comercial' },
  ];

  cancelClick() {
    this.addressDialog.close();
  }

  confirmAddress() {
    this.address.zipCode = this.zipCode?.value;
    this.address.street = this.street?.value;
    this.address.number = this.number?.value;
    this.address.complement = this.complement?.value;
    this.address.district = this.district?.value;
    this.address.city = this.city?.value;
    this.address.state = this.state?.value;
    this.address.typeCode = this.type?.value;
    this.address.note = this.note?.value;
    this.addressDialog.close(this.address);
  }

  get zipCode() {
    return this.addressForm.get('zipCode');
  }

  get number() {
    return this.addressForm.get('number');
  }

  get street() {
    return this.addressForm.get('address');
  }

  get complement() {
    return this.addressForm.get('complement');
  }

  get district() {
    return this.addressForm.get('district');
  }

  get city() {
    return this.addressForm.get('city');
  }

  get state() {
    return this.addressForm.get('state');
  }

  get type() {
    return this.addressForm.get('type');
  }

  get note() {
    return this.addressForm.get('note');
  }
}
