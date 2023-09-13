import { Component, EventEmitter, Input, Output } from '@angular/core';
import { EmailParams } from '../../shared/EmailParams';
import { EmailDialogComponent } from '../../dialogs/email-dialog/email-dialog.component';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { CustomerService } from 'src/app/services/customer.service';
import { _isTestEnvironment } from '@angular/cdk/platform';
import { ActivatedRoute } from '@angular/router';
import { CustomerParams } from '../../CustomerParams';
import { fadeInItems } from '@angular/material/menu';

@Component({
  selector: 'app-email-display',
  templateUrl: './email-display.component.html',
  styleUrls: ['./email-display.component.css'],
})
export class EmailDisplayComponent {
  @Input() emails: EmailParams[] = [];
  @Output() receiveData = new EventEmitter<EmailParams[]>();
  id: string = '';
  customer: CustomerParams = {};
  selectedEmailIndex: number = -1;

  constructor(
    private matDialog: MatDialog,
    private customerService: CustomerService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe((params) => (this.id = params['id']));
  }

  emailType(i: number) {
    if (this.emails[i].typeCode == 0) {
      return 'Não Definido';
    } else if (this.emails[i].typeCode == 1) {
      return 'Pessoal';
    } else {
      return 'Comercial';
    }
  }

  selectEmail(index: number) {
    this.selectedEmailIndex = index;
  }

  passData() {
    this.receiveData.emit(this.emails);
  }

  openDialog() {
    const dialogRef = this.matDialog.open(EmailDialogComponent, {
      width: '400px',
      height: '400px',
    });

    dialogRef.afterClosed().subscribe((emailData) => {
      if (emailData) {
        this.customerService.getCustomer(this.id).subscribe((items) => {
          const data = items;
          this.customer = data;
          this.customer.emails?.push(emailData);
          console.log(this.customer);

          this.customerService
            .updateCustomer(this.customer, this.id)
            .subscribe((items) => {
              window.location.reload();
            });
        });
      }
    });
  }

  openEditDialog() {
    if (this.selectedEmailIndex !== -1) {
      const dialogRef = this.matDialog.open(EmailDialogComponent, {
        width: '400px',
        height: '400px',
      });

      dialogRef.componentInstance.email = this.emails[this.selectedEmailIndex];

      dialogRef.afterClosed().subscribe((emailData) => {
        if (emailData) {
          this.customerService.getCustomer(this.id).subscribe((items) => {
            this.customer = items;
            this.customer.emails![this.selectedEmailIndex] = emailData;

            this.customerService
              .updateCustomer(this.customer, this.id)
              .subscribe((items) => {});
          });
        }
      });
    }
  }

  deleteEmail() {
    if (this.selectedEmailIndex !== -1) {
      this.customerService.getCustomer(this.id).subscribe((items) => {
        this.customer = items;
        this.customer.emails?.splice(this.selectedEmailIndex, 1);
        this.emails.splice(this.selectedEmailIndex, 1);

        this.customerService
          .updateCustomer(this.customer, this.id)
          .subscribe((items) => {});
      });
    }
  }

  deleteAllEmail() {
    this.customerService.getCustomer(this.id).subscribe((items) => {
      this.customer = items;
      this.customer.emails = [];
      this.emails = [];

      this.customerService
        .updateCustomer(this.customer, this.id)
        .subscribe((items) => {});
    });
  }
}
