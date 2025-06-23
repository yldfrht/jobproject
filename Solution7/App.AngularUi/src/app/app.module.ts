import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RandevuComponent } from './randevu/randevu.component';
import { ListRandevuComponent } from './randevu/list-randevu/list-randevu.component';
import { AddEditRandevuComponent } from './randevu/add-edit-randevu/add-edit-randevu.component';

@NgModule({
  declarations: [
    AppComponent,
    RandevuComponent,
    ListRandevuComponent,
    AddEditRandevuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
