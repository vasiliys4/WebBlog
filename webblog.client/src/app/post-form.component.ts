import { Component, Input } from '@angular/core';
import { Post } from './post';
import { FormsModule, NgModel } from "@angular/forms";
@Component({
  selector: "post-form",
  templateUrl: './post-form.component.html'
})
export class PostFormComponent {
  @Input() post: Post;
}
