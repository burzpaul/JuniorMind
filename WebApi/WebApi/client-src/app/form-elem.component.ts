import { Component, Input, Output } from '@angular/core';

@Component({
    selector: 'form-elem',
    templateUrl: './form-elem.component.html'
})
export class FormElementComponent {
    @Input() text: string;
    @Input() value: number;
    @Input() type: string;
}