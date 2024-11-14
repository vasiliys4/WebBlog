import { NgModule, createComponent } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { PostListComponent } from './post-list.component';
import { PostSingleComponent } from './post-single.component';
import { PostCreateComponent } from './post-create.component';
import { PostFormComponent } from './post-form.component';
import { PostEditComponent } from './post-edit.component';
import { NotFoundComponent } from './not-found.component';

import { DataService } from './data.service';


// определение маршрутов
const appRoutes: Routes = [
  { path: '', component: PostListComponent },
  { path: 'post/:id', component: PostSingleComponent },
  { path: 'create', component: PostCreateComponent },
  { path: '**', component: NotFoundComponent },
  { path: 'edit/:id', component: PostEditComponent }
];

@NgModule({
  imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
  declarations: [AppComponent, PostListComponent, PostSingleComponent, PostCreateComponent, PostFormComponent, PostEditComponent, NotFoundComponent],
  providers: [DataService], // регистрация сервисов
  bootstrap: [AppComponent]
})
export class AppModule { }
