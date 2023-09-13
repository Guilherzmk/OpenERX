import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, NavigationStart, Router } from '@angular/router';
import * as moment from 'moment';
import { CustomerParams } from 'src/app/models/CustomerParams';
import { CustomerService } from 'src/app/services/customer.service';
import { CustomerRegisterComponent } from '../customer-register/customer-register.component';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css'],
})
export class CustomerDetailComponent implements OnInit {
  customer: CustomerParams = {};
  id: string = '';
  subscription: Subscription = new Subscription();
  constructor(
    private router: Router,
    private customerService: CustomerService,
    private route: ActivatedRoute,
    private matDialog: MatDialog
  ) {}
  ngOnInit(): void {
    this.route.params.subscribe((params) => (this.id = params['id']));
    this.customerService.getCustomer(this.id).subscribe((items) => {
      const data = items;
      this.customer = data;
    });
  }

  updateCustomer() {
    console.log(this.customer);
  }

  closeScreen() {
    this.router.navigate(['/customers']);
  }

  openDialog() {
    this.matDialog.open(CustomerRegisterComponent, {
      maxWidth: '100vw',
      maxHeight: '100vh',
      height: '100%',
      width: '100%',
      panelClass: 'full-screen-modal',
    });
  }
}
