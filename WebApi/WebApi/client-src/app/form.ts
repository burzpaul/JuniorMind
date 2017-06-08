import { Component, Input } from '@angular/core';

import { FormService } from './form.service';

import { Form } from './form.interface';

@Component({
    selector: 'form-root',
    templateUrl: './form.html'
})

export class FormComponent  {
    @Input() form: Form;

    constructor(public formService: FormService) {
    }

    valueChange(event) {
        this.postValues();
    }

    responseText = [];
    public postValues() {
        this.formService.postValues(this.form).subscribe(responseValues => this.responseText = responseValues);
    }

}