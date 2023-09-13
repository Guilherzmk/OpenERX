import { Component, Input } from '@angular/core';
import { AddressParams } from '../../shared/AddressParams';
import { CustomerParams } from '../../CustomerParams';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';
import { AddressDialogComponent } from '../../dialogs/address-dialog/address-dialog.component';

@Component({
  selector: 'app-address-display',
  templateUrl: './address-display.component.html',
  styleUrls: ['./address-display.component.css'],
})
export class AddressDisplayComponent {
  @Input() addresses: AddressParams[] = [];
  id: string = '';
  customer: CustomerParams = {};
  selectedAddressIndex: number = -1;

  constructor(
    private matDialog: MatDialog,
    private customerService: CustomerService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe((params) => (this.id = params['id']));
  }

  selectEmail(i: number) {
    this.selectedAddressIndex = i;
  }

  addressType(i: number) {
    if (this.addresses[i].typeCode == 0) {
      return 'Não Definido';
    } else if (this.addresses[i].typeCode == 1) {
      return 'Residencial';
    } else {
      return 'Comercial';
    }
  }

  openDialog() {
    const dialogRef = this.matDialog.open(AddressDialogComponent, {
      width: '450px',
      height: '859px',
    });

    dialogRef.afterClosed().subscribe((addressData) => {
      if (addressData) {
        this.customerService.getCustomer(this.id).subscribe((items) => {
          this.customer = items;
          this.customer.addresses?.push(addressData);
          this.addresses.push(addressData);

          this.customerService
            .updateCustomer(this.customer, this.id)
            .subscribe((items) => {});
        });
      }
    });
  }

  openEditDialog() {
    if (this.selectedAddressIndex !== -1) {
      const dialogRef = this.matDialog.open(AddressDialogComponent, {
        width: '450px',
        height: '859px',
      });

      console.log(this.addresses[this.selectedAddressIndex]);

      dialogRef.componentInstance.address =
        this.addresses[this.selectedAddressIndex];

      dialogRef.afterClosed().subscribe((addressData) => {
        if (addressData) {
          this.customerService.getCustomer(this.id).subscribe((items) => {
            this.customer = items;
            this.customer.addresses![this.selectedAddressIndex] = addressData;

            this.customerService
              .updateCustomer(this.customer, this.id)
              .subscribe((items) => {});
          });
        }
      });
    }
  }

  deleteAddress() {
    if (this.selectedAddressIndex !== -1) {
      this.customerService.getCustomer(this.id).subscribe((items) => {
        this.customer = items;
        this.customer.addresses?.splice(this.selectedAddressIndex, 1);
        this.addresses.splice(this.selectedAddressIndex, 1);

        this.customerService
          .updateCustomer(this.customer, this.id)
          .subscribe((items) => {});
      });
    }
  }

  deleteAllAddress() {
    this.customerService.getCustomer(this.id).subscribe((items) => {
      this.customer = items;
      this.customer.addresses = [];
      this.addresses = [];

      this.customerService
        .updateCustomer(this.customer, this.id)
        .subscribe((items) => {});
    });
  }
}
