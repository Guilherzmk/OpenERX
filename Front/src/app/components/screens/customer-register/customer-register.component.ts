import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddressParams } from '../../../models/shared/AddressParams';
import { CustomerParams } from 'src/app/models/CustomerParams';
import { FormGroup } from '@angular/forms';
import { CustomerService } from 'src/app/services/customer.service';
import { Router } from 'express';

@Component({
  selector: 'app-customer-register',
  templateUrl: './customer-register.component.html',
  styleUrls: ['./customer-register.component.css'],
})
export class CustomerRegisterComponent implements OnInit {
  customerForm!: FormGroup;
  address: AddressParams = {};
  customer: CustomerParams = {};

  constructor(
    private dialog: MatDialog,
    private customerService: CustomerService
  ) {}
  ngOnInit(): void {}

  receiveCustomer($event: CustomerParams) {
    this.customer = $event;
    return this.customer;
  }

  receiveAddress($event: AddressParams) {
    this.address = $event;

    return this.address;
  }

  submit() {
    this.customer.addresses = [this.address];

    if (this.address.zipCode == '') {
      this.customer.addresses = undefined;
    }

    this.customerService.createCustomer(this.customer).subscribe((items) => {
      console.log(items);

      this.closeDialog();
      window.location.reload();
    });
  }

  closeDialog() {
    this.dialog.closeAll();
  }
}
