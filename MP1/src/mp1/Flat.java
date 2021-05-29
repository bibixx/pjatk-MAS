package mp1;


import java.time.LocalDate;
import java.util.List;

public class Flat extends Property {
	private static float tax = 0.81f;
	
	private static final long serialVersionUID = 5688857236437130848L;

	public Flat(Address address, float area, LocalDate finishedBuildingDate, List<String> ownersPhoneNumbers) throws Exception {
		super(address, area, finishedBuildingDate, ownersPhoneNumbers);
	}
	
	@Override
	public float calculateProperyTax() {
		return this.area * Flat.tax;
	}
}
