package data;

import models.Book;

import java.util.ArrayList;
import java.util.List;
import java.sql.*;

public class BookRepositoryImpl implements BookRepository {
    private static final String DATABASE_URL = "jdbc:sqlite:bookstore.db";
    private Connection connection;

    public BookRepositoryImpl() {
	try {
	    connection = DriverManager.getConnection(DATABASE_URL);
	} catch (SQLException e) {
	    e.printStackTrace();
	}
    }

    @Override
    public List<Book> getAllBooks() {
	List<Book> books = new ArrayList<>();
	try (Statement statement = connection.createStatement();
		ResultSet resultSet = statement.executeQuery("SELECT * FROM books")) {

	    while (resultSet.next()) {
		int id = resultSet.getInt("id");
		String title = resultSet.getString("title");
		String author = resultSet.getString("author");
		double price = resultSet.getDouble("price");
		books.add(new Book(id, title, author, price));
	    }
	} catch (SQLException e) {
	    e.printStackTrace();
	}
	return books;
    }

    @Override
    public Book getBookById(int id) {
	try (PreparedStatement statement = connection.prepareStatement("SELECT * FROM books WHERE id = ?")) {
	    statement.setInt(1, id);
	    ResultSet resultSet = statement.executeQuery();

	    if (resultSet.next()) {
		String title = resultSet.getString("title");
		String author = resultSet.getString("author");
		double price = resultSet.getDouble("price");
		return new Book(id, title, author, price);
	    }
	} catch (SQLException e) {
	    e.printStackTrace();
	}
	return null;
    }

    @Override
    public void addBook(Book book) {
	try (PreparedStatement statement = connection
		.prepareStatement("INSERT INTO books (title, author, price) VALUES (?, ?, ?)")) {
	    statement.setString(1, book.getTitle());
	    statement.setString(2, book.getAuthor());
	    statement.setDouble(3, book.getPrice());
	    statement.executeUpdate();
	} catch (SQLException e) {
	    e.printStackTrace();
	}
    }

    @Override
    public void updateBook(Book book) {
	try (PreparedStatement statement = connection
		.prepareStatement("UPDATE books SET title = ?, author = ?, price = ? WHERE id = ?")) {
	    statement.setString(1, book.getTitle());
	    statement.setString(2, book.getAuthor());
	    statement.setDouble(3, book.getPrice());
	    statement.setInt(4, book.getId());
	    statement.executeUpdate();
	} catch (SQLException e) {
	    e.printStackTrace();
	}
    }

    @Override
    public void deleteBook(int id) {
	try (PreparedStatement statement = connection.prepareStatement("DELETE FROM books WHERE id = ?")) {
	    statement.setInt(1, id);
	    statement.executeUpdate();
	} catch (SQLException e) {
	    e.printStackTrace();
	}
    }
}