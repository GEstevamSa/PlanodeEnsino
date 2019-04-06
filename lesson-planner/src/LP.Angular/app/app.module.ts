import { NgModule } from '@angular/core';

import * as AngularModule from './app.submodule.angular';
import * as ComponentsModule from './app.submodule.components';
import * as ProvidersModule from './app.submodule.providers';
import * as ThirdModule from './app.submodule.thirdpart';

import { AppRoutingModule } from './app-routing.module';


@NgModule({
  declarations: [
    ComponentsModule.AppComponent
  ],
  imports: [
    AngularModule.BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [ComponentsModule.AppComponent]
})
export class AppModule { }
