import { Component, OnInit } from '@angular/core';

import { FormService } from "./form.service";

import { Form } from './form.interface';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    form: Form = {
        numberOfPasswords: 0,
        passwordLength: 0,
        upperCase: 0,
        digits: 0,
        symbols: 0,
        excludeSimilar: false,
        excludeAmbigous: false
    }

    constructor(public formService: FormService) {
    }

    ngOnInit() {
        this.formService.getDefault().subscribe(form => this.form = form);
    }
}