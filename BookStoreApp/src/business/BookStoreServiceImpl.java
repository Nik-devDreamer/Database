package business;

import data.BookRepository;
import models.Book;

import java.util.List;

public class BookStoreServiceImpl implements BookStoreService {
    private BookRepository bookRepository;

    public BookStoreServiceImpl(BookRepository bookRepository) {
	this.bookRepository = bookRepository;
    }

    @Override
    public List<Book> getAllBooks() {
	return bookRepository.getAllBooks();
    }

    @Override
    public Book getBookById(int id) {
	return bookRepository.getBookById(id);
    }

    @Override
    public void addBook(Book book) {
	bookRepository.addBook(book);
    }

    @Override
    public void updateBook(Book book) {
	bookRepository.updateBook(book);
    }

    @Override
    public void deleteBook(int id) {
	bookRepository.deleteBook(id);
    }
}