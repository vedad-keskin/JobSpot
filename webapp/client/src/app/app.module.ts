import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'; // ✅ Import HttpClientModule

import { RegisterComponent } from './screens/register/register.component';
import { LoginComponent } from './screens/login/login.component';
import { ButtonComponent } from './components/button/button.component';
import { LandingPageComponent } from './screens/landing-page/landing-page.component';
import { NotFoundComponent } from './screens/not-found/not-found.component';
import { NavarComponent } from './components/navar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { AdminPanelComponent } from './screens/admin-panel/admin-panel.component';

import { CountryService } from './services/country-service.service'; // ✅ Import CountryService

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    ButtonComponent,
    LandingPageComponent,
    NotFoundComponent,
    NavarComponent,
    FooterComponent,
    AdminPanelComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatCardModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [CountryService],
  bootstrap: [AppComponent],
})
export class AppModule {}
