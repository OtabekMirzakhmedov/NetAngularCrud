import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { BookService } from '../../services/book.service';
import { AppState } from '../../store/app.state';
import * as bookActions from './../../store/book.actions';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

    public books: Book[];
    public books$: Observable<any>;

    constructor(private store: Store<AppState>, private router: Router) {
        this.books$ = this.store.select("applicationState");
}

    ngOnInit() {

        /*this.service.getAllBooks().subscribe(data => { this.books = data; })*/
        this.store.dispatch(new bookActions.loadBooksAction());
        this.books$.subscribe((state: AppState) => this.books = state.books);
    }

    showBook(id: number) {
        this.router.navigate(["/show-book/" + id]);
    }

    updateBook(id: number) {
        this.router.navigate(["/update-book/" + id]);
    }

    deleteBook(id: number) {
        this.router.navigate(["/delete-book/" + id]);
    }
}
