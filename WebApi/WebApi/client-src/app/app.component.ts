import { Component, OnInit, ElementRef } from '@angular/core';

import { FormService } from "./form.service";

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(public formService: FormService) {
    }

    values = [];
    ngOnInit() {
        this.formService.getDefault().subscribe(responseValues => this.values = responseValues);
    }
}