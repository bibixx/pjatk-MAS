package mp2;

import java.util.Arrays;

public class Main {
	public static String getH1(String text) {
		return "\u001b[1;32m" + text + "\u001b[0m";
	}
	
	public static String getH2(String text) {
		return "\u001b[1;36m" + text + "\u001b[0m";
	}
	
	public static String getIndent(String text) {
		return "  " + text;
	}
	
	
	public static void main(String[] args) throws Exception {
		System.out.println(getH1("Asocjacja „Zwykła”"));
		var publisher1 = new Publisher("Publisher name 1");
		var book1 = new Book("Book title 1");
		
		publisher1.addBook(book1);
		
		System.out.println(getH2("Połączenie zwrotne"));
		System.out.println(getIndent(Arrays.toString(publisher1.getBooks().stream().map(book -> book.getTitle()).toArray())));
		System.out.println(getIndent(book1.getPublisher().getPublisherName()));
		
		System.out.println(getH1("\nKompozycja"));
		var recipe1 = new Recipe("Recipe #1");
		var step1 = RecipeStep.createStep(recipe1, "Step #1 (R1)");
		
		var recipe2 = new Recipe("Recipe #2");
		RecipeStep.createStep(recipe2, "Step #1 (R2)");
		
		try {
			recipe2.addStep(step1);
		} catch (Exception e) {
			System.out.println("  Expected error: " + e.getMessage());
		}
		
		try {
			RecipeStep.createStep(null, "Step #2");
		} catch (Exception e) {
			System.out.println("  Expected error: " + e.getMessage());
		}
		
		System.out.println(getH2("Połączenie zwrotne"));
		System.out.println(getIndent(Arrays.toString(recipe1.getSteps().stream().map(step -> step.getDescription()).toArray())));
		System.out.println(getIndent(step1.getRecipe().getDescription()));
		
		System.out.println(getH1("\nAsocjacja kwalifikowana"));
		book1.addRecipe(0, recipe1);
		book1.addRecipe(1, recipe2);
		
		System.out.println(
			getIndent(Arrays.toString(
				book1
					.getRecipes()
					.entrySet()
					.stream()
					.map(recipe -> recipe.getKey() + ": " + recipe.getValue().getDescription())
					.toArray()
			))
		);

		System.out.println(getH2("Połączenie zwrotne"));
		System.out.println(getIndent(recipe1.getBook().getTitle()));
		System.out.println(getIndent(recipe2.getBook().getTitle()));
		
		System.out.println(getH1("\nAsocjacja z atrybutem"));
		var ingredient1 = new Ingredient("Ingredient #1", "Cup");
		var recipeIngredient = new RecipeIngredient(recipe1, ingredient1, 0.5f);
		
		System.out.println(getIndent(recipeIngredient.getIngredient().getName()));
		System.out.println(getIndent(recipeIngredient.getRecipe().getDescription()));
		
		System.out.println(getH2("Połączenie zwrotne"));
		System.out.println(getIndent(recipe1.getRecipeIngredient().getIngredient().getName()));
		System.out.println(getIndent(ingredient1.getRecipeIngredient().getRecipe().getDescription()));
	}
}
