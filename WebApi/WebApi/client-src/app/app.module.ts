import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { FormElementComponent } from './form-elem.component';
import { FormComponent } from './form';
import { FormService } from './form.service';

@NgModule({
    declarations: [
        AppComponent,
        FormComponent,
        FormElementComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    providers: [FormService],
    bootstrap: [AppComponent]
})
export class AppModule { }