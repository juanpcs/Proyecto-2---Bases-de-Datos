import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { HeaderComponent } from './Components/header/header.component';
import { RegisterComponent } from './Components/register/register.component';
import { AproductsComponent } from './Components/aproducts/aproducts.component';
import { NfoodComponent } from './Components/nfood/nfood.component';
import { CfoodComponent } from './Components/cfood/cfood.component';
import { AdminloginComponent } from './Components/adminlogin/adminlogin.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HeaderComponent,
    RegisterComponent,
    AproductsComponent,
    NfoodComponent,
    CfoodComponent,
    AdminloginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
