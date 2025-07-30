import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from './data.service';
import { Post } from './post';

@Component({
  templateUrl: './post-edit.component.html'
})
export class PostEditComponent implements OnInit {

  id: number;
  post: Post;    // изменяемый объект
  loaded: boolean = false;

  constructor(private dataService: DataService, private router: Router, activeRoute: ActivatedRoute) {
    this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
  }

  ngOnInit() {
    if (this.id)
      this.dataService.getPost(this.id)
        .subscribe((data: Post) => {
          this.post = data;
          if (this.post != null) this.loaded = true;
        });
  }

  save() {
    this.dataService.editPost(this.post).subscribe(data => this.router.navigateByUrl("/"));
  }
}
