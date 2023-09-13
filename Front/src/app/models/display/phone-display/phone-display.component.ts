import { Component, Input, OnInit } from '@angular/core';
import { PhoneParams } from '../../shared/PhoneParams';
import { MatDialog } from '@angular/material/dialog';
import { CustomerService } from 'src/app/services/customer.service';
import { ActivatedRoute } from '@angular/router';
import { PhoneDialogComponent } from '../../dialogs/phone-dialog/phone-dialog.component';
import { CustomerParams } from '../../CustomerParams';

@Component({
  selector: 'app-phone-display',
  templateUrl: './phone-display.component.html',
  styleUrls: ['./phone-display.component.css'],
})
export class PhoneDisplayComponent {
  @Input() phones: PhoneParams[] = [];
  id: string = '';
  customer: CustomerParams = {};
  selectedPhoneIndex: number = -1;

  constructor(
    private matDialog: MatDialog,
    private customerService: CustomerService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe((params) => (this.id = params['id']));
  }

  phoneType(i: number) {
    if (this.phones[i].typeCode == 0) {
      return 'Não Definido';
    } else if (this.phones[i].typeCode == 1) {
      return 'Celular';
    } else if (this.phones[i].typeCode == 2) {
      return 'Residencial';
    } else if (this.phones[i].typeCode == 3) {
      return 'Comercial';
    } else if (this.phones[i].typeCode == 4) {
      return 'Recados';
    } else {
      return 'Outros';
    }
  }

  selectPhone(index: number) {
    this.selectedPhoneIndex = index;
  }

  openDialog() {
    const dialogRef = this.matDialog.open(PhoneDialogComponent, {
      width: '400px',
      height: '400px',
    });

    dialogRef.afterClosed().subscribe((phoneData) => {
      if (phoneData) {
        this.customerService.getCustomer(this.id).subscribe((items) => {
          this.customer = items;
          this.customer.phones?.push(phoneData);
          this.phones.push(phoneData);

          this.customerService
            .updateCustomer(this.customer, this.id)
            .subscribe((items) => {});
        });
      }
    });
  }

  openEditDialog() {
    if (this.selectedPhoneIndex !== -1) {
      const dialogRef = this.matDialog.open(PhoneDialogComponent, {
        width: '400px',
        height: '400px',
      });

      dialogRef.componentInstance.phone = this.phones[this.selectedPhoneIndex];

      dialogRef.afterClosed().subscribe((phoneData) => {
        if (phoneData) {
          this.customerService.getCustomer(this.id).subscribe((items) => {
            this.customer = items;
            this.customer.phones![this.selectedPhoneIndex] = phoneData;

            this.customerService
              .updateCustomer(this.customer, this.id)
              .subscribe((items) => {});
          });
        }
      });
    }
  }

  deletePhone() {
    if (this.selectedPhoneIndex !== -1) {
      this.customerService.getCustomer(this.id).subscribe((items) => {
        this.customer = items;
        this.customer.phones?.splice(this.selectedPhoneIndex, 1);
        this.phones.splice(this.selectedPhoneIndex, 1);

        this.customerService
          .updateCustomer(this.customer, this.id)
          .subscribe((items) => {});
      });
    }
  }

  deleteAllPhone() {
    this.customerService.getCustomer(this.id).subscribe((items) => {
      this.customer = items;
      this.customer.phones = [];
      this.phones = [];

      this.customerService
        .updateCustomer(this.customer, this.id)
        .subscribe((items) => {});
    });
  }
}
