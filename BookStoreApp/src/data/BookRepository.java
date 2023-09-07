package data;

import models.Book;

import java.util.List;

public interface BookRepository {
    List<Book> getAllBooks();

    Book getBookById(int id);

    void addBook(Book book);

    void updateBook(Book book);

    void deleteBook(int id);
}
