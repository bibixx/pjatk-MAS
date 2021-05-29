package mp1;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Scanner;

public class Main {
	static String fileName = "/tmp/properties";

	@SuppressWarnings("resource")
	public static void main(String[] args) throws FileNotFoundException, IOException, ClassNotFoundException {
		while (true) {
			try {
				System.out.println("====================");
				System.out.println("1) Load Extents");
		        System.out.println("2) Create Properties");
		        System.out.println("3) Save Extents");
		        System.out.println("4) Print ages");
		        System.out.println("5) Create Property without an owner");
		        System.out.println("6) Print average age");
		        System.out.println("7) Print extent length");
		        System.out.println("8) Print taxes");
		        
		        System.out.println("0) Exit");
		        
				Scanner in = new Scanner(System.in);
		        String s = in.nextLine();
		        
				switch (s) {
					case "1":
						loadExtents();
						break;
					case "2":
						createProperties();
						break;
					case "3":
						saveExtents();
						break;
					case "4":
						printAges();
						break;
					case "5":
						createPropertyWithNoOwners();
						break;
					case "6":
						printAverageAges();
						break;
					case "7":
						printExtentLength();
						break;
					case "8":
						printTaxes();
						break;
					case "0":
						System.exit(0);
						break;
					default:
						System.out.println("Unkown option " + s);
						break;
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
	}
	
	private static void createProperties() throws Exception {
		var owner1 = "100 123 234";
		var owner2 = "200 123 234";
		var owner3 = "300 123 234";
		var owner4 = "400 123 234";
		
		var flat1Owners = new ArrayList<String>(); 
		flat1Owners.add(owner1);
		flat1Owners.add(owner2);
		new Flat(
			new Address("Chemiczna", "12", "1B"),
			100,
			LocalDate.of(2008, 6, 7),
			flat1Owners
		);

		var servicePremise1Owners = new ArrayList<String>(); 
		servicePremise1Owners.add(owner3);
		servicePremise1Owners.add(owner4);
		new ServicePremise(
			new Address("Oryszewska", "48"),
			75,
			LocalDate.of(1990, 2, 13),
			servicePremise1Owners
		);
		

		var servicePremise2Owners = new ArrayList<String>(); 
		servicePremise2Owners.add(owner1);
		servicePremise2Owners.add(owner3);
		new ServicePremise(
			new Address("Czajkowskiego Piotra", "139", "2"),
			30,
			LocalDate.of(2020, 1, 2),
			servicePremise2Owners,
			48
		);
	}

	private static void createPropertyWithNoOwners() throws Exception {
		new Flat(
			new Address("Testowa", "1"),
			100,
			LocalDate.now(),
			new ArrayList<String>()
		);
	}
	
	private static void saveExtents() throws FileNotFoundException, IOException {
		var stream = new ObjectOutputStream(new FileOutputStream(fileName));
		
		Property.saveExtent(stream);
	}
	

	private static void loadExtents() throws FileNotFoundException, IOException, ClassNotFoundException {
		var stream = new ObjectInputStream(new FileInputStream(fileName));
		
		Property.loadExtent(stream);
	}
	

	private static void printExtentLength() throws ClassNotFoundException {
		System.out.println(Property.getExtent().size());
	}
	
	private static void printAges() throws ClassNotFoundException {
		for (var property: Property.getExtent()) {
			System.out.println(String.format("%s: %s", property.getAddress().toString(), property.getPropertyAge()));
		}
	}

	private static void printAverageAges() {
		System.out.println(Flat.calculateAveragePropertyAge());
	}
	
	private static void printTaxes() throws Exception {
		float area = 100;
		var owners = new ArrayList<String>();
		owners.add("100 123 234");
		
		var flat = new Flat(
				new Address("Testowa", "1"),
				area,
				LocalDate.now(),
				owners
		);
		
		var servicesPremise1 = new ServicePremise(
				new Address("Testowa", "1"),
				area,
				LocalDate.now(),
				owners
		);
		
		
		var servicesPremise2 = new ServicePremise(
				new Address("Testowa", "1"),
				area,
				LocalDate.now(),
				owners,
				50
		);
		
		System.out.println(String.format("Flat: %f", flat.calculateProperyTax()));
		System.out.println(String.format("Services Premise (default tax): %f", servicesPremise1.calculateProperyTax()));
		System.out.println(String.format("Services Premise (custom tax): %f", servicesPremise2.calculateProperyTax()));
	}
}
