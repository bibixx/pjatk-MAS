package mp3.MultiInheritance;

import java.util.List;

public interface IDessertDish {
	public void addSauce(Sauce sideDish);
	
	public List<Sauce> getSauces();
}
