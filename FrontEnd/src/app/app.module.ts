import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table'; 

import { AppComponent } from './app.component';
import { ClientiComponent } from './clienti/clienti.component';
import { NotaiComponent } from './notai/notai.component';
import { ImmobiliComponent } from './immobili/immobili.component';
import { AttiComponent } from './atti/atti.component';

//httpclient
import { HttpClientModule } from '@angular/common/http';

//routing
import { RouterModule } from '@angular/router';
import { AppRoutes } from './routes';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    ClientiComponent,
    NotaiComponent,
    ImmobiliComponent,
    AttiComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule,
    HttpClientModule,
    MatSelectModule,
    MatTableModule,
    RouterModule.forRoot(AppRoutes),
    BrowserAnimationsModule // installazione delle regole di routing

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
