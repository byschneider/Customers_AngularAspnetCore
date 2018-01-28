import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../service/auth.service';

@Component({
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {
    message: string;
    errors: boolean;
	LoginInst = new LoginClass();

	constructor(public authService: AuthService, public router: Router) {
		this.setMessage();
	}

	setMessage() {
		this.message = '';
	}

	DoLogin() {
        this.message = 'Logging in...';
		this.authService.DoLogin(this.LoginInst.Login, this.LoginInst.Password).subscribe(() => {
			this.setMessage();
            if (this.authService.isLoggedIn) {

                let redirect = '/customer';

                // Redirect the user
                this.router.navigate([redirect]);
            } else {
                this.errors = true;
                this.message = "The e-mail and/or password entered is invalid. Please try again.";
            }
		});
	}

    logout() {
        this.errors = false;
		this.authService.logout();
		this.setMessage();
	}
}

export class LoginClass {
	Login: string;
    Password: string;
    Id: number;
    IsAdmin: boolean;
}