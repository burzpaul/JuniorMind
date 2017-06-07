import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Form } from './form.interface';
import 'rxjs/add/operator/map';
import { Observable } from "rxjs/Observable";

@Injectable()

export class FormService {
    constructor(private http: Http) {
    }
    getDefault(): Observable<Form> {
        let url: string = "http://localhost:49513/api/values/defaultvalues";
        return this.http.get(url)
            .map((response: Response) => <Form>(response.json()));
    }

    postValues(values) {
        let url: string = "http://localhost:49513/api/values";
        return this.http.post(url, values)
            .map((response: Response) => response.json());
    }
}