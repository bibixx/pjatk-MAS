package mp2;

public class RecipeStep {
	String description;

	private Recipe recipe;
	
	private RecipeStep(String description) {
		this.setDescription(description);
	}
	
	public static RecipeStep createStep(Recipe recipe, String description) throws Exception {
		if (recipe == null) {
			throw new Exception("No recipe provided when constructing recipe step");
		}
		
		RecipeStep step = new RecipeStep(description);
		recipe.addStep(step);
		
		step.setRecipe(recipe);
		
		return step;
	}
	
	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public Recipe getRecipe() {
		return recipe;
	}

	public void setRecipe(Recipe recipe) throws Exception {
		if (recipe == null) {
			throw new Exception("No recipe provided when constructing recipe step");
		}

		if (this.recipe != null) {
			return;
		}

		this.recipe = recipe;
	}
	
	public void removeRecipe() {
		if (this.recipe == null) {
			return;
		}

		this.recipe.removeStep(this);
		this.recipe = null;
	}
}
