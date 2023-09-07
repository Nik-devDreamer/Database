package data;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

public class DatabaseManager {
    private static final String DATABASE_URL = "jdbc:sqlite:BookStore.db";
    private Connection connection;

    public DatabaseManager() {
	try {
	    connection = DriverManager.getConnection(DATABASE_URL);
	    System.out.println("Подключился к базе данных");
	} catch (SQLException e) {
	    System.err.println("Ошибка подключения к базе данных: " + e.getMessage());
	}
    }

    public void createBookTable() {
	String query = "CREATE TABLE IF NOT EXISTS books (id INTEGER PRIMARY KEY, title TEXT, author TEXT, price REAL)";
	try (Statement statement = connection.createStatement()) {
	    statement.executeUpdate(query);
	} catch (SQLException e) {
	    System.err.println("Ошибка создания таблицы книг: " + e.getMessage());
	}
    }

    public void closeConnection() {
	try {
	    if (connection != null) {
		connection.close();
		System.out.println("Соединение с базой данных закрыто");
	    }
	} catch (SQLException e) {
	    System.err.println("Ошибка закрытия соединения с базой данных: " + e.getMessage());
	}
    }
}
