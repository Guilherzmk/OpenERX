import { Component, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { CustomerRegisterComponent } from '../customer-register/customer-register.component';
import { MatDialog } from '@angular/material/dialog';
import { CustomerParams } from 'src/app/models/CustomerParams';
import { CustomerService } from 'src/app/services/customer.service';
import * as moment from 'moment';
import { Router } from '@angular/router';

export interface Task {
  completed: boolean;
  color: ThemePalette;
  subtasks?: Task[];
}

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
})
export class CustomersComponent implements OnInit {
  task: Task = {
    completed: false,
    color: 'primary',
    subtasks: [{ completed: false, color: 'primary' }],
  };

  allComplete: boolean = false;
  date = moment();
  customers: CustomerParams[] = [];

  constructor(
    private customerService: CustomerService,
    private matDialog: MatDialog,
    private router: Router
  ) {}

  customerLength() {
    if (this.customers?.length == null) {
      return '0';
    } else {
      return this.customers.length;
    }
  }

  ngOnInit(): void {
    this.customerService.getCustomers().subscribe({
      next: (items) => {
        this.customers = items;
      },
      error: (erro) => {
        this.router.navigate(['/login']);
        localStorage.removeItem('Token');
      },
    });
  }

  onRowDoubleClick(item: any) {
    this.router.navigate(['/customers', `${item.id}`, 'detail']);
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

  convertCreationDate(index: number): string {
    let date = moment(this.customers[index - 1].creationDate).format(
      'DD/MM/YYYY HH:mm'
    );
    return date;
  }

  convertChangeDate(index: number): string {
    let date = moment(this.customers[index - 1].changeDate).format(
      'DD/MM/YYYY HH:mm'
    );
    return date;
  }
}
