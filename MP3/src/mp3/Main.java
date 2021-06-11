package mp3;

import java.util.Arrays;
import java.util.Date;

import mp3.Abstract.*;
import mp3.Dynamic.Table;
import mp3.MultiAspect.Order;
import mp3.MultiAspect.OrderWithDelivery;
import mp3.MultiAspect.OrderWithSelfPickup;
import mp3.MultiAspect.PaymentMethod;
import mp3.MultiInheritance.Crepes;
import mp3.MultiInheritance.Sauce;
import mp3.MultiInheritance.SideDish;
import mp3.Overlapping.Employee;
import mp3.utils.Exceptions;
import mp3.utils.Text;

public class Main {

	public static void main(String[] args) throws Exception {
		// ==== Abstract / polimorfizm ====
		System.out.println(Text.getH1("Abstract / polimorfizm"));
		var ed = new ExpressDelivery("Address 1", 30);
		var sd = new StandardDelivery("Address 1", 3);
		
		System.out.println(Text.getIndent("Express: " + ed.calculateDeliveryPrice()));
		System.out.println(Text.getIndent("Standard: " + sd.calculateDeliveryPrice()));
		
		
		// ==== Overlapping ====
		System.out.println(Text.getH1("Overlapping"));
		var cook = new Employee("C", "C");
		cook.makeCook("00001");
		
		var seller = new Employee("S", "S");
		seller.makeSeller(new Date());

		var sellerAndCook = new Employee("S", "S");
		sellerAndCook.makeCook("00002");
		sellerAndCook.makeSeller(new Date(1623409980000l));
		
		System.out.println(Text.getH2("Cook:"));
		System.out.println(Text.getIndent(cook.getCookLicenseNumber()));
		System.out.println(Text.getH2("Seller:"));
		System.out.println(Text.getIndent(seller.getDateOfTerminalTraining().toString()));
		
		System.out.println(Text.getH2("Cook and Seller:"));
		System.out.println(Text.getIndent(sellerAndCook.getCookLicenseNumber()));
		System.out.println(Text.getIndent(sellerAndCook.getDateOfTerminalTraining().toString()));
		
		System.out.println(Text.getH2("Cook accesses terminal date:"));
		Exceptions.printExpectedException(() -> cook.getDateOfTerminalTraining().toString());

		System.out.println(Text.getH2("Seller accesses cook license:"));
		Exceptions.printExpectedException(() -> seller.getCookLicenseNumber());

		
		// ==== Dynamic ====
		System.out.println(Text.getH1("Dynamic"));
		var table = Table.createIndoorsTable(1, 2, false);
		System.out.println(Text.getH2("Indoors table"));
		System.out.println(Text.getIndent(table.getIsInSmokingArea() ? "true" : "false"));
		Exceptions.printExpectedException(() -> table.getIsUnderUmbrella());

		table.makeOutdoors(true);
		
		System.out.println(Text.getH2("Outdoors table"));
		System.out.println(Text.getIndent(table.getIsUnderUmbrella() ? "true" : "false"));
		Exceptions.printExpectedException(() -> table.getIsInSmokingArea());
		

		// ==== Multi Inheritance ====
		System.out.println(Text.getH1("Multi Inheritance"));
		var crepes = new Crepes("Crepes", 10);
		
		crepes.addSauce(new Sauce("Strawberry"));
		crepes.addSideDish(new SideDish("Coleslav"));
		
		System.out.println(Text.getIndent(Arrays.toString(crepes.getSauces().stream().map(sauce -> sauce.getName()).toArray())));
		System.out.println(Text.getIndent(Arrays.toString(crepes.getSideDishes().stream().map(sideDish -> sideDish.getName()).toArray())));
		

		// ==== Multi Aspect Inheritance ====
		System.out.println(Text.getH1("Multi Aspect Inheritance"));
		var deliveryOnPickupOrder = new OrderWithDelivery(
			Order.createPaymentOnPickupOrder(100, PaymentMethod.Card),
			"address"
		);
		
		System.out.println(Text.getH2("WithDelivery and PaymentOnPickup"));
		System.out.println(Text.getIndent(deliveryOnPickupOrder.getAddress()));
		System.out.println(Text.getIndent(deliveryOnPickupOrder.getPaymentMethod().toString()));
		Exceptions.printExpectedException(() -> deliveryOnPickupOrder.getCardNumber());
		
		var deliveryPrepaymentOrder = new OrderWithDelivery(
			Order.createPrepaymentOrder(100, "1234"),
			"address"
		);
		
		System.out.println(Text.getH2("WithDelivery and Prepayment"));
		System.out.println(Text.getIndent(deliveryPrepaymentOrder.getAddress()));
		System.out.println(Text.getIndent(deliveryPrepaymentOrder.getCardNumber()));
		Exceptions.printExpectedException(() -> deliveryPrepaymentOrder.getPaymentMethod());
		
		var selfPickupOnPickupOrder = new OrderWithSelfPickup(
			Order.createPaymentOnPickupOrder(100, PaymentMethod.Card),
			new Date()
		);
		
		System.out.println(Text.getH2("WithDelivery and PaymentOnPickup"));
		System.out.println(Text.getIndent(selfPickupOnPickupOrder.getPickupDate().toString()));
		System.out.println(Text.getIndent(selfPickupOnPickupOrder.getPaymentMethod().toString()));
		Exceptions.printExpectedException(() -> selfPickupOnPickupOrder.getCardNumber());
		
		var selfPickupPrepaymentOrder = new OrderWithSelfPickup(
			Order.createPrepaymentOrder(100, "1234"),
			new Date()
		);
		
		System.out.println(Text.getH2("WithDelivery and Prepayment"));
		System.out.println(Text.getIndent(selfPickupPrepaymentOrder.getPickupDate().toString()));
		System.out.println(Text.getIndent(selfPickupPrepaymentOrder.getCardNumber()));
		Exceptions.printExpectedException(() -> selfPickupPrepaymentOrder.getPaymentMethod());
	}
}
