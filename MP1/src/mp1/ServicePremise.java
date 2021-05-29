package mp1;


import java.time.LocalDate;
import java.util.List;

public class ServicePremise extends Property {
	private static final long serialVersionUID = 4033274253884308858L;

	private static float defaultTax = 8.05f;
	
	private float tax;

	public ServicePremise(Address address, float area, LocalDate finishedBuildingDate, List<String> ownersPhoneNumbers, float tax) throws Exception {
		super(address, area, finishedBuildingDate, ownersPhoneNumbers);
		
		this.tax = tax;
	}
	
	public ServicePremise(Address adress, float area, LocalDate finishedBuildingDate, List<String> ownersPhoneNumbers) throws Exception {
		this(adress, area, finishedBuildingDate, ownersPhoneNumbers, ServicePremise.defaultTax);
	}
	
	@Override
	public float calculateProperyTax() {
		return this.area * this.tax;
	}
}
