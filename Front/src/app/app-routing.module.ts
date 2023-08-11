import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignInComponent } from './components/screens/sign-in/sign-in.component';
import { HomeComponent } from './components/screens/home/home.component';
import { authGuard } from './shared/auth.guard';
import { LayoutComponent } from './components/layout/layout.component';
import { CustomersComponent } from './components/screens/customers/customers.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    canActivate: [authGuard],
    children: [
      { path: '', component: HomeComponent },
      { path: 'customers', component: CustomersComponent },
    ],
  },
  {
    path: 'login',
    component: SignInComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
