import { Component, Input } from '@angular/core';

import { FormService } from './form.service';

@Component({
    selector: 'form-root',
    templateUrl: './form.html'
})

export class FormComponent {
    @Input() numberOfPasswords: number;
    @Input() passwordLength: number;
    @Input() upperCase: number;
    @Input() digits: number;
    @Input() symbols: number;
    @Input() excludeSimilar: boolean;
    @Input() excludeAmbigous: boolean;

    constructor(public formService: FormService) {
    }

    values = [this.numberOfPasswords,
    this.passwordLength,
    this.upperCase,
    this.digits,
    this.symbols,
    this.excludeSimilar,
    this.excludeAmbigous];

    public postValues() {
        this.formService.postValues(this.values).subscribe(responseValues => this.responseText = responseValues);
    }

    responseText;
    public returnPostResponse() {
        return this.responseText;
    }
}