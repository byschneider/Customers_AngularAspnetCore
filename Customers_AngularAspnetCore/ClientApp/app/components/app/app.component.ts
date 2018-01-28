import { Component } from '@angular/core';
import { AuthService } from '../../service/auth.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {



    constructor(public authService: AuthService, public router: Router) {
    }


    LogOut() {
        this.authService.logout();
        let redirect = '/login';
        this.router.navigate([redirect]);
    }
}
