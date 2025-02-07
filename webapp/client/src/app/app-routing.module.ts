import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './screens/register/register.component';
import { LoginComponent } from './screens/login/login.component';
import { LandingPageComponent } from './screens/landing-page/landing-page.component';
import { NotFoundComponent } from './screens/not-found/not-found.component';
import {AdminPanelComponent} from "./screens/admin-panel/admin-panel.component";

const routes: Routes = [
  { path: 'register', component: RegisterComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent, pathMatch: 'full' },
  { path: '', component: LandingPageComponent, pathMatch: 'full' },
  { path: 'admin-panel', component: AdminPanelComponent, pathMatch: 'full' },
  { path: '**', component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
