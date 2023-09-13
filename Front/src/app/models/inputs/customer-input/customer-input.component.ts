import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { provideNgxMask } from 'ngx-mask';
import { AddressParams } from '../../shared/AddressParams';
import { outputAst } from '@angular/compiler';
import { CustomerParams } from '../../CustomerParams';
import { PhoneParams } from '../../shared/PhoneParams';
import { EmailParams } from '../../shared/EmailParams';

interface personType {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-customer-input',
  templateUrl: './customer-input.component.html',
  styleUrls: ['./customer-input.component.css'],
  providers: [provideNgxMask()],
})
export class CustomerInputComponent {
  @Output() receiveData = new EventEmitter<CustomerParams>();
  phones: PhoneParams[] = [];
  emails: EmailParams[] = [];
  customer: CustomerParams = {};

  personTypes: personType[] = [
    { value: '1', viewValue: 'Pessoa Fisíca' },
    { value: '2', viewValue: 'Pessoa Jurídica' },
  ];
  personType = new FormControl('', [Validators.required]);
  name = new FormControl('', [Validators.required]);
  identity = new FormControl('', [Validators.required]);
  birthDate = new FormControl('');
  note = new FormControl('');

  identityPlaceholder() {
    let identityPlaceholder = '1';

    if (this.personType.value === '1') {
      identityPlaceholder = 'CPF';
      return identityPlaceholder;
    } else if (this.personType.value === '2') {
      identityPlaceholder = 'CNPJ';
      return identityPlaceholder;
    } else {
      return 'CPF';
    }
  }

  identityMask() {
    if (this.identityPlaceholder() === 'CPF') {
      return '000.000.000-00';
    } else {
      return '00.000.000/0000-00';
    }
  }

  receivePhone($event: PhoneParams[]) {
    this.phones = $event;
    this.passData();
  }

  receiveEmail($event: EmailParams[]) {
    this.emails = $event;
    this.passData();
  }

  passData() {
    this.customer = {
      personTypeCode: +this.personType.value!,
      name: this.name.value!,
      nickname: '',
      identity: this.identity.value!,
      birthDate: this.birthDate.value!,
      note: this.note.value!,
      phones: this.phones,
      emails: this.emails,
    };

    this.receiveData.emit(this.customer);
  }
}
