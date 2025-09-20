import { Component, Input } from '@angular/core';
import { Post } from './post';
@Component({
  selector: "post-form",
  templateUrl: './post-form.component.html'
})
export class PostFormComponent {
  @Input() post: Post;
}
