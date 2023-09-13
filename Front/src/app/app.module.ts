import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignInComponent } from './components/screens/sign-in/sign-in.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatBadgeModule } from '@angular/material/badge';
import { MatSelectModule } from '@angular/material/select';
import { MatDialogModule } from '@angular/material/dialog';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';

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
import { AddressInputComponent } from './models/inputs/address-input/address-input.component';
import { NgxMaskDirective, NgxMaskPipe } from 'ngx-mask';
import { CustomerDetailComponent } from './components/screens/customer-detail/customer-detail.component';
import { CustomerDisplayDetailComponent } from './models/display/customer-display-detail/customer-display-detail.component';
import { PhoneInputComponent } from './models/inputs/phone-input/phone-input.component';
import { PhoneDialogComponent } from './models/dialogs/phone-dialog/phone-dialog.component';
import { EmailDialogComponent } from './models/dialogs/email-dialog/email-dialog.component';
import { EmailInputComponent } from './models/inputs/email-input/email-input.component';
import { PhoneDisplayComponent } from './models/display/phone-display/phone-display.component';
import { EmailDisplayComponent } from './models/display/email-display/email-display.component';
import { AddressDisplayComponent } from './models/display/address-display/address-display.component';
import { LogDisplayComponent } from './models/display/log-display/log-display.component';
import { ClipboardModule } from '@angular/cdk/clipboard';
import { AddressDialogComponent } from './models/dialogs/address-dialog/address-dialog.component';
import { CustomerDialogComponent } from './models/dialogs/customer-dialog/customer-dialog.component';

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
    AddressInputComponent,
    CustomerDetailComponent,
    CustomerDisplayDetailComponent,
    PhoneInputComponent,
    PhoneDialogComponent,
    EmailDialogComponent,
    EmailInputComponent,
    PhoneDisplayComponent,
    EmailDisplayComponent,
    AddressDisplayComponent,
    LogDisplayComponent,
    AddressDialogComponent,
    CustomerDialogComponent,
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
    MatTabsModule,
    MatBadgeModule,
    MatMenuModule,
    MatDialogModule,
    MatTableModule,
    MatToolbarModule,
    MatInputModule,
    ClipboardModule,
    MatSidenavModule,
    NgMaterialMultilevelMenuModule,
    ReactiveFormsModule,
    NgxMaskDirective,
    NgxMaskPipe,
  ],
  providers: [MultilevelMenuService],
  bootstrap: [AppComponent],
})
export class AppModule {}
