package mp3.MultiInheritance;

import java.util.ArrayList;
import java.util.List;

public class LunchDish extends Dish {
	private List<SideDish> sideDishes = new ArrayList<>(); 
	
	public LunchDish(String name, float price) {
		super(name, price);
	}

	public void addSideDish(SideDish sideDish) {
		this.sideDishes.add(sideDish);
	}
	
	public List<SideDish> getSideDishes() {
		return this.sideDishes;
	}
}
