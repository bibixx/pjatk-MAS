package mp1;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public abstract class Property implements Serializable {
	private static List<Property> extent = new ArrayList<>(); 
	
	public static void saveExtent(ObjectOutputStream stream) throws IOException {
		stream.writeObject(extent);
	}
	
	@SuppressWarnings("unchecked")
	public static void loadExtent(ObjectInputStream stream) throws IOException, ClassNotFoundException {
		extent = (List<Property>) stream.readObject();
	}
	
	public static List<Property> getExtent() {
		return extent;
	}
	
	private static final long serialVersionUID = -2677340161119285435L;

	private LocalDate finishedBuildingDate;
	protected float area;
	private List<String> ownersPhoneNumbers;
	private Address address;
	
	public Property(Address address, float area, LocalDate finishedBuildingDate, List<String> ownersPhoneNumbers) throws Exception {
		this.setOwnersPhoneNumbers(ownersPhoneNumbers);
		
		this.address = address;
		this.area = area;
		this.finishedBuildingDate = finishedBuildingDate;
		this.ownersPhoneNumbers = ownersPhoneNumbers;
		
		extent.add(this);
	}
	
	public abstract float calculateProperyTax();
	
	public int getPropertyAge() {
		LocalDate today = LocalDate.now();

		return today.getYear() - this.finishedBuildingDate.getYear();
	}
	
	public static float calculateAveragePropertyAge() {
		float sum = 0;
		
		for (var property : extent) {
			sum += property.getPropertyAge();
		}
		
		return sum / extent.size();
	}

	public LocalDate getFinishedBuildingDate() {
		return finishedBuildingDate;
	}

	public void setFinishedBuildingDate(LocalDate finishedBuildingDate) {
		this.finishedBuildingDate = finishedBuildingDate;
	}

	public float getArea() {
		return area;
	}

	public void setArea(float area) {
		this.area = area;
	}

	public List<String> getOwnersPhoneNumbers() {
		return ownersPhoneNumbers;
	}

	public void setOwnersPhoneNumbers(List<String> ownersPhoneNumbers) throws Exception {
		if (ownersPhoneNumbers.size() == 0) {
			throw new Exception("Property has to have at least one owner's phone number.");
		}

		this.ownersPhoneNumbers = ownersPhoneNumbers;
	}

	public Address getAddress() {
		return address;
	}

	public void setAddress(Address address) {
		this.address = address;
	}
}
