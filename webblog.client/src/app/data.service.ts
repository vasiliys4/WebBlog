import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Post } from './post';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { MessageService } from './message.service';

@Injectable({ providedIn: 'root' })
export class DataService {

  private url = 'https://localhost:7236/api/home';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private https: HttpClient, private messageService: MessageService) {
  }
  getPost(id: number) : Observable<Post> {
   return this.https.get<Post>(this.url + '/' + id);
  }
  getPosts(): Observable<Post[]> {
    return this.https.get<Post[]>(this.url).pipe(tap(_ => this.log('fetched posts')), catchError(this.handleError<Post[]>('getPosts', [])));
  }
  createPost(post: Post) {
    return this.https.post(this.url, post);
  }
  editPost(post: Post, id: number) {
    return this.https.patch(this.url + '/' + id, post, this.httpOptions);
  }
  deletePost(id: number): Observable<Post> {
    return this.https.delete<Post>(this.url + '/' + id);
  }
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
  private log(message: string) {
    this.messageService.add(`HeroService: ${message}`);
  }
}
