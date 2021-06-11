package mp3.MultiInheritance;

import java.util.ArrayList;
import java.util.List;

public class Crepes extends LunchDish implements IDessertDish {
	private List<Sauce> sauces = new ArrayList<>(); 

	public Crepes(String name, float price) {
		super(name, price);
	}

	@Override
	public void addSauce(Sauce sauce) {
		this.sauces.add(sauce);
	}

	@Override
	public List<Sauce> getSauces() {
		return this.sauces;
	}
}
