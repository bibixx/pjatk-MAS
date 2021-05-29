package mp2;

public class RecipeIngredient {
	private Recipe recipe;
	
	private Ingredient ingredient;
	
	private float amount;
	
	public RecipeIngredient(Recipe recipe, Ingredient ingredient, float amount) {
		this.setRecipe(recipe);
		this.setIngredient(ingredient);
		this.amount = amount;
	}
	
	public float getAmount() {
		return amount;
	}

	public void setAmount(float amount) {
		this.amount = amount;
	}

	public Recipe getRecipe() {
		return recipe;
	}

	public void setRecipe(Recipe recipe) {
		if (this.recipe != null) {
			return;
		}

		this.recipe = recipe;
		this.recipe.setRecipeIngredient(this);
	}
	
	public void remove() {
		this.removeRecipe();
		this.removeIngredient();
	}
	
	public void removeRecipe() {
		if (this.recipe == null) {
			return;
		}

		this.recipe.removeRecipeIngredient();
		this.recipe = null;
	}

	public Ingredient getIngredient() {
		return ingredient;
	}

	public void setIngredient(Ingredient ingredient) {
		if (this.ingredient != null) {
			return;
		}

		this.ingredient = ingredient;
		this.ingredient.setRecipeIngredient(this);
	}
	
	public void removeIngredient() {
		if (this.ingredient == null) {
			return;
		}

		this.ingredient.removeRecipeIngredient();
		this.ingredient = null;
	}
}
