import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PostListComponent } from './post-list.component';
import { PostSingleComponent } from './post-single.component';
import { PostCreateComponent } from './post-create.component';
import { PostEditComponent } from './post-edit.component';
import { AppLoginComponent } from './identityComponent/app.login-component';
import { NotFoundComponent } from './not-found.component';
import {AuthGuard} from "./identityComponent/auth.guard";
import {AppRegisterComponent} from "./identityComponent/app.register-component";

const routes: Routes = [
  { path: '', component: PostListComponent, pathMatch: 'full', canActivate: [AuthGuard] },  // главная страница — список постов
  { path: 'post/:id', component: PostSingleComponent },
  { path: 'create', component: PostCreateComponent },
  { path: 'edit/:id', component: PostEditComponent },
  {path: 'register', component: AppRegisterComponent},
  { path: 'login', component: AppLoginComponent },
  { path: '**', component: NotFoundComponent } // перехватчик неизвестных маршрутов — всегда в конце!
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
