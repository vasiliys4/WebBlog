import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Post } from './post';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss'],
  providers: [DataService],
})
export class PostListComponent implements OnInit {

  public posts?: Post[];
  statusMessage: string = "";
  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.load();
  }
  load() {
    this.dataService.getPosts().subscribe((data: Post[]) => this.posts = data);
  }
  delete(id?: number) {
    this.dataService.deletePost(id!).subscribe(_ => {
      this.statusMessage = "Данные успешно удалены"
        this.load();
    });
  }
}
