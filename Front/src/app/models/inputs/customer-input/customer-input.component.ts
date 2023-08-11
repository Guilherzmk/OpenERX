import { Component } from '@angular/core';

interface personType{
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-customer-input',
  templateUrl: './customer-input.component.html',
  styleUrls: ['./customer-input.component.css']
})
export class CustomerInputComponent {
personTypes: personType[] = [
  {value: '1', viewValue: 'Pessoa Fisíca'},
  {value: '2', viewValue: 'Pessoa Jurídica'}
]
}
