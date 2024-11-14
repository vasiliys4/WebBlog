import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from './data.service';
import { Post } from './post';

@Component({
  templateUrl: './post-create.component.html',
  providers: [DataService],
})
export class PostCreateComponent {

  post: Post = new Post();    // добавляемый объект
  constructor(private dataService: DataService, private router: Router) { }
  save() {
    this.dataService.createPost(this.post).subscribe(data => this.router.navigateByUrl("/"));
  }
}
