import { Component, Input } from '@angular/core';

import { FormService } from './form.service';

import { Form } from './form.interface';

@Component({
    selector: 'form-root',
    templateUrl: './form.html'
})

export class FormComponent  {
    @Input() numberOfPasswords: number;
    @Input() passwordLength: number;
    @Input() upperCase: number;
    @Input() digits: number;
    @Input() symbols: number;
    @Input() excludeSimilar: boolean;
    @Input() excludeAmbigous: boolean;


    public form: Form = {
        numberOfPasswords: 1,
        passwordLength: 8,
        upperCase: 2,
        digits: 2,
        symbols: 2,
        excludeSimilar: false,
        excludeAmbigous: false
    }

    constructor(public formService: FormService) {
    }

    valueChange(id, event) {
        id = event;
        this.postValues();
    }

    responseText;
    public postValues() {
        this.form.numberOfPasswords = this.numberOfPasswords;
        this.form.passwordLength = this.passwordLength;
        this.form.upperCase = this.upperCase;
        this.form.digits = this.digits;
        this.form.symbols = this.symbols;
        this.form.excludeSimilar = this.excludeSimilar;
        this.form.excludeAmbigous = this.excludeAmbigous;

        this.formService.postValues(this.form).subscribe(responseValues => this.responseText = responseValues);

    }

}