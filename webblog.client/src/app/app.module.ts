import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { PostListComponent } from './post-list.component';
import { PostSingleComponent } from './post-single.component';

import { DataService } from './data.service';

// определение маршрутов
const appRoutes: Routes = [
  { path: '', component: PostListComponent },
  { path: 'post/:id', component: PostSingleComponent },
];

@NgModule({
  imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
  declarations: [AppComponent, PostListComponent, PostSingleComponent],
  providers: [DataService], // регистрация сервисов
  bootstrap: [AppComponent]
})
export class AppModule { }
