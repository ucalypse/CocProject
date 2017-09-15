import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { MemberListComponent } from './members/member-list.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  imports:      [ BrowserModule, AppRoutingModule],
  declarations: [ AppComponent , MemberListComponent],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
