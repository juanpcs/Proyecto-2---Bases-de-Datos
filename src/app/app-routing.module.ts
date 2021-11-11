import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminloginComponent } from './Components/adminlogin/adminlogin.component';
import { AproductsComponent } from './Components/aproducts/aproducts.component';
import { CfoodComponent } from './Components/cfood/cfood.component';
import { LoginComponent } from './Components/login/login.component';
import { NfoodComponent } from './Components/nfood/nfood.component';
import { RegisterComponent } from './Components/register/register.component';

const routes: Routes = [
  {
    path: "",
    component: LoginComponent
  },
  {
    path: "client",
    component: CfoodComponent
  },
  {
    path: "nutritionist",
    component: NfoodComponent
  },
  {
    path: "register",
    component: RegisterComponent
  },
  {
    path: "adminlogin",
    component: AdminloginComponent
  },
  {
    path: "admin",
    component: AproductsComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
