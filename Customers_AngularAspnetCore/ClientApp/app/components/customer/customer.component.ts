import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { AuthService, LoginVM } from '../../service/auth.service';

@Component({
	selector: 'customer',
	templateUrl: './customer.component.html'
})
export class CustomerComponent {


	private headers = new Headers({
		'Content-Type': 'application/json',
		'Accept': 'application/json',
		'withCredentials': 'false'
	});

    public customers: CustomerClass[];
    public genders: FilterClass[];
    public cities: FilterClass[];
    public regions: FilterClass[];
    public classifications: FilterClass[];
    public sellers: FilterClass[];

    customerFilter = new CustomerClass();

	http: Http;
	baseUrl: string;
    login: LoginVM;
    

    constructor(_http: Http, @Inject('BASE_URL') _baseUrl: string, public authService: AuthService) {
		this.http = _http;
        this.baseUrl = _baseUrl;
        this.login = authService.loginVM;

        var config = {
            params: {
                Id: this.login.Id,
                IsAdmin: this.login.IsAdmin
            }
        }

        _http.get(_baseUrl + 'api/Customer/GetFilters').subscribe(result => {
            this.genders = result.json().genders as FilterClass[];
            this.cities = result.json().cities as FilterClass[];
            this.regions = result.json().regions as FilterClass[];
            this.classifications = result.json().classifications as FilterClass[];
            this.sellers = result.json().sellers as FilterClass[];
        }, error => console.error(error));

        _http.get(_baseUrl + 'api/Customer/Get', config).subscribe(result => {
            this.customers = result.json() as CustomerClass[];
        }, error => console.error(error));
	}

    Filtrar() {

        var config = {
            params: {
                Id: this.login.Id,
                IsAdmin: this.login.IsAdmin,
                Name: this.customerFilter.Name,
                Gender: this.customerFilter.Gender,
                City: this.customerFilter.City,
                Region: this.customerFilter.Region,
                Classification: this.customerFilter.Classification,
                Seller: this.customerFilter.Seller
            }
        }

        this.http.get(this.baseUrl + 'api/Customer/Get', config).subscribe(result => {
            this.customers = result.json() as CustomerClass[];
        }, error => console.error(error));
    }

    Limpar() {

        var config = {
            params: {
                Id: this.login.Id,
                IsAdmin: this.login.IsAdmin,
                Name: this.customerFilter.Name,
                Gender: this.customerFilter.Gender,
                City: this.customerFilter.City,
                Region: this.customerFilter.Region,
                Classification: this.customerFilter.Classification,
                Seller: this.customerFilter.Seller
            }
        }

        this.http.get(this.baseUrl + 'api/Customer/Get', config).subscribe(result => {
            this.customers = result.json() as CustomerClass[];
        }, error => console.error(error));
    }
}

export class CustomerClass {
	Id: number;
    Name: string;
    Gender: string;
    City: string;
    Region: string;
    Classification: string;
    Seller: string;
}

export class FilterClass {
    Text: string;
    Value: string;
}