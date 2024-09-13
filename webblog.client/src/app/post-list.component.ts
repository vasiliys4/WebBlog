import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Post } from './post';
import { Observable } from 'rxjs';

@Component({
  templateUrl: './post-list.component.html',
  providers: [DataService]
})
export class PostListComponent implements OnInit {

  public posts?: Post[];
  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.load();
  }
  load() {
    this.dataService.getPosts().subscribe((data : Post[]) => this.posts = data);
  }
}
