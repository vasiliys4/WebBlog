import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule,HTTP_INTERCEPTORS } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './identityComponent/auth.guard';

import { AuthInterceptor } from './identityComponent/auth.interceptor';
import { AppComponent } from './app.component';
import { PostListComponent } from './post-list.component';
import { PostSingleComponent } from './post-single.component';
import { PostCreateComponent } from './post-create.component';
import { PostFormComponent } from './post-form.component';
import { PostEditComponent } from './post-edit.component';
import { NotFoundComponent } from './not-found.component';
import { LayoutComponent } from "./app.layout-component";

import { DataService } from './data.service';


// определение маршрутов
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  imports: [BrowserModule, FormsModule, HttpClientModule,RouterModule,AppRoutingModule],
  exports: [RouterModule],
  declarations: [AppComponent,
    LayoutComponent,
    PostListComponent,
    PostSingleComponent,
    PostCreateComponent,
    PostFormComponent,
    PostEditComponent,
    NotFoundComponent,],
  providers: [DataService, AuthInterceptor], // регистрация сервисов
  bootstrap: [AppComponent]
})
export class AppModule { }
