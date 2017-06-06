import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()

export class FormService {
    constructor(private http: Http) {
    }
    getDefault() {
        let url: string = "http://localhost:49513/api/values/defaultvalues";
        return this.http.get(url).map((response: Response) => response.json());
    }
    postValues(values) {
        let url: string = "http://localhost:49513/api/values";
        return this.http.post(url, {
            numberOfPasswords: values.numberOfPasswords,
            passwordLength: values.passwordLength,
            upperCase: values.upperCase,
            digits: values.digits,
            symbols: values.symbols,
            excludeSimilar: values.excludeSimilar,
            exludeAmbigous: values.excludeAmbigous
        })
            .map((response: Response) => response.json());
    }
}