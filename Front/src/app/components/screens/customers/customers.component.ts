import { Component, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { CustomerRegisterComponent } from '../customer-register/customer-register.component';
import { MatDialog } from '@angular/material/dialog';
import { CustomerParams } from 'src/app/models/CustomerParams';
import { CustomerService } from 'src/app/services/customer.service';

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
  customers: CustomerParams[] = [];

  constructor(private customerService: CustomerService, private matDialog:MatDialog) {}

  ngOnInit(): void {
    this.customerService.getCustomers().subscribe((items) => {
      const data = items;

      this.customers = data;

      console.log(this.customers);
    });
  }

  updateAllComplete() {
    this.allComplete =
      this.task?.subtasks != null &&
      this.task?.subtasks.every((t) => t.completed);
  }

  someComplete(): boolean {
    if (this.task?.subtasks == null) {
      return false;
    }
    return (
      this.task?.subtasks.filter((t) => t.completed).length > 0 &&
      !this.allComplete
    );
  }

  setAll(completed: boolean) {
    this.allComplete = completed;
    if (this.task?.subtasks == null) {
      return;
    }
    this.task?.subtasks.forEach((t) => (t.completed = completed));
  }

  onRowDoubleClick(item: any) {
    console.log('Item clicado:', item);
    // Aqui você pode fazer o que quiser com os dados do item clicado
  }

  openDialog(){
    this.matDialog.open(CustomerRegisterComponent,{
      width:'100%',
      height: '100%',

    })
  }
}
