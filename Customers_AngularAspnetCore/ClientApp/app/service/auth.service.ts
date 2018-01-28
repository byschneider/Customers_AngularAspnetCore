import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/delay';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthService {
	isLoggedIn = false;
	// store the URL so we can redirect after logging in
	redirectUrl: string;
	http: Http;
    baseUrl: string;
    loginVM = new LoginVM();

	constructor(_http: Http, @Inject('BASE_URL') _baseUrl: string) {
		this.http = _http;
		this.baseUrl = _baseUrl;

	}

	DoLogin(login: string, password: string): Observable<boolean> {
        return this.http.get(this.baseUrl + 'api/Login/Get', { params: { email: login, password: password } }).map(result => {

            this.loginVM = new LoginVM();
            this.loginVM = result.json();

            if (this.loginVM != null)
            {
                this.isLoggedIn = true;
            }
            else
            {
                this.isLoggedIn = false;
            }
			return this.isLoggedIn;
		});
	}

	logout(): void {
		this.isLoggedIn = false;
	}
}

export class LoginVM {
    Login: string;
    Password: string;
    Id: number;
    IsAdmin: boolean;
}