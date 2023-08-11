import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignInComponent } from './components/screens/sign-in/sign-in.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatBadgeModule } from '@angular/material/badge';
import {MatSelectModule} from '@angular/material/select';
import {MatDialogModule} from '@angular/material/dialog';
import {MatTableModule} from '@angular/material/table';

import {
  MultilevelMenuService,
  NgMaterialMultilevelMenuModule,
} from 'ng-material-multilevel-menu';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './components/screens/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { LayoutComponent } from './components/layout/layout.component';
import { CustomersComponent } from './components/screens/customers/customers.component';
import { CustomerRegisterComponent } from './components/screens/customer-register/customer-register.component';
import { CustomerInputComponent } from './models/inputs/customer-input/customer-input.component';
import { IConfig } from 'ngx-mask'

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    SignInComponent,
    HomeComponent,
    HeaderComponent,
    CustomersComponent,
    CustomerRegisterComponent,
    CustomerInputComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatCheckboxModule,
    FormsModule,
    MatIconModule,
    MatListModule,
    MatButtonModule,
    MatBadgeModule,
    MatDialogModule,
    MatTableModule,
    MatToolbarModule,
    MatInputModule,
    MatSidenavModule,
    NgMaterialMultilevelMenuModule,
    ReactiveFormsModule,
  ],
  providers: [MultilevelMenuService],
  bootstrap: [AppComponent],
})
export class AppModule {}
