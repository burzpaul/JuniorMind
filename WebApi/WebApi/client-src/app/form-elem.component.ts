import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'form-elem',
    templateUrl: './form-elem.component.html'
})
export class FormElementComponent {
    @Input() text: string;
    @Input() value: number;
    @Input() type: string;

    @Output('update') valueChange: EventEmitter<number> = new EventEmitter <number>();


    onValueChange(event) {
        this.value = event.target.value;
        this.valueChange.emit(this.value);
    }
}