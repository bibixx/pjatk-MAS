package mp3.MultiInheritance;

import java.util.ArrayList;
import java.util.List;

public class DessertDish extends Dish implements IDessertDish {
	private List<Sauce> sauces = new ArrayList<>(); 

	public DessertDish(String name, float price) {
		super(name, price);
	}

	@Override
	public void addSauce(Sauce sauce) {
		this.sauces.add(sauce);
	}
	
	public List<Sauce> getSauces() {
		return this.sauces;
	}
}
