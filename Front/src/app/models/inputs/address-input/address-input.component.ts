import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { provideNgxMask } from 'ngx-mask';
import { AddressParams } from '../../shared/AddressParams';

@Component({
  selector: 'app-address-input',
  templateUrl: './address-input.component.html',
  styleUrls: ['./address-input.component.css'],
  providers: [provideNgxMask()],
})
export class AddressInputComponent {
  @Output() receiveData = new EventEmitter<AddressParams>();

  zipCode = new FormControl('');
  address = new FormControl('');
  number = new FormControl('');
  complement = new FormControl('');
  district = new FormControl('');
  city = new FormControl('');
  state = new FormControl('');
  note = new FormControl('');

  passData() {
    this.receiveData.emit({
      typeCode: 0,
      typeName: '',
      prefix: '',
      street: this.address.value!,
      number: this.number.value!,
      complement: this.complement.value!,
      district: this.district.value!,
      city: this.city.value!,
      state: this.state.value!,
      country: '',
      zipCode: this.zipCode.value!,
      note: '',
    });
  }
}
