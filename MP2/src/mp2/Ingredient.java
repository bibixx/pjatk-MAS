package mp2;

public class Ingredient {
	private String name;
	private String methodOfMeasurement;
	private RecipeIngredient recipeIngredient;
	
	public Ingredient(String name, String methodOfMeasurement) {
		this.setName(name);
		this.setMethodOfMeasurement(methodOfMeasurement);
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getMethodOfMeasurement() {
		return methodOfMeasurement;
	}

	public void setMethodOfMeasurement(String methodOfMeasurement) {
		this.methodOfMeasurement = methodOfMeasurement;
	}
	

	public RecipeIngredient getRecipeIngredient() {
		return recipeIngredient;
	}

	public void setRecipeIngredient(RecipeIngredient recipeIngredient) {
		if (this.recipeIngredient != null) {
			return;
		}

		this.recipeIngredient = recipeIngredient;
		recipeIngredient.setIngredient(this);
	}
	
	public void removeRecipeIngredient() {
		if (this.recipeIngredient == null) {
			return;
		}

		this.recipeIngredient.remove();
		this.recipeIngredient = null;
	}
}
