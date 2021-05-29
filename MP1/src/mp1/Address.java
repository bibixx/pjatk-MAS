package mp1;

import java.io.Serializable;

public class Address implements Serializable {
	private static final long serialVersionUID = 112114175274845037L;

	private String streetName;
	private String streetNumber;
	private String apartmentNumber = null;
	
	public Address(String street, String streetNumber, String apartmentNumber) {
		this.streetName = street;
		this.streetNumber = streetNumber;
		this.apartmentNumber = apartmentNumber;
	}
	
	public Address(String street, String streetNumber) {
		this.streetName = street;
		this.streetNumber = streetNumber;
	}
	
	public String toString() {
		if (this.apartmentNumber == null) {
			return String.format("ul. %s %s", this.streetName, this.streetNumber);
		}
		
		return String.format("ul. %s %s/%s", this.streetName, this.streetNumber, this.apartmentNumber);
	}

	public String getStreetName() {
		return streetName;
	}

	public void setStreetName(String streetName) {
		this.streetName = streetName;
	}

	public String getStreetNumber() {
		return streetNumber;
	}

	public void setStreetNumber(String streetNumber) {
		this.streetNumber = streetNumber;
	}

	public String getApartmentNumber() {
		return apartmentNumber;
	}

	public void setApartmentNumber(String apartmentNumber) {
		this.apartmentNumber = apartmentNumber;
	}
}
