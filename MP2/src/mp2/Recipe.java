package mp2;

import java.util.ArrayList;
import java.util.List;

public class Recipe {
	private static List<Recipe> allRecipies = new ArrayList<>();
	
	private Book book;
	private List<RecipeStep> steps;
	private String description;
	
	private RecipeIngredient recipeIngredient;
	
	public Recipe(String description) {
		this.setDescription(description);
		this.steps = new ArrayList<>();
		
		Recipe.allRecipies.add(this);
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public List<RecipeStep> getSteps() {
		return steps;
	}
	
	public void addStep(RecipeStep step) throws Exception {
		if (Recipe.allRecipies.stream().anyMatch(recipe -> recipe.getSteps().contains(step))) {
			throw new Exception("This step already exists in another recipe");
		}
		
		this.steps.add(step);
	}
	
	public void removeStep(RecipeStep step) {
		if (!this.steps.contains(step)) {
			return;
		}

        this.steps.remove(step);
 
        step.removeRecipe();
	}

	public Book getBook() {
		return book;
	}

	public void setBook(Book book) {
		if (this.book != null) {
			return;
		}

		this.book = book;
	}

	public RecipeIngredient getRecipeIngredient() {
		return recipeIngredient;
	}

	public void setRecipeIngredient(RecipeIngredient recipeIngredient) {
		if (this.recipeIngredient != null) {
			return;
		}

		this.recipeIngredient = recipeIngredient;
		recipeIngredient.setRecipe(this);
	}
	
	public void removeRecipeIngredient() {
		if (this.recipeIngredient == null) {
			return;
		}

		this.recipeIngredient.remove();
		this.recipeIngredient = null;
	}
}
