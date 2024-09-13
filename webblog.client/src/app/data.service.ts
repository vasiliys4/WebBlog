import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Post } from './post';
import { Observable } from 'rxjs';
 
@Injectable()
export class DataService {
 
  private url = 'https://localhost:7236/api/home';
 
    constructor(private https: HttpClient) {
  }
  getPost(id: number) : Observable<Post> {
    return this.https.get<Post>(this.url + '/' + id);
  }
  getPosts(): Observable<Post[]> {
    return this.https.get<Post[]>(this.url);
  }
  createPost(post: Post) {
    return this.https.post(this.url, post);
  }
  updatePost(post: Post) {

    return this.https.put(this.url, post);
  }
  deletePost(id: number) {
    return this.https.delete(this.url + '/' + id);
  }
}
