import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import * as moment from 'moment';
import { CustomerDialogComponent } from '../../dialogs/customer-dialog/customer-dialog.component';
import { DialogConfig } from '@angular/cdk/dialog';
import { CustomerParams } from '../../CustomerParams';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-display-detail',
  templateUrl: './customer-display-detail.component.html',
  styleUrls: ['./customer-display-detail.component.css'],
})
export class CustomerDisplayDetailComponent {
  @Input() id: string = '';
  @Input() name: string = '';
  @Input() personType: number = 0;
  @Input() nickname: string = '';
  @Input() birthDate: string = '';
  @Input() identity: string = '';
  @Input() note: string = '';
  customer: CustomerParams = {};

  constructor(
    private matDialog: MatDialog,
    private customerService: CustomerService
  ) {}

  convertBirthDate() {
    let date = moment(this.birthDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
    return date;
  }

  copyToClipboard(identity: string) {}

  openDialog() {
    const dialogRef = this.matDialog.open(CustomerDialogComponent, {
      width: '650px',
      height: '630px',
    });

    let customer: CustomerParams = {
      personTypeCode: this.personType,
      name: this.name,
      nickname: this.nickname,
      birthDate: this.birthDate,
      identity: this.identity,
      note: this.note,
    };

    dialogRef.componentInstance.customer = customer;

    dialogRef.afterClosed().subscribe((customerData) => {
      if (customerData) {
        this.customerService
          .updateCustomer(customerData, this.id)
          .subscribe((items) => {
            window.location.reload();
          });
      }
    });
  }
}
