package presentation;

import business.BookStoreService;
import business.BookStoreServiceImpl;
import data.BookRepository;
import data.BookRepositoryImpl;
import data.DatabaseManager;
import models.Book;

import java.util.List;
import java.util.Scanner;

public class BookStoreApp {
    private static BookStoreService bookStoreService;

    public static void main(String[] args) {
	DatabaseManager databaseManager = new DatabaseManager();
	databaseManager.createBookTable();

	try {
	    BookRepository bookRepository = new BookRepositoryImpl();
	    bookStoreService = new BookStoreServiceImpl(bookRepository);

	    Scanner scanner = new Scanner(System.in);
	    boolean running = true;

	    while (running) {
		System.out.println("1. Просмотреть все книги");
		System.out.println("2. Просмотреть книгу по ID");
		System.out.println("3. Добавить книгу");
		System.out.println("4. Обновить информацию о книге");
		System.out.println("5. Удалить книгу");
		System.out.println("6. Выйти");

		System.out.print("Выберите действие: ");
		int choice = scanner.nextInt();
		scanner.nextLine();

		switch (choice) {
		case 1:
		    displayAllBooks();
		    break;
		case 2:
		    displayBookById(scanner);
		    break;
		case 3:
		    addBook(scanner);
		    break;
		case 4:
		    updateBook(scanner);
		    break;
		case 5:
		    deleteBook(scanner);
		    break;
		case 6:
		    running = false;
		    break;
		default:
		    System.out.println("Неверный выбор. Попробуйте снова.");
		}
	    }
	} finally {
	    databaseManager.closeConnection();
	}
    }

    private static void displayAllBooks() {
	List<Book> books = bookStoreService.getAllBooks();
	for (Book book : books) {
	    System.out.println(book);
	}
    }

    private static void displayBookById(Scanner scanner) {
	System.out.print("Введите ID книги: ");
	int id = scanner.nextInt();
	scanner.nextLine();

	Book book = bookStoreService.getBookById(id);
	if (book != null) {
	    System.out.println(book);
	} else {
	    System.out.println("Книга не найдена");
	}
    }

    private static void addBook(Scanner scanner) {
	System.out.print("Введите название книги: ");
	String title = scanner.nextLine();
	System.out.print("Введите автора книги: ");
	String author = scanner.nextLine();
	System.out.print("Введите цену книги: ");
	double price = scanner.nextDouble();

	Book newBook = new Book(0, title, author, price);
	bookStoreService.addBook(newBook);
	System.out.println("Книга добавлена");
    }

    private static void updateBook(Scanner scanner) {
	System.out.print("Введите ID книги, которую хотите обновить: ");
	int id = scanner.nextInt();
	scanner.nextLine();

	Book existingBook = bookStoreService.getBookById(id);
	if (existingBook != null) {
	    System.out.print("Введите новое название книги: ");
	    String title = scanner.nextLine();
	    System.out.print("Введите нового автора книги: ");
	    String author = scanner.nextLine();
	    System.out.print("Введите новую цену книги: ");
	    double price = scanner.nextDouble();

	    existingBook.setTitle(title);
	    existingBook.setAuthor(author);
	    existingBook.setPrice(price);

	    bookStoreService.updateBook(existingBook);
	    System.out.println("Книга обновлена");
	} else {
	    System.out.println("Книга не найдена");
	}
    }

    private static void deleteBook(Scanner scanner) {
	System.out.print("Введите ID книги, которую хотите удалить: ");
	int id = scanner.nextInt();
	scanner.nextLine();

	Book existingBook = bookStoreService.getBookById(id);
	if (existingBook != null) {
	    bookStoreService.deleteBook(id);
	    System.out.println("Книга удалена");
	} else {
	    System.out.println("Книга не найдена");
	}
    }
}
