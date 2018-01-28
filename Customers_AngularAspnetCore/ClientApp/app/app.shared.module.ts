import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { CustomerComponent } from './components/customer/customer.component';

import { AuthGuard } from './service/auth-guard.service';
import { AuthService } from './service/auth.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        LoginComponent,
        CustomerComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
            { path: 'login', component: LoginComponent },
            { path: 'customer', component: CustomerComponent, canActivate: [AuthGuard] },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [AuthGuard, AuthService]
})
export class AppModuleShared {
}
