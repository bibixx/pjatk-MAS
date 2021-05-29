package mp2;

import java.util.ArrayList;
import java.util.List;

public class Publisher {
	private List<Book> books = new ArrayList<>();
	
	private String publisherName;
	
	public Publisher(String publisherName) {
		this.setPublisherName(publisherName); 
	}
	
	public void addBook(Book book) {
		if (this.books.contains(book)) {
			return;
		}

		this.books.add(book);
		book.setPublisher(this);
	}
	
	public void removeBook(Book book) {
		if (!this.books.contains(book)) {
			return;
		}

        this.books.remove(book);
 
        book.removePublisher();
	}
	
	public List<Book> getBooks() {
		return this.books;
	}

	public String getPublisherName() {
		return publisherName;
	}

	public void setPublisherName(String publisherName) {
		this.publisherName = publisherName;
	}
}
