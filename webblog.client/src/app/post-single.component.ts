import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from './data.service';
import { Post } from './post';
 
@Component({
  templateUrl: './post-single.component.html',
  providers: [DataService]
})
export class PostSingleComponent implements OnInit {

  id: number;
  post: Post;

  constructor(private dataService: DataService, activeRoute: ActivatedRoute) {
    this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
  }

  ngOnInit() {
    if (this.id)
      this.dataService.getPost(this.id).subscribe((data: Post) => this.post = data);
  }
}
