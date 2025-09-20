import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from './data.service';
import { Post } from './post';

@Component({
  templateUrl: './post-edit.component.html',
  providers: [DataService]
})
export class PostEditComponent implements OnInit {

  id: number;
  post: Post;    // изменяемый объект
  loaded: boolean = false;

  constructor(private dataService: DataService, private router: Router, activeRoute: ActivatedRoute) {
    this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
  }

  ngOnInit() {
    if (this.id) {
      this.dataService.getPost(this.id)
        .subscribe({
          next: (data: Post) => {
            console.log('Получен пост:', data);
            this.post = data;
            this.loaded = !!this.post;
          },
          error: err => {
            console.error('Ошибка загрузки поста', err);
          }
        });
    }
  }

  save() {
    if (!this.loaded || !this.post) {
      console.error('Данные поста ещё не загружены.');
      return;
    }

    this.dataService.editPost(this.post, this.id)
      .subscribe(() => this.router.navigateByUrl("/"));
  }
}
