package mp2;

import java.util.HashMap;
import java.util.Map;

public class Book {
	private Map<Integer, Recipe> recipes = new HashMap<>();
	
	private String title;
	
	private Publisher publisher;
	
	public Book(String title) {
		this.setTitle(title);
	}
	
	public void addRecipe(Integer pageNumber, Recipe recipe) {
		this.recipes.put(pageNumber, recipe);
		recipe.setBook(this);
	}
	
	public Recipe getRecipe(Integer pageNumber) {
		return this.recipes.get(pageNumber);
	}
	
	public Map<Integer, Recipe> getRecipes() {
		return this.recipes;
	}
	
	public Publisher getPublisher() {
		return publisher;
	}

	public void setPublisher(Publisher publisher) {
		if (this.publisher != null) {
			return;
		}

		this.publisher = publisher;
		publisher.addBook(this);
	}
	
	public void removePublisher() {
		if (this.publisher == null) {
			return;
		}

		this.publisher.removeBook(this);
		this.publisher = null;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

}
